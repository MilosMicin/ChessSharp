using ChessSharp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ChessSharp.Model
{
    [Serializable]    
    public class PoljeSvetlo : INotifyPropertyChanged, ISerializable
    {
        public string Naziv { get; set; }
        public PoljeSvetlo() { }
        protected PoljeSvetlo(string naziv, Brush boja)
        {
            this.Naziv = naziv;
            this.Boja = boja;
        }

        private Brush boja = Brush1;
        public Brush Boja
        {
            get { return boja; }
            set
            {
                if (boja != value)
                {
                    boja = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public static Brush Brush1 = Brushes.Gray;
        public static Brush Brush2 = Brushes.Orange;
        public static Brush Brush3 = Brushes.Brown;
        public static readonly PoljeSvetlo Siva = new PoljeSvetlo("Siva", Brush1);
        public static readonly PoljeSvetlo Narandzasta = new PoljeSvetlo("Narandzasta", Brush2);
        public static readonly PoljeSvetlo Braon = new PoljeSvetlo("Braon", Brush3);
        public static readonly PoljeSvetlo[] Boje1 = new PoljeSvetlo[] { Siva, Narandzasta, Braon };
        public override string ToString()
        {
            return this.Naziv;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
           //info.AddValue("Boja",this.Boja,typeof(BrushConverter));
            info.AddValue("bojaR", ((SolidColorBrush)this.Boja).Color.R);
            info.AddValue("bojaG", ((SolidColorBrush)this.Boja).Color.G);
            info.AddValue("bojaB", ((SolidColorBrush)this.Boja).Color.B);
        }
        public PoljeSvetlo(SerializationInfo info, StreamingContext context)
        {
            byte r = info.GetByte("bojaR");
            byte g = info.GetByte("bojaG");
            byte b = info.GetByte("bojaB");
            this.Boja = new SolidColorBrush(Color.FromRgb(r, g, b));
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
    [Serializable] 
    public class PoljeTamno : INotifyPropertyChanged, ISerializable
    {
        public string Naziv { get; set; }
        public PoljeTamno() { }
        protected PoljeTamno(string naziv, Brush boja)
        {
            this.Naziv = naziv;
            this.Boja = boja;
        }

        private Brush boja = Brush4;
        public Brush Boja
        {
            get { return boja; }
            set
            {
                if (boja != value)
                {
                    boja = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public static Brush Brush4 = Brushes.Tan;
        public static Brush Brush5 = Brushes.Aqua;
        public static Brush Brush6 = Brushes.Green;
        public static readonly PoljeTamno Zuta = new PoljeTamno("Zuta", Brush4);
        public static readonly PoljeTamno Plava = new PoljeTamno("Plava", Brush5);
        public static readonly PoljeTamno Zelena = new PoljeTamno("Zelena", Brush6);
        public static readonly PoljeTamno[] Boje2 = new PoljeTamno[] { Zuta, Plava, Zelena };
        public override string ToString()
        {
            return this.Naziv;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("bojaR", ((SolidColorBrush)this.Boja).Color.R);
            info.AddValue("bojaG", ((SolidColorBrush)this.Boja).Color.G);
            info.AddValue("bojaB", ((SolidColorBrush)this.Boja).Color.B);
        }
        public PoljeTamno(SerializationInfo info, StreamingContext context)
        {
            byte r = info.GetByte("bojaR");
            byte g = info.GetByte("bojaG");
            byte b = info.GetByte("bojaB");
            this.Boja = new SolidColorBrush(Color.FromRgb(r, g, b));
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
