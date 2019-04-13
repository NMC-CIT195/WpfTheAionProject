using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTheAionProject.Models
{
    public interface IBattle
    {
        int SkillLevel { get; set; }
        List<Weapon> Weapons { get; set; }

        int Attack(int skillLevel);
        int Defend(int skillLevel);
        int Retreat(int skillLevel);
    }
}
