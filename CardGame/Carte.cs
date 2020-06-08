using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Carte
    {
        private string value;
        private string suit;
        private int score;


        public Carte (string value, string suit) 
        {
            this.value = value;
            this.suit = suit;

            bool bConvertValue = int.TryParse(this.value, out this.score);

            if (!bConvertValue)
            {
                switch (value.ToLower())
                {
                    case "as":
                        this.score = 1;
                        break;
                    case "valet":
                        this.score = 11;
                        break;
                    case "reine":
                        this.score = 12;
                        break;
                    case "roi":
                        this.score = 13;
                        break;
                    default:
                        throw new ArgumentException(paramName: nameof(value), message: "Valeur de carte incorrecte");
                }
            }
        }


        public string Value
        {
            get { return value; }
        }
        public int Score
        {
            get { return score; }
        }

        public string Suit
        {
            get { return suit; }
        }

    }
}
