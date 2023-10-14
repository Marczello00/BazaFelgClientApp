namespace MyApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LogoPicture = new PictureBox();
            LogoPictureLabel = new Label();
            DownloadButton = new Button();
            rimListView = new ListView();
            boltPatternDropDown = new ComboBox();
            diameterDropDown = new ComboBox();
            FilteringLabel = new Label();
            noMatchingRimsLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)LogoPicture).BeginInit();
            SuspendLayout();
            // 
            // LogoPicture
            // 
            LogoPicture.BackColor = Color.Transparent;
            LogoPicture.BackgroundImage = Properties.Resources.cover;
            LogoPicture.BackgroundImageLayout = ImageLayout.Zoom;
            LogoPicture.Location = new Point(26, 12);
            LogoPicture.Name = "LogoPicture";
            LogoPicture.Size = new Size(548, 198);
            LogoPicture.SizeMode = PictureBoxSizeMode.Zoom;
            LogoPicture.TabIndex = 1;
            LogoPicture.TabStop = false;
            LogoPicture.Paint += pictureBox1_Paint;
            // 
            // LogoPictureLabel
            // 
            LogoPictureLabel.AutoSize = true;
            LogoPictureLabel.BackColor = Color.Transparent;
            LogoPictureLabel.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            LogoPictureLabel.Location = new Point(216, 12);
            LogoPictureLabel.Name = "LogoPictureLabel";
            LogoPictureLabel.Size = new Size(183, 54);
            LogoPictureLabel.TabIndex = 2;
            LogoPictureLabel.Text = "Baza felg";
            // 
            // DownloadButton
            // 
            DownloadButton.Location = new Point(246, 216);
            DownloadButton.Name = "DownloadButton";
            DownloadButton.Size = new Size(123, 39);
            DownloadButton.TabIndex = 3;
            DownloadButton.Text = "Pobierz dane";
            DownloadButton.UseVisualStyleBackColor = true;
            DownloadButton.Click += button1_Click;
            // 
            // rimListView
            // 
            rimListView.Location = new Point(26, 359);
            rimListView.Name = "rimListView";
            rimListView.Size = new Size(548, 320);
            rimListView.TabIndex = 4;
            rimListView.UseCompatibleStateImageBehavior = false;
            rimListView.MouseClick += rimListView_MouseClick;
            // 
            // boltPatternDropDown
            // 
            boltPatternDropDown.FormattingEnabled = true;
            boltPatternDropDown.Location = new Point(120, 302);
            boltPatternDropDown.Name = "boltPatternDropDown";
            boltPatternDropDown.Size = new Size(121, 23);
            boltPatternDropDown.TabIndex = 5;
            boltPatternDropDown.SelectedIndexChanged += boltPatternDropDown_SelectedIndexChanged;
            // 
            // diameterDropDown
            // 
            diameterDropDown.FormattingEnabled = true;
            diameterDropDown.Location = new Point(269, 302);
            diameterDropDown.Name = "diameterDropDown";
            diameterDropDown.Size = new Size(121, 23);
            diameterDropDown.TabIndex = 6;
            diameterDropDown.SelectedIndexChanged += diameterDropDown_SelectedIndexChanged;
            // 
            // FilteringLabel
            // 
            FilteringLabel.AutoSize = true;
            FilteringLabel.Location = new Point(26, 305);
            FilteringLabel.Name = "FilteringLabel";
            FilteringLabel.Size = new Size(65, 15);
            FilteringLabel.TabIndex = 7;
            FilteringLabel.Text = "Filtrowanie";
            // 
            // noMatchingRimsLabel
            // 
            noMatchingRimsLabel.AutoSize = true;
            noMatchingRimsLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            noMatchingRimsLabel.Location = new Point(161, 466);
            noMatchingRimsLabel.Name = "noMatchingRimsLabel";
            noMatchingRimsLabel.Size = new Size(264, 37);
            noMatchingRimsLabel.TabIndex = 8;
            noMatchingRimsLabel.Text = "Brak pasujących felg!";
            noMatchingRimsLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(617, 742);
            Controls.Add(noMatchingRimsLabel);
            Controls.Add(DownloadButton);
            Controls.Add(FilteringLabel);
            Controls.Add(diameterDropDown);
            Controls.Add(boltPatternDropDown);
            Controls.Add(rimListView);
            Controls.Add(LogoPictureLabel);
            Controls.Add(LogoPicture);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)LogoPicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox LogoPicture;
        private Label LogoPictureLabel;
        private Button DownloadButton;
        private ListView rimListView;
        private ComboBox boltPatternDropDown;
        private ComboBox diameterDropDown;
        private Label FilteringLabel;
        private Label noMatchingRimsLabel;
    }
}