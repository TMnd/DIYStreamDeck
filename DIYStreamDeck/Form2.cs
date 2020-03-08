using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIYStreamDeck
{
    public partial class Form2 : Form
    {
        profile profile;
        string button;
        string type, program;

        public Form2(profile profile, string button)
        {
            InitializeComponent();
            this.profile = profile;
            this.button = button;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ArrayList a = profile.getButtonData(button);
            switch (a[0])
            {
                case "Program":
                    radioProgram.Checked = true;
                    programPath.Text = a[1].ToString();
                    break;
                case "Windows":
                    if(a[1].Equals(""))
                        radioWindowsMute.Checked = true;
                    else
                    {
                        radioProgramMute.Checked = true;
                        inputProgram.Text = a[1].ToString().Split('\\')[1];
                    }
                    break;
                default:
                    radioDefault.Checked = true;
                    break;
            }
        }

        private void findProgram_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "All Files (*.exe)|*.exe";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string sFileName = openFileDialog1.FileName;
                Console.WriteLine(sFileName);
                programPath.Text = sFileName;
                program = sFileName;
            }
        }

        private void radioDefault_CheckedChanged(object sender, EventArgs e)
        {
            if (radioDefault.Checked == true)
            {
                programPath.Text = "";
                type = "Default";
                program = "";
            }
        }

        private void radioProgram_CheckedChanged(object sender, EventArgs e)
        {
            if (radioProgram.Checked == true)
            {
                findProgram.Enabled = true;
                type = "Program";
                
            }
            else
            {
                findProgram.Enabled = false;
            }
                
        }

        private void radioWindowsMute_CheckedChanged(object sender, EventArgs e)
        {
            if (radioWindowsMute.Checked == true)
            {
                programPath.Text = "";
                type = "Windows";
                program = "";
            }   
        }

        private void radioProgramMute_CheckedChanged(object sender, EventArgs e)
        {
            type = "Windows";
            if (radioProgramMute.Checked == true)
            {
                programPath.Text = "";
                inputProgram.Enabled = true;
            }
            else
            {
                inputProgram.Enabled = false;
            }   
        }

        private void inputProgram_TextChanged(object sender, EventArgs e)
        {
            program = ".\\"+inputProgram.Text;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            ArrayList SubData = new ArrayList();

            SubData.Add(type);
            SubData.Add(program);

            profile.setButtonData(button, SubData);

            Close();
        }
    }
}
