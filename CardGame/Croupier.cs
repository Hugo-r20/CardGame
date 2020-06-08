using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Croupier
    {
        private JeuDeCartes jeuDeCartes;
        private List<Carte> listeCarte;

        private List<int> listeIndexPiochés = new List<int>();

        private List<Joueur> playerList;

        public Croupier(List<Joueur> playerList)
        {
            this.playerList = playerList;

            jeuDeCartes = new JeuDeCartes();
            listeCarte = jeuDeCartes.ListeCartes;
        }

        public void distributerCartes()
        {
            Random random = new Random();

            for (int i = 0; i<7; i++)
            {
                int index = random.Next(listeCarte.Count);
                if (listeIndexPiochés.Contains(index))
                {
                    i--;
                } else
                {
                    listeIndexPiochés.Add(index);
                }
            }

            int valueIndex = 0;
            foreach (Joueur player in playerList)
            {
                for (int i = 0; i<player.NbCartes; i++)
                {
                    player.addCarte(listeCarte[listeIndexPiochés[valueIndex]]);
                    valueIndex++;
                }
            }
           
        }

        public void calculerScore(Joueur player)
        {
            List<Carte> listeCartesJoueur = player.ListeCartes;
            int score = player.Score;

            foreach (Carte carte in listeCartesJoueur)
            {
                score += carte.Score;
            }

            if (player.NbCartes == 2)
            {
                if (listeCartesJoueur[0].Suit == listeCartesJoueur[1].Suit)
                {
                    score += 20;
                }
            } else if (player.NbCartes == 3)
            {
                if (listeCartesJoueur[0].Suit == listeCartesJoueur[1].Suit && listeCartesJoueur[0].Suit == listeCartesJoueur[2].Suit)
                {
                    score += 35;
                } else if (listeCartesJoueur[0].Value == listeCartesJoueur[1].Value && listeCartesJoueur[0].Value == listeCartesJoueur[2].Value)
                {
                    score += 1000;
                }
            }

            player.Score = score;
        }

        public string designerVainqueur()
        {
            int maxscore = playerList.Max(player => player.Score);
            string winnerName = "";

            foreach (Joueur player in playerList)
            {   
                if (player.Score == maxscore)
                {
                    Console.WriteLine("Le vainqueur est : " + player.Name + " avec " + player.Score + " points.");
                    winnerName = player.Name;
                }

            }

            return winnerName;
        }

    }
}
