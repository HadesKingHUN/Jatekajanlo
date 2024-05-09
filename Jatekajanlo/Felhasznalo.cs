using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jatekajanlo
{
    public class Felhasznalo
{
    public string Name { get; set; }
    public string PreferredPlatform { get; set; }
    public string PreferredType { get; set; }

    public Felhasznalo(string name)
    {
        Name = name;
    }
}
}
