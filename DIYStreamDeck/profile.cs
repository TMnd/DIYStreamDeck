using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DIYStreamDeck
{
    class profile
    {
        private string profile_title;

        public profile(string profile_title)
        {
            this.profile_title = profile_title;
        }

        public string get_title() { return this.profile_title; }
        public void set_title(string input_title) { this.profile_title = input_title; }

        public void saveActiveProfileConfig()
        {
            XmlTextWriter writer = new XmlTextWriter("activeProfile.xml", System.Text.Encoding.UTF8);

            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("profile");
            writer.WriteElementString("title", this.profile_title);
            writer.WriteEndElement();
            writer.Flush();
            writer.Close();
        }
        
    }
}
