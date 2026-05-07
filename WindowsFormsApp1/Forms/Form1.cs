using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1.Core
{
    public partial class Form1 : Form
    {
        private Game game;
        private Difficulty selectedDifficulty;
        private Timer timer;
        private int elapsedSeconds = 0;
        private int totalMines = 0;
        private bool isPanelExpanded = true;
        private int panelMaxHeight = 150;
        private int panelMinHeight = 0;
        private Timer panelTimer;
        private Dictionary<string, Image> cellImages;
        private int cellSize;
        private const int PanelAnimationStep = 10;
        private GameRenderer renderer;
        private Label customTooltip;
        private bool isPaused = false;
        private bool gameStarted = false;
        private Panel pauseOverlayPanel;
        private Label pauseLabel;
        private Button resumeButton;
        private Difficulty currentLevel;
        private Dictionary<Difficulty, int> bestTimes;
        private readonly string bestTimesFile = "best_times.txt";

        public Form1()
        {
            InitializeComponent();
            SetupUI();

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += GameTimer_Tick;

            btnSafeCell.Click += BtnSafeCell_Click;
            this.borderForAdditionInfo.Paint += new PaintEventHandler(this.borderForAdditionInfo_Paint);
            this.pausePanel.Click += new System.EventHandler(this.pausePanel_Click);

            SetupPauseOverlay();
            LoadBestTimes();
        }

        private void SetupUI()
        {
            this.Text = "Minesweeper";

            panelGame.Visible = true;
            buttonNewGame.Visible = false;
            buttonStartGame.Enabled = true;

            labelTimer.Text = "Час: 0 с";

            radioEasy.CheckedChanged += RadioDifficulty_CheckedChanged;
            radioMedium.CheckedChanged += RadioDifficulty_CheckedChanged;
            radioHard.CheckedChanged += RadioDifficulty_CheckedChanged;

            buttonStartGame.Click += (s, e) => StartGame();
            buttonNewGame.Click += (s, e) => StartGame();
            buttonNewGame.Enabled = false;

            groupDifficulty.Height = panelMaxHeight;

            panelTimer = new Timer();
            panelTimer.Interval = 15;
            panelTimer.Tick += PanelTimer_Tick;

            buttonTogglePanel.Click += (s, e) =>
            {
                panelTimer.Start();
            };

            SetupCustomTooltip();
            LoadCellImages();
        }

        private void StartGame()
        {
            UpdateSelectedDifficulty();
            game = new Game(selectedDifficulty);
            gameStarted = true;
            game.ResetFirstClick();
            panelGame.Visible = true;
            buttonNewGame.Visible = true;
            buttonNewGame.Enabled = true;
            buttonStartGame.Visible = false;

            int rows = game.Board.Rows;
            int cols = game.Board.Columns;

            panelGame.Width = 660;
            panelGame.Height = 480;

            cellSize = Math.Min(panelGame.Width / cols, panelGame.Height / rows);

            elapsedSeconds = 0;
            labelTimer.Text = "Час: 0 с";
            timer.Stop();
            timer.Start();

            renderer = new GameRenderer(panelGame, game, cellSize, cellImages);
            renderer.DrawBoard(Cell_Click);
            btnSafeCell.Enabled = true;
            lblSafeOpensRemaining.Text = $"Залишилось:\n{renderer.GetRemainingHighlights()}";
            labelProgress.Text = $"Відкрито:\n{game.GetRevealedPercentage()}%";


            totalMines = game.Board.TotalMines;

            btnSafeCell.Visible = true;
            panelGame.Enabled = true;


            currentLevel = selectedDifficulty;
            lvlNow.Text = $"Рівень: {GetDifficultyDisplayName(currentLevel)}";
            int best = bestTimes[currentLevel];
            topRecord.Text = best == int.MaxValue
                ? "Найкращий час:---"
                : $"Найкращий час: {best} с";

            UpdateMinesLeft();
        }

        private void RadioDifficulty_CheckedChanged(object sender, EventArgs e)
        {
            if (radioEasy.Checked) selectedDifficulty = Difficulty.Easy;
            else if (radioMedium.Checked) selectedDifficulty = Difficulty.Medium;
            else if (radioHard.Checked) selectedDifficulty = Difficulty.Hard;
        }

        private void UpdateSelectedDifficulty()
        {
            if (radioEasy.Checked) selectedDifficulty = Difficulty.Easy;
            else if (radioMedium.Checked) selectedDifficulty = Difficulty.Medium;
            else if (radioHard.Checked) selectedDifficulty = Difficulty.Hard;
        }

        private void UpdateMinesLeft()
        {
            int flagged = game.Board.Cells.Cast<Cell>().Count(c => c.IsFlagged);
            int remaining = totalMines - flagged;
            labelMinesLeft.Text = $"Міни: {remaining}";
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            elapsedSeconds++;
            labelTimer.Text = $"Час: {elapsedSeconds} с";
        }

        private void Cell_Click(object sender, MouseEventArgs e)
        {
            if (sender is not PictureBox pic || game.State != GameState.Playing) return;

            Point p = (Point)pic.Tag;
            List<Cell> changedCells = new();

            if (e.Button == MouseButtons.Left)
            {
                changedCells = game.RevealCell(p.X, p.Y);
            }
            else if (e.Button == MouseButtons.Right)
            {
                game.ToggleFlag(p.X, p.Y);
                changedCells.Add(game.Board.GetCell(p.X, p.Y));
            }

            renderer.RedrawCells(changedCells);
            UpdateMinesLeft();
            labelProgress.Text = $"Відкрито:\n{game.GetRevealedPercentage()}%";

            if (game.State == GameState.Lost)
            {
                timer.Stop();
                var result = MessageBox.Show("Гра закінчилась. Ви програли!\n\nСпробувати ще раз?", "Поразка", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) StartGame();
            }

            else if (game.State == GameState.Won)
            {
                timer.Stop();

                if (elapsedSeconds < bestTimes[selectedDifficulty])
                {
                    bestTimes[selectedDifficulty] = elapsedSeconds;
                    SaveBestTimesToFile();
                    MessageBox.Show($"Новий рекорд: {elapsedSeconds} секунд для рівня {GetDifficultyDisplayName(selectedDifficulty)}!", "Рекорд");
                }

                if (selectedDifficulty == Difficulty.Easy)
                {
                    var result = MessageBox.Show(
                        "Вітаємо, Ви пройшли легкий рівень!\n\nПерейти до середнього рівня?",
                        "Перемога",
                        MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        radioMedium.Checked = true;
                        StartGame();
                        labelProgress.Text = $"Відкрито:\n{game.GetRevealedPercentage()}%";
                    }
                }
                else if (selectedDifficulty == Difficulty.Medium)
                {
                    var result = MessageBox.Show(
                        "Чудово! Ви пройшли середній рівень.\n\nПерейти до складного рівня?",
                        "Перемога",
                        MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        radioHard.Checked = true;
                        StartGame();
                        labelProgress.Text = $"Відкрито:\n{game.GetRevealedPercentage()}%";
                    }
                }
                else if (selectedDifficulty == Difficulty.Hard)
                {
                    MessageBox.Show(
                        "Вітаємо, Вам вдалось пройти останній рівень складності!",
                        "Перемога",
                        MessageBoxButtons.OK);
                }
            }
        }

        private void PanelTimer_Tick(object sender, EventArgs e)
        {


            if (!isPanelExpanded)
            {
                groupDifficulty.Height += PanelAnimationStep;
                if (groupDifficulty.Height >= panelMaxHeight)
                {
                    groupDifficulty.Height = panelMaxHeight;
                    panelTimer.Stop();
                    isPanelExpanded = true;
                }
            }
            else
            {
                groupDifficulty.Height -= PanelAnimationStep;
                if (groupDifficulty.Height <= panelMinHeight)
                {
                    groupDifficulty.Height = panelMinHeight;
                    panelTimer.Stop();
                    isPanelExpanded = false;
                }
            }
        }

        private void LoadCellImages()
        {
            cellImages = new Dictionary<string, Image>
            {
        { "field_0", Properties.Resources.field_0 },
        { "ground", Properties.Resources.ground },
        { "mine", Properties.Resources.mine },
        { "flag", Properties.Resources.flag },
        { "field_1", Properties.Resources.field_1 },
        { "field_2", Properties.Resources.field_2 },
        { "field_3", Properties.Resources.field_3 },
        { "field_4", Properties.Resources.field_4 },
        { "field_5", Properties.Resources.field_5 },
        { "field_6", Properties.Resources.field_6 },
        };
        }

        private void BtnSafeCell_Click(object sender, EventArgs e)
        {
            var safeCell = game.GetSafeCell();
            if (safeCell != null)
            {
                renderer.HighlightCell(safeCell);
            }
            lblSafeOpensRemaining.Text = $"Залишилось:\n{renderer.GetRemainingHighlights()}";

            if (renderer.IsHighlightsLimitReached())
            {
                btnSafeCell.Enabled = false;
            }
        }

        private void SetupCustomTooltip()
        {
            customTooltip = new Label();
            customTooltip.BackColor = Color.OliveDrab;
            customTooltip.ForeColor = Color.Black;
            customTooltip.Font = new Font("Times New Roman", 11, FontStyle.Bold);
            customTooltip.BorderStyle = BorderStyle.FixedSingle;
            customTooltip.AutoSize = true;
            customTooltip.Padding = new Padding(5);
            customTooltip.Visible = false;
            this.Controls.Add(customTooltip);

            btnSafeCell.MouseEnter += (s, e) =>
            {
                var btn = s as Control;
                customTooltip.Text = "Це безпечне відкриття." +
                    "\nВоно допоможе знайти клітинки без мін." +
                    "\nДля рівней складності є своя кількість:" +
                    "\n      Для легкого - 3 безпечних відкриттів;" +
                    "\n      Для середнього - 5 безпечних відкриттів;" +
                    "\n      Для складного - 7 безпечних відкриттів;" +
                    "\nКористуйся з розумом!";

                customTooltip.Visible = true;
                customTooltip.Update();

                var btnScreenPos = btn.PointToScreen(Point.Empty);
                var btnClientPos = this.PointToClient(btnScreenPos);

                int tooltipX = btnClientPos.X;
                int tooltipY = btnClientPos.Y - customTooltip.Height - 5;

                if (tooltipY < 0)
                    tooltipY = btnClientPos.Y + btn.Height + 5;

                customTooltip.Location = new Point(tooltipX, tooltipY);

                customTooltip.BringToFront();
            };

            btnSafeCell.MouseLeave += (s, e) =>
            {
                customTooltip.Visible = false;
            };
        }

        private void borderForAdditionInfo_Paint(object sender, PaintEventArgs e)
        {
            Control p = (Control)sender;
            using (Pen pen = new Pen(Color.Black, 2))
            {
                e.Graphics.DrawRectangle(pen, 1, 1, p.Width - 2, p.Height - 2);
            }

            this.Controls.SetChildIndex(this.borderForAdditionInfo, 4);
        }

        private void SetupPauseOverlay()
        {
            pauseOverlayPanel = new Panel
            {
                Size = new Size(831, 489),
                Location = new Point((this.ClientSize.Width - 658) / 2, (this.ClientSize.Height - 534) / 2),
                BackColor = Color.FromArgb(0, 0, 0),
                Visible = false
            };

            pauseLabel = new Label
            {
                Text = "Гру призупинено",
                AutoSize = true,
                Font = new Font("Consolas", 24, FontStyle.Bold),
                ForeColor = Color.FromArgb(90, 140, 59),
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point((pauseOverlayPanel.Width - 280) / 2, 100)
            };

            resumeButton = new Button
            {
                Text = "Продовжити",
                Font = new Font("Consolas", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(90, 140, 59),
                BackColor = Color.Black,
                Size = new Size(150, 40),
                FlatStyle = FlatStyle.Flat,
                Location = new Point((pauseOverlayPanel.Width - 136) / 2, 300)
            };

            resumeButton.Click += (s, e) =>
            {
                isPaused = false;
                timer.Start();

                pauseOverlayPanel.Visible = false;

                panelGame.Enabled = true;
                buttonNewGame.Enabled = true;
                buttonStartGame.Enabled = true;

                radioEasy.Enabled = true;
                radioMedium.Enabled = true;
                radioHard.Enabled = true;

                lblSafeOpensRemaining.BringToFront();
                labelProgress.BringToFront();
                customTooltip.BringToFront();
                btnSafeCell.BringToFront();
            };


            pauseOverlayPanel.Controls.Add(pauseLabel);
            pauseOverlayPanel.Controls.Add(resumeButton);
            this.Controls.Add(pauseOverlayPanel);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                if (!gameStarted || game.State != GameState.Playing)
                    return true;

                if (!isPaused)
                {
                    isPaused = true;
                    timer.Stop();

                    panelGame.Enabled = false;
                    buttonNewGame.Enabled = false;
                    buttonStartGame.Enabled = false;

                    radioEasy.Enabled = false;
                    radioMedium.Enabled = false;
                    radioHard.Enabled = false;

                    pauseOverlayPanel.Visible = true;
                    pauseOverlayPanel.BringToFront();
                }
                else
                {
                    isPaused = false;
                    timer.Start();

                    panelGame.Enabled = true;
                    buttonNewGame.Enabled = true;
                    buttonStartGame.Enabled = true;

                    radioEasy.Enabled = true;
                    radioMedium.Enabled = true;
                    radioHard.Enabled = true;

                    pauseOverlayPanel.Visible = false;
                    lblSafeOpensRemaining.BringToFront();
                    labelProgress.BringToFront();
                    customTooltip.BringToFront();
                    btnSafeCell.BringToFront();
                }

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void pausePanel_Click(object sender, EventArgs e)
        {
            if (!gameStarted || game.State != GameState.Playing)
                return;

            if (isPaused) return;

                isPaused = true;
                timer.Stop();

                panelGame.Enabled = false;
                buttonNewGame.Enabled = false;
                buttonStartGame.Enabled = false;

                radioEasy.Enabled = false;
                radioMedium.Enabled = false;
                radioHard.Enabled = false;

                pauseOverlayPanel.Visible = true;
                pauseOverlayPanel.BringToFront();
        }

        private void LoadBestTimes()
        {
            bestTimes = new Dictionary<Difficulty, int>
            {
                { Difficulty.Easy, int.MaxValue },
                { Difficulty.Medium, int.MaxValue },
                { Difficulty.Hard, int.MaxValue }
            };

            if (!File.Exists(bestTimesFile)) return;

            var lines = File.ReadAllLines(bestTimesFile);
            foreach (var line in lines)
            {
                var parts = line.Split('=');
                if (parts.Length != 2) continue;

                if (Enum.TryParse(parts[0], out Difficulty diff) && int.TryParse(parts[1], out int time))
                {
                    bestTimes[diff] = time;
                }
            }
        }

        private void SaveBestTimesToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(bestTimesFile))
                {
                    foreach (var pair in bestTimes)
                    {
                        writer.WriteLine($"{pair.Key}={pair.Value}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка збереження найкращих часів: {ex.Message}");
            }
        }

        private string GetDifficultyDisplayName(Difficulty diff)
        {
            return diff switch
            {
                Difficulty.Easy => "Легкий",
                Difficulty.Medium => "Середній",
                Difficulty.Hard => "Складний",
                _ => "Невідомо"
            };
        }
    }
}