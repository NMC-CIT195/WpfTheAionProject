using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTheAionProject.Models;

namespace WpfTheAionProject.Models
{
    public interface IBattle
    {
        int SkillLevel { get; set; }
        Weapon CurrentWeapon { get; set; }
        BattleModeName BattleMode { get; set; }

        /// <summary>
        /// methods to return hit point values (0 - 100) for each battle mode
        /// </summary>
        /// <returns>hit point values (0 - 100)</returns>
        int Attack();
        int Defend();
        int Retreat();
    }
}
