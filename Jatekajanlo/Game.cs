using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jatekajanlo
{
    public class Game
{
    public string Title { get; set; }
    public string Platform { get; set; }
    public string Type { get; set; }

    public Game(string title, string platform, string type)
    {
        Title = title;
        Platform = platform;
        Type = type;
    }
}
}
