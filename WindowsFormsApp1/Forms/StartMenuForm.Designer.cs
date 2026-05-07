using System.Linq;

namespace WindowsFormsApp1.Core
{
    partial class StartMenuForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartMenuForm));
            this.buttonPlay = new System.Windows.Forms.Button();
            this.cage1 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.explanationFlagSpace = new System.Windows.Forms.Label();
            this.rightClickMouse = new System.Windows.Forms.PictureBox();
            this.flagSpaceLabel = new System.Windows.Forms.Label();
            this.explanationRevealSpace = new System.Windows.Forms.Label();
            this.revealSpaceLabel = new System.Windows.Forms.Label();
            this.explanationNumberedSpace = new System.Windows.Forms.Label();
            this.leftClickMouse = new System.Windows.Forms.PictureBox();
            this.numberedSpaceLabel = new System.Windows.Forms.Label();
            this.explanationGreenSpace = new System.Windows.Forms.Label();
            this.greenSpaceLabel = new System.Windows.Forms.Label();
            this.gameScreenPicture = new System.Windows.Forms.PictureBox();
            this.minesweepertitle = new System.Windows.Forms.Label();
            this.redMineIcon = new System.Windows.Forms.PictureBox();
            this.howToPlay = new System.Windows.Forms.Label();
            this.labelPlayerName = new System.Windows.Forms.Label();
            this.textBoxPlayerName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.rightClickMouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftClickMouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameScreenPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redMineIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPlay
            // 
            this.buttonPlay.BackColor = System.Drawing.Color.Lime;
            this.buttonPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlay.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold);
            this.buttonPlay.ForeColor = System.Drawing.Color.Black;
            this.buttonPlay.Location = new System.Drawing.Point(213, 470);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(106, 44);
            this.buttonPlay.TabIndex = 2;
            this.buttonPlay.Text = "Грати";
            this.buttonPlay.UseVisualStyleBackColor = false;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // cage1
            // 
            this.cage1.BackColor = System.Drawing.Color.Gray;
            this.cage1.Location = new System.Drawing.Point(3, 131);
            this.cage1.Name = "cage1";
            this.cage1.Size = new System.Drawing.Size(525, 1);
            this.cage1.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Location = new System.Drawing.Point(3, 266);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(525, 1);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Location = new System.Drawing.Point(3, 342);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(525, 1);
            this.panel2.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gray;
            this.panel3.Location = new System.Drawing.Point(3, 431);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(525, 1);
            this.panel3.TabIndex = 10;
            // 
            // explanationFlagSpace
            // 
            this.explanationFlagSpace.AutoSize = true;
            this.explanationFlagSpace.BackColor = System.Drawing.Color.Transparent;
            this.explanationFlagSpace.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold);
            this.explanationFlagSpace.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(140)))), ((int)(((byte)(59)))));
            this.explanationFlagSpace.Location = new System.Drawing.Point(125, 387);
            this.explanationFlagSpace.Name = "explanationFlagSpace";
            this.explanationFlagSpace.Size = new System.Drawing.Size(360, 18);
            this.explanationFlagSpace.TabIndex = 7;
            this.explanationFlagSpace.Text = "Позначити прапорцем поле, де може бути міна.";
            // 
            // rightClickMouse
            // 
            this.rightClickMouse.BackColor = System.Drawing.Color.Transparent;
            this.rightClickMouse.Image = ((System.Drawing.Image)(resources.GetObject("rightClickMouse.Image")));
            this.rightClickMouse.Location = new System.Drawing.Point(27, 344);
            this.rightClickMouse.Name = "rightClickMouse";
            this.rightClickMouse.Size = new System.Drawing.Size(86, 82);
            this.rightClickMouse.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rightClickMouse.TabIndex = 9;
            this.rightClickMouse.TabStop = false;
            // 
            // flagSpaceLabel
            // 
            this.flagSpaceLabel.AutoSize = true;
            this.flagSpaceLabel.BackColor = System.Drawing.Color.Transparent;
            this.flagSpaceLabel.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Bold);
            this.flagSpaceLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(140)))), ((int)(((byte)(59)))));
            this.flagSpaceLabel.Location = new System.Drawing.Point(124, 354);
            this.flagSpaceLabel.Name = "flagSpaceLabel";
            this.flagSpaceLabel.Size = new System.Drawing.Size(197, 23);
            this.flagSpaceLabel.TabIndex = 5;
            this.flagSpaceLabel.Text = "Права кнопка миші";
            // 
            // explanationRevealSpace
            // 
            this.explanationRevealSpace.AutoSize = true;
            this.explanationRevealSpace.BackColor = System.Drawing.Color.Transparent;
            this.explanationRevealSpace.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold);
            this.explanationRevealSpace.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(140)))), ((int)(((byte)(59)))));
            this.explanationRevealSpace.Location = new System.Drawing.Point(125, 307);
            this.explanationRevealSpace.Name = "explanationRevealSpace";
            this.explanationRevealSpace.Size = new System.Drawing.Size(192, 18);
            this.explanationRevealSpace.TabIndex = 6;
            this.explanationRevealSpace.Text = "Відкрити клітинку поля.";
            // 
            // revealSpaceLabel
            // 
            this.revealSpaceLabel.AutoSize = true;
            this.revealSpaceLabel.BackColor = System.Drawing.Color.Transparent;
            this.revealSpaceLabel.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Bold);
            this.revealSpaceLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(140)))), ((int)(((byte)(59)))));
            this.revealSpaceLabel.Location = new System.Drawing.Point(124, 274);
            this.revealSpaceLabel.Name = "revealSpaceLabel";
            this.revealSpaceLabel.Size = new System.Drawing.Size(186, 23);
            this.revealSpaceLabel.TabIndex = 4;
            this.revealSpaceLabel.Text = "Ліва кнопка миші";
            // 
            // explanationNumberedSpace
            // 
            this.explanationNumberedSpace.AutoSize = true;
            this.explanationNumberedSpace.BackColor = System.Drawing.Color.Transparent;
            this.explanationNumberedSpace.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold);
            this.explanationNumberedSpace.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(140)))), ((int)(((byte)(59)))));
            this.explanationNumberedSpace.Location = new System.Drawing.Point(150, 233);
            this.explanationNumberedSpace.Name = "explanationNumberedSpace";
            this.explanationNumberedSpace.Size = new System.Drawing.Size(264, 18);
            this.explanationNumberedSpace.TabIndex = 7;
            this.explanationNumberedSpace.Text = "Вказує, скільки мін навколо неї.";
            // 
            // leftClickMouse
            // 
            this.leftClickMouse.BackColor = System.Drawing.Color.Transparent;
            this.leftClickMouse.Image = ((System.Drawing.Image)(resources.GetObject("leftClickMouse.Image")));
            this.leftClickMouse.Location = new System.Drawing.Point(27, 268);
            this.leftClickMouse.Name = "leftClickMouse";
            this.leftClickMouse.Size = new System.Drawing.Size(85, 66);
            this.leftClickMouse.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.leftClickMouse.TabIndex = 8;
            this.leftClickMouse.TabStop = false;
            // 
            // numberedSpaceLabel
            // 
            this.numberedSpaceLabel.AutoSize = true;
            this.numberedSpaceLabel.BackColor = System.Drawing.Color.Transparent;
            this.numberedSpaceLabel.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Bold);
            this.numberedSpaceLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(140)))), ((int)(((byte)(59)))));
            this.numberedSpaceLabel.Location = new System.Drawing.Point(149, 208);
            this.numberedSpaceLabel.Name = "numberedSpaceLabel";
            this.numberedSpaceLabel.Size = new System.Drawing.Size(219, 23);
            this.numberedSpaceLabel.TabIndex = 5;
            this.numberedSpaceLabel.Text = "Нумерована клітинка";
            // 
            // explanationGreenSpace
            // 
            this.explanationGreenSpace.AutoSize = true;
            this.explanationGreenSpace.BackColor = System.Drawing.Color.Transparent;
            this.explanationGreenSpace.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold);
            this.explanationGreenSpace.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(140)))), ((int)(((byte)(59)))));
            this.explanationGreenSpace.Location = new System.Drawing.Point(150, 172);
            this.explanationGreenSpace.Name = "explanationGreenSpace";
            this.explanationGreenSpace.Size = new System.Drawing.Size(304, 18);
            this.explanationGreenSpace.TabIndex = 6;
            this.explanationGreenSpace.Text = "Можливо, тут є міна, а можливо, й ні.";
            // 
            // greenSpaceLabel
            // 
            this.greenSpaceLabel.AutoSize = true;
            this.greenSpaceLabel.BackColor = System.Drawing.Color.Transparent;
            this.greenSpaceLabel.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Bold);
            this.greenSpaceLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(140)))), ((int)(((byte)(59)))));
            this.greenSpaceLabel.Location = new System.Drawing.Point(149, 145);
            this.greenSpaceLabel.Name = "greenSpaceLabel";
            this.greenSpaceLabel.Size = new System.Drawing.Size(175, 23);
            this.greenSpaceLabel.TabIndex = 4;
            this.greenSpaceLabel.Text = "Зелена клітинка";
            // 
            // gameScreenPicture
            // 
            this.gameScreenPicture.BackColor = System.Drawing.Color.Transparent;
            this.gameScreenPicture.Image = global::WindowsFormsApp1.Properties.Resources.gamescreen;
            this.gameScreenPicture.Location = new System.Drawing.Point(13, 134);
            this.gameScreenPicture.Name = "gameScreenPicture";
            this.gameScreenPicture.Size = new System.Drawing.Size(128, 130);
            this.gameScreenPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gameScreenPicture.TabIndex = 3;
            this.gameScreenPicture.TabStop = false;
            // 
            // minesweepertitle
            // 
            this.minesweepertitle.AutoSize = true;
            this.minesweepertitle.BackColor = System.Drawing.Color.Transparent;
            this.minesweepertitle.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minesweepertitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.minesweepertitle.Location = new System.Drawing.Point(117, 2);
            this.minesweepertitle.Name = "minesweepertitle";
            this.minesweepertitle.Size = new System.Drawing.Size(251, 51);
            this.minesweepertitle.TabIndex = 0;
            this.minesweepertitle.Text = "Minesweeper";
            // 
            // redMineIcon
            // 
            this.redMineIcon.BackColor = System.Drawing.Color.Transparent;
            this.redMineIcon.Image = global::WindowsFormsApp1.Properties.Resources.redmine;
            this.redMineIcon.Location = new System.Drawing.Point(355, 2);
            this.redMineIcon.Name = "redMineIcon";
            this.redMineIcon.Size = new System.Drawing.Size(52, 60);
            this.redMineIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.redMineIcon.TabIndex = 1;
            this.redMineIcon.TabStop = false;
            // 
            // howToPlay
            // 
            this.howToPlay.AutoSize = true;
            this.howToPlay.BackColor = System.Drawing.Color.Transparent;
            this.howToPlay.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Bold);
            this.howToPlay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(140)))), ((int)(((byte)(59)))));
            this.howToPlay.Location = new System.Drawing.Point(10, 91);
            this.howToPlay.Name = "howToPlay";
            this.howToPlay.Size = new System.Drawing.Size(149, 32);
            this.howToPlay.TabIndex = 11;
            this.howToPlay.Text = "Як грати?";
            // 
            // labelPlayerName
            // 
            this.labelPlayerName.AutoSize = true;
            this.labelPlayerName.BackColor = System.Drawing.Color.Transparent;
            this.labelPlayerName.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold);
            this.labelPlayerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(140)))), ((int)(((byte)(59)))));
            this.labelPlayerName.Location = new System.Drawing.Point(85, 439);
            this.labelPlayerName.Name = "labelPlayerName";
            this.labelPlayerName.Size = new System.Drawing.Size(190, 22);
            this.labelPlayerName.TabIndex = 12;
            this.labelPlayerName.Text = "Введіть ваше ім\'я:";
            // 
            // textBoxPlayerName
            // 
            this.textBoxPlayerName.Font = new System.Drawing.Font("Consolas", 12F);
            this.textBoxPlayerName.Location = new System.Drawing.Point(281, 438);
            this.textBoxPlayerName.Name = "textBoxPlayerName";
            this.textBoxPlayerName.Size = new System.Drawing.Size(150, 26);
            this.textBoxPlayerName.TabIndex = 13;
            // 
            // StartMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.bgStartMenuForm;
            this.ClientSize = new System.Drawing.Size(532, 525);
            this.Controls.Add(this.textBoxPlayerName);
            this.Controls.Add(this.labelPlayerName);
            this.Controls.Add(this.gameScreenPicture);
            this.Controls.Add(this.howToPlay);
            this.Controls.Add(this.numberedSpaceLabel);
            this.Controls.Add(this.explanationGreenSpace);
            this.Controls.Add(this.greenSpaceLabel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.redMineIcon);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.minesweepertitle);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cage1);
            this.Controls.Add(this.rightClickMouse);
            this.Controls.Add(this.leftClickMouse);
            this.Controls.Add(this.explanationFlagSpace);
            this.Controls.Add(this.explanationNumberedSpace);
            this.Controls.Add(this.explanationRevealSpace);
            this.Controls.Add(this.flagSpaceLabel);
            this.Controls.Add(this.revealSpaceLabel);
            this.Controls.Add(this.buttonPlay);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StartMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartMenu";
            ((System.ComponentModel.ISupportInitialize)(this.rightClickMouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftClickMouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameScreenPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redMineIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Panel cage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label explanationFlagSpace;
        private System.Windows.Forms.PictureBox rightClickMouse;
        private System.Windows.Forms.Label flagSpaceLabel;
        private System.Windows.Forms.Label explanationRevealSpace;
        private System.Windows.Forms.Label revealSpaceLabel;
        private System.Windows.Forms.Label explanationNumberedSpace;
        private System.Windows.Forms.PictureBox leftClickMouse;
        private System.Windows.Forms.Label numberedSpaceLabel;
        private System.Windows.Forms.Label explanationGreenSpace;
        private System.Windows.Forms.Label greenSpaceLabel;
        private System.Windows.Forms.PictureBox gameScreenPicture;
        private System.Windows.Forms.Label minesweepertitle;
        private System.Windows.Forms.PictureBox redMineIcon;
        private System.Windows.Forms.Label howToPlay;
        private System.Windows.Forms.Label labelPlayerName;
        private System.Windows.Forms.TextBox textBoxPlayerName;
    }
}