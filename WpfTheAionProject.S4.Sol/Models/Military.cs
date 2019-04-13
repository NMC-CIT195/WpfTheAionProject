using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTheAionProject.Models
{
    public class Military : Npc, ISpeak, IBattle
    {
        private const int DEFENDER_DAMAGE_ADJUSTMENT = 10;
        private const int MAXIMUM_RETREAT_DAMAGE = 10;

        public List<string> Messages { get; set; }
        public int SkillLevel { get; set; }
        public List<Weapon> Weapons { get; set; }
        public Weapon CurrentWeapon { get; set; }

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
            string description,
            List<string> messages,
            int skillLevel,
            List<Weapon> weapons,
            Weapon currentWeapon)
            : base(id, name, race, description)
        {
            Messages = messages;
            SkillLevel = skillLevel;
            Weapons = weapons;
            CurrentWeapon = currentWeapon;
        }

        /// <summary>
        /// generate a message or use default
        /// </summary>
        /// <returns>message text</returns>
        public string Speak()
        {
            if (this.Messages != null)
            {
                return GetMessage();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// randomly select a message from the list of messages
        /// </summary>
        /// <returns>message text</returns>
        private string GetMessage()
        {
            Random r = new Random();
            int messageIndex = r.Next(0, Messages.Count());
            return Messages[messageIndex];
        }

        /// <summary>
        /// return a percent damage number [0 - 100] based on the NPCs weapon and skill level
        /// </summary>
        /// <returns>damage number 0-100</returns>
        public int Attack(int skillLevel)
        {
            return CalculateMaxPercentDamage(skillLevel);
        }

        /// <summary>
        /// return a damage number [0 - 100] based on the NPCs weapon and skill level
        /// adjusted to deliver more damage when first attacked
        /// </summary>
        /// <returns>damage number 0-100</returns>
        public int Defend(int skillLevel)
        {
            int adjustedPercentDamage = CalculateMaxPercentDamage(skillLevel) + DEFENDER_DAMAGE_ADJUSTMENT;

            if (adjustedPercentDamage <= 100)
            {
                return adjustedPercentDamage;
            }
            else
            {
                return 100;
            }
        }

        /// <summary>
        /// return a percent damage number [0 - 100] based on the NPCs skill level
        /// </summary>
        /// <returns>damage number 0-100</returns>
        public int Retreat(int skillLevel)
        {
            return Convert.ToInt32(MAXIMUM_RETREAT_DAMAGE / skillLevel);
        }

        /// <summary>
        /// calculate the maximum possible percent damage based on weapon and skill level
        /// </summary>
        /// <param name="skillLevel">maximum possible percent damage</param>
        /// <returns></returns>
        private int CalculateMaxPercentDamage(int skillLevel)
        {
            CurrentWeapon = GetRandomWeapon();

            if (GetRandomWeapon() != null)
            {
                Random random = new Random();

                //
                // minimum and maximum damage values range: 0 - 10
                // skill level values range: 0 - 10
                // multiplying converts to percentage of damage
                //
                return Convert.ToInt32(random.Next(CurrentWeapon.MinimumDamage, CurrentWeapon.MaximumDamage) * skillLevel);
            }
            else
            {
                //
                // attacking with no weapon results in 100% damage
                //
                return 100;
            }
        }

        /// <summary>
        /// get a random weapon from the NPCs list of weapons
        /// </summary>
        /// <returns>weapon to battle with</returns>
        private Weapon GetRandomWeapon()
        {
            Random random = new Random();
            Weapon battleWeapon = null;

            if (Weapons.Count != 0)
            {
                int index = random.Next(Weapons.Count);
                battleWeapon = Weapons[index];
            }

            return battleWeapon;
        }
    }
}
