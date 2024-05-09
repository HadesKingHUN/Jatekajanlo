using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jatekajanlo
{
    public class Gameajanlo
    {
        public List<Game> games;
        private List<Game> recommendedGames = new List<Game>();

        public Gameajanlo()
        {
            games = new List<Game>
        {
                // Xbox játékok
                new XboxGame("Halo Infinite", "akció"),
                new XboxGame("Sea of Thieves", "Kaland"),
                new XboxGame("Gears 5", "akció"),
                new XboxGame("Forza 4", "sport"),
                new XboxGame("Forza 5", "sport"),
                new XboxGame("State of Decay 2", "akció"),
                new XboxGame("Ori and the Will of Wisps", "kaland"),
                new XboxGame("Grounded", "túlélő"),
                new XboxGame("Fable", "Kaland"),
                new XboxGame("Everwind", "kaland"),

               // PS játékok
                new PsGame("God of War", "akció"),
                new PsGame("The Last of Us Part II", "kaland"),
                new PsGame("Spider-Man: Miles Morales", "kaland"),
                new PsGame("Ratchet & Clank: Rift Apart", "kaland"),
                new PsGame("Horizon Forbidden West", "akció"),
                new PsGame("Grand Turismo 7", "sport"),
                new PsGame("Days Gone", "túlélő"),

                // PC játékok
                new PcGame("Forest 2", "túlélő"),
                new PcGame("Counter-Strike: Global Offensive (CS:GO)", "akció"),
                new PcGame("Fortnite", "akció"),
                new PcGame("The Witcher 3: Wild Hunt", "kaland"),
                new PcGame("Grand Theft Auto V", "Akció"),
                new PcGame("Hades", "akció"),
                new PcGame("Rocket League", "sport"),
                new PcGame("EA FC 24", "sport"),


        };
        }
        //public Game KovetkezoAjanlat(string platform, string type)
        //{
        //return games.FirstOrDefault(g => g.Platform == platform && g.Type == type);
        //}
        public Game Ajanlottjatek(string platform, string type)
        {
            Random rnd = new Random();
            // Kizárjuk azokat a játékokat, amelyek már ajánlva voltak, és csak a megfelelő platformú játékokat vesszük figyelembe 
            var filteredGames = games.Where(g => g.Platform == platform && g.Type == type && !recommendedGames.Contains(g)).ToList();

            // Ellenőrizzük, hogy a játék típusa megfelel-e a keresett platformnak
            filteredGames = filteredGames.Where(g =>
            {
                switch (platform.ToLower())
                {
                    case "pc":
                        return g is PcGame;
                    case "xbox":
                        return g is XboxGame;
                    case "ps":
                        return g is PsGame;
                    default:
                        return false;
                }
            }).ToList();

            if (filteredGames.Count == 0)
            {
                if (games.Any(g => g.Platform == platform && g.Type == type))
                {
                    Console.WriteLine("Sajnáljuk, de nincs több ajánlatunk ebben a kategóriában.");
                }
                else
                {
                    Console.WriteLine("Nincsenek játékok ezen a platformon ezzel a típussal.");
                }
                return null;
            }

            int index = rnd.Next(filteredGames.Count);
            Game recommendedGame = filteredGames[index];
            recommendedGames.Add(recommendedGame); // Hozzáadjuk az ajánlott játékok listájához
            return recommendedGame;
        }

        internal Game KovetkezoAjanlat()
        {
            throw new NotImplementedException();
        }
    }
}