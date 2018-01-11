using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChessSharp.Model
{
    public enum Igrac
    {
        Crni, Beli
    }
    public enum Figurice
    {
        Kralj, Kraljica, Lovac, Skakac, Top, Pesak
    }

    public class Sah : INotifyPropertyChanged
    {
        private Point pozicija;
        public Point Pozicija
        {
            get { return this.pozicija; }
            set { SetAndNotify(ref pozicija, value); }
        }

        private Figurice tipFigurice;
        public Figurice TipFigurice
        {
            get { return this.tipFigurice; }
            set { SetAndNotify(ref tipFigurice, value); }
        }

        private Igrac igrac;
        public Igrac Igrac
        {
            get { return this.igrac; }
            set { SetAndNotify(ref igrac, value); }
        }
        
        #region PropertyChangedImpl
        protected void SetAndNotify<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                NotifyPropertyChanged(propertyName);
            }
        }

        protected void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        }

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }

}
