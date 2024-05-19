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
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string filename = "myFile.txt";
            string filePath = Path.Combine(path, filename);
            games = new List<Game>();
            LoadGamesFromFile("jatekok.txt");
        }

        private void LoadGamesFromFile(string filePath)
        {
            try
            {
                var lines = File.ReadAllLines(filePath);
                string currentPlatform = "";

                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    if (line.StartsWith("//"))
                    {
                        currentPlatform = line.TrimStart('/').Trim();
                    }
                    else
                    {
                        var parts = line.Split(',');
                        if (parts.Length == 2)
                        {
                            string title = parts[0].Trim();
                            string type = parts[1].Trim();

                            switch (currentPlatform.ToLower())
                            {
                                case "ps játékok":
                                    games.Add(new PsGame(title, type));
                                    break;
                                case "xbox játékok":
                                    games.Add(new XboxGame(title, type));
                                    break;
                                case "pc játékok":
                                    games.Add(new PcGame(title, type));
                                    break;
                                default:
                                    Console.WriteLine($"Ismeretlen platform: {currentPlatform}");
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba történt a játékok beolvasása közben: {ex.Message}");
            }
        }


        public Game Ajanlottjatek(string platform, string type)
        {
            Random rnd = new Random();
           
            var filteredGames = games.Where(g => g.Platform == platform && g.Type == type && !recommendedGames.Contains(g)).ToList();

           
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
            recommendedGames.Add(recommendedGame); 
            return recommendedGame;
        }

        internal Game KovetkezoAjanlat()
        {
            throw new NotImplementedException();
        }
    }
}