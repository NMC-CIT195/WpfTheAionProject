using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTheAionProject.Models
{
    // todo 10 - implement the IBattle interface in Military class
    //public class Military : Npc, ISpeak, IBattle
    public class Military : Npc
    {
        Random r = new Random();

        // todo 10a - implement the IBattle interface in Military class
        //private const int DEFENDER_DAMAGE_ADJUSTMENT = 10;
        //private const int MAXIMUM_RETREAT_DAMAGE = 10;

        // todo 08a - implement the ISpeak interface in the Military class
        //public List<string> Messages { get; set; }

        // todo 10b - implement the IBattle interface in Military class
        //public int SkillLevel { get; set; }
        //public BattleModeName BattleMode { get; set; }
        //public Weapon CurrentWeapon { get; set; }

        protected override string InformationText()
        {
            return $"{Name} - {Description}";
        }

        public Military()
        {

        }

        public Military(
            int id,
            string name,
            RaceType race,
            string description
            // todo 08b - implement the ISpeak interface in the Military class
            //List<string> messages,

            // todo 10c - implement the IBattle interface in Military class
            //int skillLevel,
            //Weapon currentWeapon
            )
            : base(id, name, race, description)
        {
            // todo 08c - implement the ISpeak interface in the Military class
            //Messages = messages;
            //SkillLevel = skillLevel;
            //CurrentWeapon = currentWeapon;
        }

        // todo 08d - implement the ISpeak interface in the Military class
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

        // todo 08e - implement the ISpeak interface in Military classes
        /// <summary>
        /// randomly select a message from the list of messages
        /// </summary>
        /// <returns>message text</returns>
        //private string GetMessage()
        //{
        //    int messageIndex = r.Next(0, Messages.Count());
        //    return Messages[messageIndex];
        //}

        #region BATTLE METHODS

        // todo 10d - implement the IBattle interface in Military class
        /// <summary>
        /// return hit points [0 - 100] based on the NPCs weapon and skill level
        /// </summary>
        /// <returns>hit points 0-100</returns>
        //public int Attack()
        //{
        //    int hitPoints = random.Next(CurrentWeapon.MinimumDamage, CurrentWeapon.MaximumDamage) * SkillLevel;

        //    if (hitPoints <= 100)
        //    {
        //        return hitPoints;
        //    }
        //    else
        //    {
        //        return 100;
        //    }
        //}

        // todo 10e - implement the IBattle interface in Military class
        /// <summary>
        /// return hit points [0 - 100] based on the NPCs weapon and skill level
        /// adjusted to deliver more damage when first attacked
        /// </summary>
        /// <returns>hit points 0-100</returns>
        //public int Defend()
        //{
        //    int hitPoints = (random.Next(CurrentWeapon.MinimumDamage, CurrentWeapon.MaximumDamage) * SkillLevel) - DEFENDER_DAMAGE_ADJUSTMENT;

        //    if (hitPoints >= 0 && hitPoints <= 100)
        //    {
        //        return hitPoints;
        //    }
        //    else if (hitPoints > 100)
        //    {
        //        return 100;
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}

        // todo 10f - implement the IBattle interface in Military class
        /// <summary>
        /// return hit points [0 - 100] based on the NPCs skill level
        /// </summary>
        /// <returns>hit points 0-100</returns>
        //public int Retreat()
        //{
        //    int hitPoints = SkillLevel * MAXIMUM_RETREAT_DAMAGE;

        //    if (hitPoints <= 100)
        //    {
        //        return hitPoints;
        //    }
        //    else
        //    {
        //        return 100;
        //    }
        //}

        #endregion

    }
}
