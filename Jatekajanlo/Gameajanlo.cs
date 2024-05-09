using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jatekajanlo
{
    public class Gameajanlo
    {
        public List<Game> games;

        public Gameajanlo()
        {
            games = new List<Game>
        {
            new Game("Halo Infinite", "xbox", "akció"),
            new Game("Sea of Theves", "xbox", "Kaland"),
            new Game("Gears 5","xbox","akció"),
            new Game("Forza 4","xbox","sport"),
            new Game("Forza 5","xbox","sport"),
            new Game("State of Decay 2","xbox","akció"),
            new Game("Ori and the Will of Wisps","xbox","kaland"),
            new Game("Grounded","xbox","túlélő"),
            new Game("Fable","xbox","Kaland"),
            new Game("Everwind","xbox","kaland"),

            new Game("God of War", "ps", "akció"),
            new Game("The Last of Us Part II","ps","kaland"),
            new Game("Spider-Man: Miles Morales","ps","kaland"),
            new Game("Ratchet& Clank: Rift Apart","ps","kaland"),
            new Game("Horizon Forbidden West","ps","akció"),
            new Game("Grand Turismo 7","ps","sport"),
            new Game("Days Gone","ps","túlélő"),


            new Game("Forest 2","pc","túlélő"),
            new Game("Counter-Strike: Global Offensive (CS:GO)","pc","akció"),
            new Game("Fortnite","pc","akció"),
            new Game("The Witcher 3: Wild Hunt","pc","kaland"),
            new Game("Grand Theft Auto V","pc","Akció"),
            new Game("Hades","pc","akció"),
            new Game("Rocket League","pc","sport"),
            new Game("EA FC 24","pc","sport"),


        };
        }
        public Game KovetkezoAjanlat(string platform, string type)
        {
            return games.FirstOrDefault(g => g.Platform == platform && g.Type == type);
        }
        public Game Ajanlottjatek(string platform, string type)
        {
            Random rnd = new Random();
            var filteredGames = games.Where(g => g.Platform == platform && g.Type == type).ToList();
            if (filteredGames.Count == 0) return null;
            int index = rnd.Next(filteredGames.Count);
            return filteredGames[index];
        }

        internal Game KovetkezoAjanlat()
        {
            throw new NotImplementedException();
        }
    }
}