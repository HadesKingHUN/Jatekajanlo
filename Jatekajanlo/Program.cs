using Jatekajanlo;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Üdvözöllek! Kérlek, add meg a neved:");
        string name = Console.ReadLine();
        Felhasznalo user = new Felhasznalo(name);

        Console.WriteLine($"Üdvözöllek {name}, Kérlek válassz platformot (xbox/ps/pc):");
        user.PreferredPlatform = Console.ReadLine().ToLower();

        Console.WriteLine("Milyen típusú játékot szeretnél? (akció/kaland/stratégia/Sport/túlélő):");
        user.PreferredType = Console.ReadLine().ToLower();

        Gameajanlo recommender = new Gameajanlo();
        Game recommendedGame = recommender.Ajanlottjatek(user.PreferredPlatform, user.PreferredType);

        bool elfogadva = false;
        while (!elfogadva && recommendedGame != null)
        {
            Console.WriteLine($"Ajánlott játék: {recommendedGame.Title}. Elfogadod? (igen/nem)");
            string válasz = Console.ReadLine().ToLower();

            if (válasz == "igen")
            {
                Console.WriteLine($"Tökéletes választás! Jó szórakozást a(z) {recommendedGame.Title} játékkal!");
                elfogadva = true;
            }
            else
             {
                recommendedGame = recommender.Ajanlottjatek(user.PreferredPlatform, user.PreferredType);

                if (recommendedGame == null)
                {
                    elfogadva = true; 
                }
            }
        }
    }
}