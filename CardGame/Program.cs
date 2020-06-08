/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Program
    {
        static object LOCK;
        delegate void DELG();
        static void Main(string[] args)
        {
            DELG dlG_time = new DELG(time);
            LOCK = new object();

            System.Threading.Thread thd_timeInvok = new System.Threading.Thread(new System.Threading.ThreadStart(dlG_time.Invoke));


            Dictionary<string, int> scoreTable = new Dictionary<string, int>();
            scoreTable.Add("Player 1", 0);
            scoreTable.Add("Player 2", 0);
            scoreTable.Add("Bank", 0);

            for (int i = 0; i < 100; i++)
            {



                List<Joueur> listJoueurs = new List<Joueur>();

                listJoueurs.Add(new Joueur("Player 1", 2));
                listJoueurs.Add(new Joueur("Player 2", 2));
                listJoueurs.Add(new Joueur("Bank", 3));

                Croupier croupier = new Croupier(listJoueurs);
                croupier.distributerCartes();

                foreach (Joueur joueur in listJoueurs)
                {
                    croupier.calculerScore(joueur);
                }

                string winnerName = croupier.designerVainqueur();
                scoreTable[winnerName] += 1;

                Console.WriteLine("");
            }

            

            Console.WriteLine("Jeu terminé");
        }

        static void time()
        {
            long t = 0;
            lock (LOCK)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(t.ToString() + "secondes écoulées");
                Console.ForegroundColor = ConsoleColor.Gray;
                t += 1;
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
*/