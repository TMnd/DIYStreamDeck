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
            this.f16 = new System.Windows.Forms.Button();
            this.f17 = new System.Windows.Forms.Button();
            this.f18 = new System.Windows.Forms.Button();
            this.f19 = new System.Windows.Forms.Button();
            this.f20 = new System.Windows.Forms.Button();
            this.f21 = new System.Windows.Forms.Button();
            this.remove = new System.Windows.Forms.Button();
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
            // f16
            // 
            this.f16.Location = new System.Drawing.Point(8, 138);
            this.f16.Name = "f16";
            this.f16.Size = new System.Drawing.Size(92, 83);
            this.f16.TabIndex = 8;
            this.f16.Text = "F16";
            this.f16.UseVisualStyleBackColor = true;
            this.f16.Click += new System.EventHandler(this.f16_Click);
            // 
            // f17
            // 
            this.f17.Location = new System.Drawing.Point(106, 138);
            this.f17.Name = "f17";
            this.f17.Size = new System.Drawing.Size(92, 83);
            this.f17.TabIndex = 9;
            this.f17.Text = "F17";
            this.f17.UseVisualStyleBackColor = true;
            this.f17.Click += new System.EventHandler(this.f17_Click);
            // 
            // f18
            // 
            this.f18.Location = new System.Drawing.Point(204, 138);
            this.f18.Name = "f18";
            this.f18.Size = new System.Drawing.Size(92, 83);
            this.f18.TabIndex = 10;
            this.f18.Text = "F18";
            this.f18.UseVisualStyleBackColor = true;
            this.f18.Click += new System.EventHandler(this.f18_Click);
            // 
            // f19
            // 
            this.f19.Location = new System.Drawing.Point(9, 227);
            this.f19.Name = "f19";
            this.f19.Size = new System.Drawing.Size(92, 83);
            this.f19.TabIndex = 11;
            this.f19.Text = "F19";
            this.f19.UseVisualStyleBackColor = true;
            this.f19.Click += new System.EventHandler(this.f19_Click);
            // 
            // f20
            // 
            this.f20.Location = new System.Drawing.Point(106, 227);
            this.f20.Name = "f20";
            this.f20.Size = new System.Drawing.Size(92, 83);
            this.f20.TabIndex = 12;
            this.f20.Text = "F20";
            this.f20.UseVisualStyleBackColor = true;
            this.f20.Click += new System.EventHandler(this.f20_Click);
            // 
            // f21
            // 
            this.f21.Location = new System.Drawing.Point(205, 227);
            this.f21.Name = "f21";
            this.f21.Size = new System.Drawing.Size(92, 83);
            this.f21.TabIndex = 13;
            this.f21.Text = "F21";
            this.f21.UseVisualStyleBackColor = true;
            this.f21.Click += new System.EventHandler(this.f21_Click);
            // 
            // remove
            // 
            this.remove.Location = new System.Drawing.Point(151, 10);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(59, 21);
            this.remove.TabIndex = 14;
            this.remove.Text = "Remove";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 326);
            this.Controls.Add(this.remove);
            this.Controls.Add(this.f21);
            this.Controls.Add(this.f20);
            this.Controls.Add(this.f19);
            this.Controls.Add(this.f18);
            this.Controls.Add(this.f17);
            this.Controls.Add(this.f16);
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
        private System.Windows.Forms.Button f16;
        private System.Windows.Forms.Button f17;
        private System.Windows.Forms.Button f18;
        private System.Windows.Forms.Button f19;
        private System.Windows.Forms.Button f20;
        private System.Windows.Forms.Button f21;
        private System.Windows.Forms.Button remove;
    }
}

