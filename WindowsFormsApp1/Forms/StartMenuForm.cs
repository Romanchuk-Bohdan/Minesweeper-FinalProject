using System;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace WindowsFormsApp1.Core
{
    public partial class StartMenuForm : Form
    {
        Panel overlayPanel;

        public StartMenuForm()
        {
            InitializeComponent();
            this.Text = "Game menu";

            overlayPanel = new Panel();
            overlayPanel.BackColor = Color.FromArgb(128, Color.Black);
            overlayPanel.Size = new Size(523, 515);
            overlayPanel.Location = new Point(5, 7);
            overlayPanel.Name = "overlayPanel";
            overlayPanel.BringToFront();

            overlayPanel.Controls.Add(minesweepertitle);
            overlayPanel.Controls.Add(redMineIcon);
            overlayPanel.Controls.Add(howToPlay);
            overlayPanel.Controls.Add(greenSpaceLabel);
            overlayPanel.Controls.Add(explanationGreenSpace);
            overlayPanel.Controls.Add(numberedSpaceLabel);
            overlayPanel.Controls.Add(explanationNumberedSpace);
            overlayPanel.Controls.Add(leftClickMouse);
            overlayPanel.Controls.Add(rightClickMouse);
            overlayPanel.Controls.Add(revealSpaceLabel);
            overlayPanel.Controls.Add(explanationRevealSpace);
            overlayPanel.Controls.Add(flagSpaceLabel);
            overlayPanel.Controls.Add(explanationFlagSpace);
            overlayPanel.Controls.Add(buttonPlay);
            overlayPanel.Controls.Add(labelPlayerName);
            overlayPanel.Controls.Add(textBoxPlayerName);

            this.Controls.Add(overlayPanel);
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            string playerName = textBoxPlayerName.Text.Trim();
            if (string.IsNullOrEmpty(playerName))
            {
                playerName = "Guest";
            }

            bool profileExists = false;
            foreach (var p in ProfileManager.Instance.GetAllProfiles())
            {
                if (p.Name.Equals(playerName, StringComparison.OrdinalIgnoreCase))
                {
                    profileExists = true;
                    break;
                }
            }

            if (!profileExists)
            {
                ProfileManager.Instance.CreateProfile(playerName);
            }

            ProfileManager.Instance.SetCurrentProfile(playerName);

            this.Hide();
            using (var mainForm = new Form1())
            {
                mainForm.ShowDialog();
            }
            this.Close();
        }
    }
}
