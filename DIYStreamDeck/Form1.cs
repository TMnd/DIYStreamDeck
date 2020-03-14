using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            gkh.HookedKeys.Add(Keys.F17);
            gkh.HookedKeys.Add(Keys.F18);
            gkh.HookedKeys.Add(Keys.F19);
            gkh.HookedKeys.Add(Keys.F20);
            gkh.HookedKeys.Add(Keys.F21);
            gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);
            gkh.KeyUp += new KeyEventHandler(gkh_KeyUp);
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
            string nomeaplicacao = "";

            if (input.Equals("current"))
            {
                nomeaplicacao = GetForegroundProcessName();
                input = nomeaplicacao;
            }

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

            switch (buttonPressed)
            {
                case "F13": //Button1
                    buttonCommands("Button1");
                    break;
                case "F14": //Button2
                    buttonCommands("Button2");
                    break;
                case "F15": //Button3
                    buttonCommands("Button3");
                    break;
                case "F16": //Button3
                    buttonCommands("Button4");
                    break;
                case "F17": //Button3
                    buttonCommands("Button5");
                    break;
                case "F18": //Button3
                    buttonCommands("Button6");
                    break;
                case "F19": //Button3
                    buttonCommands("Button7");
                    break;
                case "F20": //Button3
                    buttonCommands("Button8");
                    break;
                case "F21": //Button3
                    buttonCommands("Button9");
                    break;
                default:
                    break;
            }
            e.Handled = true;
        }

        private void buttonCommands(string buttonId)
        {
            ArrayList data = profile.getButtonData(buttonId);

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
                        //Console.WriteLine(status);
                        if (status.Equals("False"))
                            AudioManager.SetApplicationMute(program, true);
                        else
                            AudioManager.SetApplicationMute(program, false);
                    }
                    break;
                case "nircmd":
                    NirCmdCall.DoNirCmd("setdefaultsounddevice \"Headset\"");
                    break;
                default:
                    PressKey(Keys.F13, false);
                    PressKey(Keys.F13, true);
                    break;
            }
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
                Console.WriteLine(title_name);
                selectProfile.Text = title_name;
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
                case "Button4":
                    if (a[0].Equals("Program"))
                        f16.Text = programName;
                    else if (a[0].Equals("Default"))
                        f16.Text = "F16";
                    else if (a[0].Equals("Windows"))
                        if (programName.Equals(""))
                            f16.Text = "Mute All";
                        else
                            f16.Text = "Mute " + programName;
                    break;
                case "Button5":
                    if (a[0].Equals("Program"))
                        f17.Text = programName;
                    else if (a[0].Equals("Default"))
                        f17.Text = "F17";
                    else if (a[0].Equals("Windows"))
                        if (programName.Equals(""))
                            f17.Text = "Mute All";
                        else
                            f17.Text = "Mute " + programName;
                    break;
                case "Button6":
                    if (a[0].Equals("Program"))
                        f18.Text = programName;
                    else if (a[0].Equals("Default"))
                        f18.Text = "F18";
                    else if (a[0].Equals("Windows"))
                        if (programName.Equals(""))
                            f18.Text = "Mute All";
                        else
                            f18.Text = "Mute " + programName;
                    break;
                case "Button7":
                    if (a[0].Equals("Program"))
                        f19.Text = programName;
                    else if (a[0].Equals("Default"))
                        f19.Text = "F19";
                    else if (a[0].Equals("Windows"))
                        if (programName.Equals(""))
                            f19.Text = "Mute All";
                        else
                            f19.Text = "Mute " + programName;
                    break;
                case "Button8":
                    if (a[0].Equals("Program"))
                        f20.Text = programName;
                    else if (a[0].Equals("Default"))
                        f20.Text = "F20";
                    else if (a[0].Equals("Windows"))
                        if (programName.Equals(""))
                            f20.Text = "Mute All";
                        else
                            f20.Text = "Mute " + programName;
                    break;
                case "Button9":
                    if (a[0].Equals("Program"))
                        f21.Text = programName;
                    else if (a[0].Equals("Default"))
                        f21.Text = "F21";
                    else if (a[0].Equals("Windows"))
                        if (programName.Equals(""))
                            f21.Text = "Mute All";
                        else
                            f21.Text = "Mute " + programName;
                    break;
                default:
                    break;
            }
        }

        //Form elements events
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProfileTitle = (string)selectProfile.SelectedItem;

           // profile.set_title(selectedProfileTitle);


            //Console.WriteLine(selectProfile.Text);

            string newFile = System.IO.Directory.GetCurrentDirectory() + "/Profiles/" + selectProfile.Text + ".xml";

            loadConfig(newFile);

            profile.saveActiveProfileConfig();

            for (int i = 1; i <= 9; i++)
            {
                refreshButtonData("Button" + i);
            }
        } 

        private void newConfig_Click(object sender, EventArgs e)
        {
            if (selectProfile.Text.Length == 0) return;

            profile.set_title(selectProfile.Text);
            profile.saveActiveProfileConfig();

            string sourceFile = System.IO.Directory.GetCurrentDirectory() + "/activeProfile.xml";
            string newFile = System.IO.Directory.GetCurrentDirectory() + "/Profiles/" + selectProfile.Text + ".xml";

            File.Copy(sourceFile, newFile, true);
        }

        private void f13_Click(object sender, EventArgs e)
        {
            setButtonsClick("Button1");
        }

        private void f14_Click(object sender, EventArgs e)
        {
            setButtonsClick("Button2");
        }

        private void f15_Click(object sender, EventArgs e)
        {
            setButtonsClick("Button3");
        }

        private void f16_Click(object sender, EventArgs e)
        {
            setButtonsClick("Button4");
        }

        private void f17_Click(object sender, EventArgs e)
        {
            setButtonsClick("Button5");
        }

        private void f18_Click(object sender, EventArgs e)
        {
            setButtonsClick("Button6");
        }

        private void f19_Click(object sender, EventArgs e)
        {
            setButtonsClick("Button7");
        }

        private void f20_Click(object sender, EventArgs e)
        {
            setButtonsClick("Button8");
        }

        private void f21_Click(object sender, EventArgs e)
        {
            setButtonsClick("Button9");
        }

        private void setButtonsClick(string buttonId)
        {
            Form2 f2 = new Form2(profile, buttonId); //this is the change, code for redirect  
            f2.ShowDialog();

            //When the form2 closes
            refreshButtonData(buttonId);
        }
    }


    public class NirCmdCall
    {
        [System.Runtime.InteropServices.DllImport("nircmd.dll")]
        public static extern bool DoNirCmd(String NirCmdStr);
    }
}