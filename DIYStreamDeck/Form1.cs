using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Utilities;
using VideoPlayerController;

namespace DIYStreamDeck
{
    public partial class Form1 : Form
    {
        // The GetForegroundWindow function returns a handle to the foreground window
        // (the window  with which the user is currently working).
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        // The GetWindowThreadProcessId function retrieves the identifier of the thread
        // that created the specified window and, optionally, the identifier of the
        // process that created the window.
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern Int32 GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        private Dictionary<string, string> configLocations = new Dictionary<string, string>();
        private profile profile;
        private XmlTextReader reader = null;
        globalKeyboardHook gkh = new globalKeyboardHook();
        static int spotify;

        // Returns the name of the process owning the foreground window.
        private static string GetForegroundProcessName()
        {
            IntPtr hwnd = GetForegroundWindow();

            // The foreground window can be NULL in certain circumstances, 
            // such as when a window is losing activation.
            if (hwnd == null)
                return "Unknown";

            uint pid;
            GetWindowThreadProcessId(hwnd, out pid);

            foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
            {
                if (p.Id == pid)
                    return p.ProcessName;
            }

            return "Unknown";
        }

        private static int getPid(String input)
        {
            Process[] remoteAll = Process.GetProcessesByName(input);
            for (int i = 0; i < remoteAll.Length; i++)
            {
                float? teste = AudioManager.GetApplicationVolume(remoteAll[i].Id);
                if (teste != null)
                {
                    return remoteAll[i].Id;
                }
            }
            return 0;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            spotify = getPid("spotify");

            string activeProfile = System.IO.Directory.GetCurrentDirectory() + "/activeProfile.xml";
            string startupPath = System.IO.Directory.GetCurrentDirectory() + "/Profiles";

            if (!Directory.Exists(startupPath)){
                DirectoryInfo di = Directory.CreateDirectory(startupPath);
            }

            if (File.Exists(activeProfile)){
                loadConfig(activeProfile);
            }
            else{
                createNewConfig();
            }

            string[] filePaths = Directory.GetFiles(startupPath, "*.xml");

            foreach (String file in filePaths){
                String[] aux = file.Split('\\');
                String key = aux[aux.Length - 1].Split('.')[0];
                String value = file;

                configLocations.Add(key, value);
                selectProfile.Items.Add(key);
            }

            //Set up que keys
            gkh.HookedKeys.Add(Keys.F13);
            gkh.HookedKeys.Add(Keys.F14);
            gkh.HookedKeys.Add(Keys.F15);
            gkh.HookedKeys.Add(Keys.F16);
            gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);
            gkh.KeyUp += new KeyEventHandler(gkh_KeyUp);
        }

        void gkh_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        void gkh_KeyDown(object sender, KeyEventArgs e)
        {
            string buttonPressed = e.KeyCode.ToString();
            switch (buttonPressed)
            {
                case "F13":
                    Boolean newAudioState = AudioManager.GetMasterVolumeMute() ? false : true;
                    AudioManager.SetMasterVolumeMute(newAudioState);
                    break;
                case "F14":
                    AudioManager.SetApplicationVolume(spotify, 50);
                    break;
                case "F15":
                    Console.WriteLine("F15");
                    break;
                default:
                    break;
            }
            e.Handled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedEmployee = (string)selectProfile.SelectedItem;
            profile = new profile(selectedEmployee);

            profile.saveActiveProfileConfig();
        }

        private void loadConfig(string activeProfileFilePath)
        {
            try
            {
                //Load the reader with the XML file.
                reader = new XmlTextReader(activeProfileFilePath);
                XmlDocument xml = new XmlDocument();
                xml.Load(activeProfileFilePath);
                string id = xml.SelectSingleNode("profile/title").InnerText;
                selectProfile.SelectedText = id;


                //f14.Image = new Bitmap(@"C:\Users\TMind\source\repos\DIYStreamDeck\DIYStreamDeck\bin\Debug\s.jpg");
                //f14.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
                //button1.Location = new System.Drawing.Point(13, 100);

            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        public void createNewConfig()
        {
            XmlTextWriter writer = new XmlTextWriter("activeProfile.xml", System.Text.Encoding.UTF8);

            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("profile");
            writer.WriteElementString("title", "");
            writer.WriteEndElement();
            writer.Flush();
            writer.Close();
        }

        private void newConfig_Click(object sender, EventArgs e)
        {
            Console.WriteLine("New");
        }

        private void f13_Click(object sender, EventArgs e)
        {
            Console.WriteLine("F13 - option");
            if (AudioManager.GetMasterVolumeMute())
            {
                AudioManager.SetMasterVolumeMute(false);
            }
            else
            {
                AudioManager.SetMasterVolumeMute(true);
            }
                
                

        }

        private void f14_Click(object sender, EventArgs e)
        {
            Console.WriteLine("F14 - option");
        }

        private void f15_Click(object sender, EventArgs e)
        {
            Console.WriteLine("F15 - option");
        }
    }
}
