using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ChessSharp.Model
{
    public class SetFigurica : INotifyPropertyChanged
    {
        public SetFigurica() { }
        public SetFigurica(string naziv, Uri putanja)
        {
            this.Naziv = naziv;
            this.putanja = putanja;
        }
        public string Naziv { get; set; }

        private Uri putanja = classic;
        public Uri PutanjaPublic
        {
            get { return this.putanja; }
            set { SetAndNotify(ref putanja, value); }
        }

        public static Uri classic = new Uri(@"../../Slicice/1/", UriKind.Relative);
        public static Uri renesans = new Uri(@"../../Slicice/2/", UriKind.Relative);
        public static readonly SetFigurica putanja1 = new SetFigurica("Classic", classic);
        public static readonly SetFigurica putanja2 = new SetFigurica("Renesans", renesans);

        public static readonly SetFigurica[] Putanje = new SetFigurica[] { putanja1, putanja2 };
        public override string ToString()
        {
            return this.Naziv;
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
