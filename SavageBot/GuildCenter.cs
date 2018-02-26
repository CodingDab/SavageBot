using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace SavageBot
{
    class GuildCenter
    {
        public static List<GuildData> Guilds = new List<GuildData>();
        public static GuildData GetGuild(ulong id)
        {
            foreach(var x in Guilds)
            {
                if (x.Id == id) return x;
            }
            return new GuildData(0,""); // 0 id means that the guild was not found
        }
        public static void SaveGuilds()
        {
            if (Guilds.Count == 0) return;
            XmlDocument settings = new XmlDocument();

            XmlDeclaration declaration = settings.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = settings.DocumentElement;
            settings.InsertBefore(declaration, root);
            
            XmlElement guilds = settings.CreateElement(string.Empty,"guilds",string.Empty); // holds all guilds

            XmlElement[] guildArr = new XmlElement[Guilds.Count];
            for(int i = 0; i < Guilds.Count; i++)
            {
                guildArr[i] = settings.CreateElement(string.Empty,"Guild"+(i==0?null:i.ToString()),string.Empty);

                XmlElement name = settings.CreateElement(string.Empty, "Name", string.Empty);
                XmlNode nameText = settings.CreateTextNode(Guilds.ElementAt(i).Name);
                name.AppendChild(nameText);

                XmlElement id = settings.CreateElement(string.Empty, "Id", string.Empty);
                XmlNode idText = settings.CreateTextNode(Guilds.ElementAt(i).Id.ToString());
                id.AppendChild(idText);

                XmlElement defaultChannel = settings.CreateElement(string.Empty, "DefaultChannel", string.Empty);
                XmlNode defaultChannelText = settings.CreateTextNode(Guilds.ElementAt(i).defaultChannel.ToString());
                defaultChannel.AppendChild(defaultChannelText);


                guildArr[i].AppendChild(name);
                guildArr[i].AppendChild(id);
                guildArr[i].AppendChild(defaultChannel);
            }

            foreach(var g in guildArr) guilds.AppendChild(g);

            settings.AppendChild(guilds);
            settings.Save("../../guild_settings.xml");
        }
        public static void LoadGuilds()
        {
            if (File.ReadAllText("../../guild_settings.xml") == "") return;
            XmlDocument settings = new XmlDocument();
            settings.Load("../../guild_settings.xml");
            var guilds = settings.FirstChild;

            for (int i = 0; i < guilds.ChildNodes.Count; i++)
            {
                Guilds.Add(new GuildData(
                    Convert.ToUInt64(guilds.SelectSingleNode("Guild" + (i == 0 ? null : i.ToString())).SelectSingleNode("Name").Value),
                    guilds.SelectSingleNode("Guild" + (i == 0 ? null : i.ToString())).SelectSingleNode("Name").Value,
                    Convert.ToUInt64(guilds.SelectSingleNode("Guild" + (i == 0 ? null : i.ToString())).SelectSingleNode("DefaultChannel").Value)
                ));
            }
        }
    }
}
