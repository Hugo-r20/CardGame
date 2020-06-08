using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CardGame
{
    class Program2
    {
        delegate void DELG();
        delegate void EVT();
        static event EVT evt;
        static int loop;
        static object LOCK;

        
        static void Main(string[] args)
        {
            Dictionary<string, int> scoreTable = new Dictionary<string, int>() {
            { "Player 1", 0 },
            { "Player 2", 0 },
            { "Bank", 0 }
            };

            DELG dlG_time = new DELG(time);
            DELG dlg_multiCast;
            IAsyncResult asyncR;
            LOCK = new object();
            loop = 0;
            evt += new EVT(state_display);
            
            Thread thd_timeInvok = new Thread(new ThreadStart(dlG_time.Invoke));

            Thread thd_game = new Thread(new ThreadStart(() =>
            {
                Parallel.For(0, 10000, i =>
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
                    Thread.Sleep(10);
                    //Console.WriteLine("");
                });
                /*
                    for(int i = 0; i< 10000; i ++)
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
                        Thread.Sleep(10);
                        //Console.WriteLine("");
                    }
                */
                evt();
            }));

            asyncR = dlG_time.BeginInvoke((async) =>
            {
                DELG d = (DELG)((System.Runtime.Remoting.Messaging.AsyncResult)async).AsyncDelegate;
                d.EndInvoke(async);
                Console.WriteLine("Fin des traveaux");
            }, dlG_time);

            dlg_multiCast = thd_game.Start;
            dlg_multiCast.Invoke();

            while (!asyncR.IsCompleted) // Tant que le résult asyncR n'est pas complété, on affiche un message dans la console toutes les 5 secondes
            {
                Console.WriteLine("Travaux en cours...");
                Thread.Sleep(5000);
            }

            Console.WriteLine("==================================");
            Console.WriteLine("");
            foreach(var scoreLine in scoreTable)
            {
                Console.WriteLine("Le nombre de victoires de " + scoreLine.Key + " est " + scoreLine.Value);
            }
            Console.WriteLine("");
            Console.WriteLine("==================================");

            Console.Read();
        }

        static void time() // Méthodes affichant un timer dans la console tant que les deux threads ne sont pas terminés
        {
            long t = 0; // valeur du timer
            lock (LOCK)
            {
                while (loop < 1) // La valeur de loop est incrémentées dans state_display lorsqu'un thread se termine
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(t.ToString());
                    Console.ForegroundColor = ConsoleColor.Gray;
                    t += 1;
                    Thread.Sleep(1000);
                }
            }
        }

        static void state_display() // Méthode affichant la fin d'un thread for
        {
            Interlocked.Increment(ref loop);
        }
    }
}

