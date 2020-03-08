using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DIYStreamDeck
{
    public class profile
    {
        private string profile_title;

        ArrayList SubData = new ArrayList();
        private Dictionary<string, ArrayList> ButtonData = new Dictionary<string, ArrayList>();
        

        public profile(string profile_title)
        {
            this.profile_title = profile_title;
        }

        public string get_title() { return profile_title;  }
        public void set_title(string input_title) { this.profile_title = input_title; }

        public void saveActiveProfileConfig()
        {
            XmlTextWriter writer = new XmlTextWriter("activeProfile.xml", System.Text.Encoding.UTF8);

            writer.WriteStartDocument();
            writer.WriteWhitespace("\n  ");
            writer.WriteStartElement("Profile");//START PARENT
            writer.Indentation = 4;
            writer.IndentChar = Convert.ToChar(" ");
            writer.Formatting = Formatting.Indented;

            writer.WriteElementString("Title", this.profile_title);

            for (int i = 1; i <= 9; i++)
            {
                string tagName = "Button" + i;
                ArrayList a = new ArrayList();
                a = getButtonData(tagName);
                writer.WriteStartElement(tagName);// START CHILD 
                writer.WriteElementString("Type", a[0].ToString());
                writer.WriteElementString("Program", a[1].ToString());
                writer.WriteEndElement();//END CHILD
            }

            writer.WriteEndElement();//END PARENT
            writer.WriteEndDocument();

            writer.Flush();
            writer.Close();
        }
        
        public void setButtonData(string key, ArrayList subData)
        {
            if(ButtonData.ContainsKey(key))
                ButtonData[key] = subData;
            else
                ButtonData.Add(key, subData);
        }

        public ArrayList getButtonData(string key)
        {
            return ButtonData[key];
        }

        public Dictionary<string, ArrayList> getAllButtonData()
        {
            return ButtonData;
        }

    }
}
