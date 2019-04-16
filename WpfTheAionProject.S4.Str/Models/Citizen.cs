using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTheAionProject.Models
{
    // todo 09 - implement the ISpeak in the Citizen class
    //public class Citizen : Npc, ISpeak
    public class Citizen : Npc
    {
        Random r = new Random();
        // todo 09a - implement the ISpeak interface in Citizen class
        //public List<string> Messages { get; set; }

        protected override string InformationText()
        {
            return $"{Name} - {Description}";
        }

        public Citizen()
        {

        }

        public Citizen(int id, string name, RaceType race, string description, List<string> messages)
            : base(id, name, race, description)
        {
            // todo 09b - implement the ISpeak interface in Citizen class
            //Messages = messages;
        }

        // todo 09c - implement the ISpeak interface in Citizen class
        /// <summary>
        /// generate a message or use default
        /// </summary>
        /// <returns>message text</returns>
        //public string Speak()
        //{
        //    if (this.Messages != null)
        //    {
        //        return GetMessage();
        //    }
        //    else
        //    {
        //        return "";
        //    }
        //}

        // todo 09d - implement the ISpeak interface in Citizen class
        /// <summary>
        /// randomly select a message from the list of messages
        /// </summary>
        /// <returns>message text</returns>
        //private string GetMessage()
        //{
        //    int messageIndex = r.Next(0, Messages.Count());
        //    return Messages[messageIndex];
        //}
    }
}
