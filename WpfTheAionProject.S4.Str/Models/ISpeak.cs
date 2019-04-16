using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTheAionProject.Models
{
    // todo 06 - create an ISpeak interface
    interface ISpeak
    {
        List<string> Messages { get; set; }

        string Speak();
    }
}
