using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Joueur
    {
        private List<Carte> cartesJoueur = new List<Carte>();
        private int score = 0;
        private int nbCartes;
        private string name;

        public Joueur(string name, int nbCartes)
        {
            this.name = name;
            this.nbCartes = nbCartes;
        }

        public List<Carte> ListeCartes 
        { 
            get { return cartesJoueur; }
            set { cartesJoueur = value; } 
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        public int NbCartes
        {
            get { return nbCartes; }
        }
        public string Name
        {
            get { return name; }
        }

        public void addCarte (Carte carte)
        {
            cartesJoueur.Add(carte);
        }

    }
}
