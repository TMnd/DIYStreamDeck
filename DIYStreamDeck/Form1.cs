using System;
using System.Collections;
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
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern Int32 GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        [System.Runtime.InteropServices.DllImport("nircmd.dll")]
        public static extern bool DoNirCmd(string NirCmdStr);

        private Dictionary<string, string> configLocations = new Dictionary<string, string>();
        profile profile;
        private XmlTextReader reader = null;
        globalKeyboardHook gkh = new globalKeyboardHook();
        int program;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string activeProfile = System.IO.Directory.GetCurrentDirectory() + "/activeProfile.xml";
            string startupPath = System.IO.Directory.GetCurrentDirectory() + "/Profiles";

            if (!Directory.Exists(startupPath)){
                DirectoryInfo di = Directory.CreateDirectory(startupPath);
            }

            if (!File.Exists(activeProfile)){
                createNewConfig();
            }
            loadConfig(activeProfile);

            string[] filePaths = Directory.GetFiles(startupPath, "*.xml");

            foreach (String file in filePaths){
                String[] aux = file.Split('\\');
                String key = aux[aux.Length - 1].Split('.')[0];
                String value = file;

                configLocations.Add(key, value);
                selectProfile.Items.Add(key);
            }

            for(int i = 1; i <= 9; i++)
            {
                refreshButtonData("Button" + i);
            }

            //Set up que keys
            gkh.HookedKeys.Add(Keys.F13);
            gkh.HookedKeys.Add(Keys.F14);
            gkh.HookedKeys.Add(Keys.F15);
            gkh.HookedKeys.Add(Keys.F16);
            gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);
            gkh.KeyUp += new KeyEventHandler(gkh_KeyUp);
        }

        public static void RunCmd(string command)
        {
            DoNirCmd(command);
        }

        public static void PressKey(Keys key, bool up)
        {
            const int KEYEVENTF_EXTENDEDKEY = 0x1;
            const int KEYEVENTF_KEYUP = 0x2;
            if (up)
            {
                keybd_event((byte)key, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr)0);
            }
            else
            {
                keybd_event((byte)key, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
            }
        }

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

        void gkh_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        void gkh_KeyDown(object sender, KeyEventArgs e)
        {
            string buttonPressed = e.KeyCode.ToString();

            ArrayList data;

            switch (buttonPressed)
            {
                case "F13": //Button1
                    data = profile.getButtonData("Button1");

                    switch (data[0])
                    {
                        case "Program":
                            Process.Start(data[1].ToString());
                            break;
                        case "Windows":
                            if (data[1].Equals(""))
                                AudioManager.ToggleMasterVolumeMute();
                            else
                            {
                                //Drop a error when is used sometimes in a row.
                                program = getPid(data[1].ToString().Split('\\')[1]);
                                string status = AudioManager.GetApplicationMute(program).ToString();
                                Console.WriteLine(status);
                                if (status.Equals("False"))
                                    AudioManager.SetApplicationMute(program, true);
                                else
                                    AudioManager.SetApplicationMute(program, false);
                            }
                            break;
                        default:
                            PressKey(Keys.F13, false);
                            PressKey(Keys.F13, true);
                            break;
                    }
                    break;
                case "F14": //Button2
                    data = profile.getButtonData("Button2");

                    switch (data[0])
                    {
                        case "Program":
                            Process.Start(data[1].ToString());
                            break;
                        case "Windows":
                            if (data[1].Equals(""))
                                AudioManager.ToggleMasterVolumeMute();
                            else
                            {
                                //Drop a error when is used sometimes in a row.
                                program = getPid(data[1].ToString().Split('\\')[1]);
                                string status = AudioManager.GetApplicationMute(program).ToString();
                                Console.WriteLine(status);
                                if (status.Equals("False"))
                                    AudioManager.SetApplicationMute(program, true);
                                else
                                    AudioManager.SetApplicationMute(program, false);
                            }
                            break;
                        default:
                            PressKey(Keys.F14, false);
                            PressKey(Keys.F14, true);
                            break;
                    }
                    break;
                case "F15": //Button3
                    data = profile.getButtonData("Button3");

                    switch (data[0])
                    {
                        case "Program":
                            Process.Start(data[1].ToString());
                            break;
                        case "Windows":
                            if (data[1].Equals(""))
                                AudioManager.ToggleMasterVolumeMute();
                            else
                            {
                                //Drop a error when is used sometimes in a row.
                                program = getPid(data[1].ToString().Split('\\')[1]);
                                string status = AudioManager.GetApplicationMute(program).ToString();
                                Console.WriteLine(status);
                                if (status.Equals("False"))
                                    AudioManager.SetApplicationMute(program, true);
                                else
                                    AudioManager.SetApplicationMute(program, false);
                            }
                            break;
                        default:
                            PressKey(Keys.F15, false);
                            PressKey(Keys.F15, true);
                            break;
                    }
                    break;
                default:
                    break;
            }
            e.Handled = true;
        }

        private void loadConfig(string activeProfileFilePath)
        {
            try
            {
                //Load the reader with the XML file.
                reader = new XmlTextReader(activeProfileFilePath);
                XmlDocument xml = new XmlDocument();
                xml.Load(activeProfileFilePath);
                string title_name = xml.SelectSingleNode("Profile/Title").InnerText;
                selectProfile.SelectedText = title_name; 
                profile = new profile(title_name);

                for (int i = 1; i <= 9; i++)
                {
                    ArrayList SubData = new ArrayList();

                    string bottomKey = "Button" + i;
                    string getXMLType = xml.SelectSingleNode("Profile/" + bottomKey + "/Type").InnerText;
                    string getXMLProgram = xml.SelectSingleNode("Profile/" + bottomKey + "/Program").InnerText;

                    SubData.Add(getXMLType);
                    SubData.Add(getXMLProgram);

                    profile.setButtonData(bottomKey, SubData);
                }
                
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

            writer.WriteStartDocument();
            writer.WriteWhitespace("\n  ");
            writer.WriteStartElement("Profile");//START PARENT
            writer.Indentation = 4;
            writer.IndentChar = Convert.ToChar(" ");
            writer.Formatting = Formatting.Indented;

            writer.WriteElementString("Title", "");

            for (int i = 1; i <= 9; i++)
            {
                string tagName = "Button" + i;
                writer.WriteStartElement(tagName);// START CHILD 
                writer.WriteElementString("Type", "Default");
                //writer.WriteElementString("Image", "");
                writer.WriteElementString("Program", "");
                writer.WriteEndElement();//END CHILD
            }

            writer.WriteEndElement();//END PARENT
            writer.WriteEndDocument();

            writer.Flush();
            writer.Close();
        }

        public void refreshButtonData(string buttonid)
        {
            ArrayList a = profile.getButtonData(buttonid);
            string programName="";

            if (!a[1].Equals(""))
            {
                string[] aux = a[1].ToString().Split('\\');
                programName = aux[aux.Length - 1].Split('.')[0];
                Console.WriteLine(programName);
            }

            switch (buttonid)
            {
                case "Button1":
                    if (a[0].Equals("Program"))
                        f13.Text = programName;
                    else if (a[0].Equals("Default"))
                        f13.Text = "F13";
                    else if (a[0].Equals("Windows"))
                        if (programName.Equals(""))
                            f13.Text = "Mute All";
                        else
                            f13.Text = "Mute " + programName;
                    break;
                case "Button2":
                    if (a[0].Equals("Program"))
                        f14.Text = programName;
                    else if (a[0].Equals("Default"))
                        f14.Text = "F14";
                    else if (a[0].Equals("Windows"))
                        if (programName.Equals(""))
                            f14.Text = "Mute All";
                        else
                            f14.Text = "Mute " + programName;
                    break;
                case "Button3":
                    if (a[0].Equals("Program"))
                        f15.Text = programName;
                    else if (a[0].Equals("Default"))
                        f15.Text = "F15";
                    else if (a[0].Equals("Windows"))
                        if (programName.Equals(""))
                            f15.Text = "Mute All";
                        else
                            f15.Text = "Mute " + programName;
                    break;
                default:
                    break;
            }
        }

        //Form elements events
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProfileTitle = (string)selectProfile.SelectedItem;

            profile.set_title(selectedProfileTitle);

            profile.saveActiveProfileConfig();
        } 

        private void newConfig_Click(object sender, EventArgs e)
        {
            profile.set_title(selectProfile.Text);
            profile.saveActiveProfileConfig();
        }

        private void f13_Click(object sender, EventArgs e)
        {
            string button = "Button1";
            Form2 f2 = new Form2(profile, button); //this is the change, code for redirect  
            f2.ShowDialog();

            //When the form2 closes
            refreshButtonData(button);
        }

        private void f14_Click(object sender, EventArgs e)
        {
            string button = "Button2";
            Form2 f2 = new Form2(profile, button); //this is the change, code for redirect  
            f2.ShowDialog();

            //When the form2 closes
            refreshButtonData(button);
        }

        private void f15_Click(object sender, EventArgs e)
        {
            string button = "Button3";
            Form2 f2 = new Form2(profile, button); //this is the change, code for redirect  
            f2.ShowDialog();

            //When the form2 closes
            refreshButtonData(button);
        }
    }
}
