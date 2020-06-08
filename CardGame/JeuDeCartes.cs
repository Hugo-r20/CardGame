using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class JeuDeCartes
    {
        private List<Carte> jeuDeCartes = new List<Carte>();
        private List<string> couleurs = new List<string> { "Pique", "Trefle", "Coeur", "Carreau"};
        private List<string> figures = new List<string> { "Valet", "Reine", "Roi"};


        public JeuDeCartes()
        {
            foreach (string couleur in couleurs)
            {
                for (int i = 1; i<11; i++)
                {
                    jeuDeCartes.Add(new Carte(i.ToString(), couleur));
                }

                foreach (string figure in figures)
                {
                    jeuDeCartes.Add(new Carte(figure, couleur));
                }
            }
           
        }

        public List<Carte> ListeCartes
        {
            get { return jeuDeCartes; }
        }


    }
}
