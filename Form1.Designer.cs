namespace jsrsetup
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
            widthBox = new TextBox();
            label1 = new Label();
            heightBox = new TextBox();
            msaaBox = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            label4 = new Label();
            checkBox1 = new CheckBox();
            SaveButton = new Button();
            label5 = new Label();
            SaveAndPlayButton = new Button();
            SuspendLayout();
            // 
            // widthBox
            // 
            widthBox.Location = new Point(101, 31);
            widthBox.Name = "widthBox";
            widthBox.Size = new Size(53, 23);
            widthBox.TabIndex = 0;
            widthBox.TextChanged += widthBox_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 34);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 1;
            label1.Text = "Resolution";
            // 
            // heightBox
            // 
            heightBox.Location = new Point(178, 31);
            heightBox.Name = "heightBox";
            heightBox.Size = new Size(53, 23);
            heightBox.TabIndex = 2;
            heightBox.TextChanged += heightBox_TextChanged;
            // 
            // msaaBox
            // 
            msaaBox.FormattingEnabled = true;
            msaaBox.Items.AddRange(new object[] { "1", "2", "4", "8" });
            msaaBox.Location = new Point(101, 70);
            msaaBox.MaxDropDownItems = 4;
            msaaBox.MaxLength = 1;
            msaaBox.Name = "msaaBox";
            msaaBox.Size = new Size(47, 23);
            msaaBox.TabIndex = 4;
            msaaBox.Text = "1";
            msaaBox.SelectedIndexChanged += msaaBox_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 73);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 5;
            label3.Text = "MSAA";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(160, 39);
            label2.Name = "label2";
            label2.Size = new Size(12, 15);
            label2.TabIndex = 6;
            label2.Text = "x";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 112);
            label4.Name = "label4";
            label4.Size = new Size(64, 15);
            label4.TabIndex = 8;
            label4.Text = "Windowed";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(101, 113);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 14);
            checkBox1.TabIndex = 9;
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(17, 158);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(99, 29);
            SaveButton.TabIndex = 10;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(233, 193);
            label5.Name = "label5";
            label5.Size = new Size(100, 15);
            label5.TabIndex = 11;
            label5.Text = "Made by Loomeh";
            // 
            // SaveAndPlayButton
            // 
            SaveAndPlayButton.Location = new Point(122, 158);
            SaveAndPlayButton.Name = "SaveAndPlayButton";
            SaveAndPlayButton.Size = new Size(99, 29);
            SaveAndPlayButton.TabIndex = 12;
            SaveAndPlayButton.Text = "Save And Play";
            SaveAndPlayButton.UseVisualStyleBackColor = true;
            SaveAndPlayButton.Click += SaveAndPlayButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(345, 214);
            Controls.Add(SaveAndPlayButton);
            Controls.Add(label5);
            Controls.Add(SaveButton);
            Controls.Add(checkBox1);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(msaaBox);
            Controls.Add(heightBox);
            Controls.Add(label1);
            Controls.Add(widthBox);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox widthBox;
        private Label label1;
        private TextBox heightBox;
        private ComboBox msaaBox;
        private Label label3;
        private Label label2;
        private Label label4;
        private CheckBox checkBox1;
        private Button SaveButton;
        private Label label5;
        private Button SaveAndPlayButton;
    }
}
