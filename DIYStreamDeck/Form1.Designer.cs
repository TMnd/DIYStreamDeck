using System.Drawing;

namespace DIYStreamDeck
{
    partial class Form1
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
            this.selectProfile = new System.Windows.Forms.ComboBox();
            this.newConfig = new System.Windows.Forms.Button();
            this.f13 = new System.Windows.Forms.Button();
            this.f14 = new System.Windows.Forms.Button();
            this.f15 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // selectProfile
            // 
            this.selectProfile.FormattingEnabled = true;
            this.selectProfile.Location = new System.Drawing.Point(9, 10);
            this.selectProfile.Margin = new System.Windows.Forms.Padding(2);
            this.selectProfile.Name = "selectProfile";
            this.selectProfile.Size = new System.Drawing.Size(92, 21);
            this.selectProfile.Sorted = true;
            this.selectProfile.TabIndex = 0;
            this.selectProfile.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // newConfig
            // 
            this.newConfig.Location = new System.Drawing.Point(106, 10);
            this.newConfig.Name = "newConfig";
            this.newConfig.Size = new System.Drawing.Size(39, 21);
            this.newConfig.TabIndex = 4;
            this.newConfig.Text = "New";
            this.newConfig.UseVisualStyleBackColor = true;
            this.newConfig.Click += new System.EventHandler(this.newConfig_Click);
            // 
            // f13
            // 
            this.f13.Location = new System.Drawing.Point(9, 49);
            this.f13.Name = "f13";
            this.f13.Size = new System.Drawing.Size(92, 83);
            this.f13.TabIndex = 5;
            this.f13.Text = "F13";
            this.f13.UseVisualStyleBackColor = true;
            this.f13.Click += new System.EventHandler(this.f13_Click);
            // 
            // f14
            // 
            this.f14.Location = new System.Drawing.Point(107, 49);
            this.f14.Name = "f14";
            this.f14.Size = new System.Drawing.Size(92, 83);
            this.f14.TabIndex = 6;
            this.f14.Text = "F14";
            this.f14.UseVisualStyleBackColor = true;
            this.f14.Click += new System.EventHandler(this.f14_Click);
            // 
            // f15
            // 
            this.f15.Location = new System.Drawing.Point(205, 49);
            this.f15.Name = "f15";
            this.f15.Size = new System.Drawing.Size(92, 83);
            this.f15.TabIndex = 7;
            this.f15.Text = "F15";
            this.f15.UseVisualStyleBackColor = true;
            this.f15.Click += new System.EventHandler(this.f15_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 150);
            this.Controls.Add(this.f15);
            this.Controls.Add(this.f13);
            this.Controls.Add(this.newConfig);
            this.Controls.Add(this.f14);
            this.Controls.Add(this.selectProfile);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox selectProfile;
        private System.Windows.Forms.Button newConfig;
        private System.Windows.Forms.Button f13;
        private System.Windows.Forms.Button f14;
        private System.Windows.Forms.Button f15;
    }
}

