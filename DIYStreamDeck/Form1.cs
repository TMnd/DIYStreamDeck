using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DIYStreamDeck
{
    public partial class Form1 : Form
    {
        private Dictionary<string, string> configLocations = new Dictionary<string, string>();
        private profile profile;
        private XmlTextReader reader = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadConfig();

            string startupPath = System.IO.Directory.GetCurrentDirectory() + "/Profiles";

            if (!Directory.Exists(startupPath)){
                DirectoryInfo di = Directory.CreateDirectory(startupPath);
            }

            string[] filePaths = Directory.GetFiles(startupPath,"*.xml");

            foreach (String file in filePaths)
            {
                String[] aux = file.Split('\\');
                String key = aux[aux.Length - 1].Split('.')[0];
                String value = file;

                configLocations.Add(key, value);
                comboBox1.Items.Add(key);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedEmployee = (string)comboBox1.SelectedItem;
            profile = new profile(selectedEmployee);
            label2.Text = selectedEmployee;

            profile.saveConfig();
        }

        private void loadConfig()
        {
            string activeProfile = System.IO.Directory.GetCurrentDirectory() + "/activeProfile.xml";

            try
            {
                //Load the reader with the XML file.
                reader = new XmlTextReader(activeProfile);
                XmlDocument xml = new XmlDocument();
                string filePath = "D:\\Nextcloud\\Projectos Pessoais\\C#\\DIYStreamDeck\\DIYStreamDeck\\bin\\Debug\\activeProfile.xml";
                xml.Load(filePath);
                string id = xml.SelectSingleNode("profile/title").InnerText;
                label2.Text = id;
                comboBox1.SelectedText = id;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

    }
}
