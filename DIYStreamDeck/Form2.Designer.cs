namespace DIYStreamDeck
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.saveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.radioDefault = new System.Windows.Forms.RadioButton();
            this.radioProgram = new System.Windows.Forms.RadioButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.findProgram = new System.Windows.Forms.Button();
            this.programPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.radioWindowsMute = new System.Windows.Forms.RadioButton();
            this.radioProgramMute = new System.Windows.Forms.RadioButton();
            this.inputProgram = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(15, 12);
            this.saveButton.Name = "saveButton";
            this.saveButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Opções:";
            // 
            // radioDefault
            // 
            this.radioDefault.AutoSize = true;
            this.radioDefault.Location = new System.Drawing.Point(50, 79);
            this.radioDefault.Name = "radioDefault";
            this.radioDefault.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioDefault.Size = new System.Drawing.Size(59, 17);
            this.radioDefault.TabIndex = 3;
            this.radioDefault.TabStop = true;
            this.radioDefault.Text = "Default";
            this.radioDefault.UseVisualStyleBackColor = true;
            this.radioDefault.CheckedChanged += new System.EventHandler(this.radioDefault_CheckedChanged);
            // 
            // radioProgram
            // 
            this.radioProgram.AutoSize = true;
            this.radioProgram.Location = new System.Drawing.Point(39, 106);
            this.radioProgram.Name = "radioProgram";
            this.radioProgram.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioProgram.Size = new System.Drawing.Size(70, 17);
            this.radioProgram.TabIndex = 4;
            this.radioProgram.TabStop = true;
            this.radioProgram.Text = "Programa";
            this.radioProgram.UseVisualStyleBackColor = true;
            this.radioProgram.CheckedChanged += new System.EventHandler(this.radioProgram_CheckedChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // findProgram
            // 
            this.findProgram.Enabled = false;
            this.findProgram.Location = new System.Drawing.Point(114, 103);
            this.findProgram.Name = "findProgram";
            this.findProgram.Size = new System.Drawing.Size(75, 23);
            this.findProgram.TabIndex = 8;
            this.findProgram.Text = "Find";
            this.findProgram.UseVisualStyleBackColor = true;
            this.findProgram.Click += new System.EventHandler(this.findProgram_Click);
            // 
            // programPath
            // 
            this.programPath.Location = new System.Drawing.Point(114, 133);
            this.programPath.Name = "programPath";
            this.programPath.ReadOnly = true;
            this.programPath.Size = new System.Drawing.Size(263, 20);
            this.programPath.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "WindowsSound:";
            // 
            // radioWindowsMute
            // 
            this.radioWindowsMute.AutoSize = true;
            this.radioWindowsMute.Location = new System.Drawing.Point(96, 179);
            this.radioWindowsMute.Name = "radioWindowsMute";
            this.radioWindowsMute.Size = new System.Drawing.Size(96, 17);
            this.radioWindowsMute.TabIndex = 12;
            this.radioWindowsMute.TabStop = true;
            this.radioWindowsMute.Text = "Windows Mute";
            this.radioWindowsMute.UseVisualStyleBackColor = true;
            this.radioWindowsMute.CheckedChanged += new System.EventHandler(this.radioWindowsMute_CheckedChanged);
            // 
            // radioProgramMute
            // 
            this.radioProgramMute.AutoSize = true;
            this.radioProgramMute.Location = new System.Drawing.Point(96, 200);
            this.radioProgramMute.Name = "radioProgramMute";
            this.radioProgramMute.Size = new System.Drawing.Size(91, 17);
            this.radioProgramMute.TabIndex = 13;
            this.radioProgramMute.TabStop = true;
            this.radioProgramMute.Text = "Program Mute";
            this.radioProgramMute.UseVisualStyleBackColor = true;
            this.radioProgramMute.CheckedChanged += new System.EventHandler(this.radioProgramMute_CheckedChanged);
            // 
            // inputProgram
            // 
            this.inputProgram.Enabled = false;
            this.inputProgram.Location = new System.Drawing.Point(188, 200);
            this.inputProgram.Name = "inputProgram";
            this.inputProgram.Size = new System.Drawing.Size(115, 20);
            this.inputProgram.TabIndex = 14;
            this.inputProgram.TextChanged += new System.EventHandler(this.inputProgram_TextChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 245);
            this.Controls.Add(this.inputProgram);
            this.Controls.Add(this.radioProgramMute);
            this.Controls.Add(this.radioWindowsMute);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.programPath);
            this.Controls.Add(this.findProgram);
            this.Controls.Add(this.radioProgram);
            this.Controls.Add(this.radioDefault);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveButton);
            this.Name = "Form2";
            this.Text = "Insert Config";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioDefault;
        private System.Windows.Forms.RadioButton radioProgram;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button findProgram;
        private System.Windows.Forms.TextBox programPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioWindowsMute;
        private System.Windows.Forms.RadioButton radioProgramMute;
        private System.Windows.Forms.TextBox inputProgram;
    }
}