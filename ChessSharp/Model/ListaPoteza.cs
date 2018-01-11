using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessSharp.Model
{
    [Serializable]
    public class ListaPoteza 
    {
        public string Pozicija { get; set; }
        public string Igrac { get; set; }
        public string TipIgraca { get; set; }

        public ListaPoteza() { }
        public ListaPoteza(string pozicija, string igrac, string tipIgraca)
        {
            this.Pozicija = pozicija;
            this.Igrac = igrac;
            this.TipIgraca = tipIgraca;
        }
    }
}
