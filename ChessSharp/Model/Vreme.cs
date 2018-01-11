using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessSharp.Model
{
    public class Vreme
    {
        public static readonly Vreme Vreme1 = new Vreme("5.0", new TimeSpan(0, 5, 0));
        public static readonly Vreme Vreme2 = new Vreme("15.0", new TimeSpan(0, 15, 0));
        public static readonly Vreme Vreme3 = new Vreme("30.0", new TimeSpan(0, 30, 0));
        public static readonly Vreme[] Vremena = new Vreme[] { Vreme1, Vreme2, Vreme3 };


        public string Naziv { get; private set; }
        public TimeSpan MaxVreme { get; private set; }
        protected Vreme(string naziv, TimeSpan maxVreme)
        {
            this.Naziv = naziv;
            this.MaxVreme = maxVreme;           
        }

        public override string ToString()
        {
            return this.Naziv;
        }
    }
}
