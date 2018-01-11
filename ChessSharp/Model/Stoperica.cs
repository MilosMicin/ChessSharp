using ChessSharp.Model;
using ChessSharp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ChessSharp.Model
{
    [Serializable]
    public class Stoperica : INotifyPropertyChanged
    {       
        public MyStopwatch Stoperica1 = new MyStopwatch();
        public MyStopwatch Stoperica2 = new MyStopwatch();
       
        public Stoperica()
        {            
            Thread thread = new Thread(delegate()
            {
                while (true)
                {
                    Thread.Sleep(500);
                    NotifyPropertyChanged("Elapsed1");
                    NotifyPropertyChanged("Elapsed2");
                }
            });
            thread.IsBackground = true;
            thread.Start();
            
        }

        public TimeSpan ts { get; set; }
        public TimeSpan Elapsed1
        {
            get
            {
                return ts =  this.MaxVreme - Stoperica1.Elapsed;
            }
            set { ts = value; }
        }
        public TimeSpan Elapsed2
        {
            get
            {
                return this.MaxVreme - Stoperica2.Elapsed;
            }
        }

        public bool Radi1
        {
            get { return this.Stoperica1.IsRunning; }
        }
        public bool Radi2
        {
            get { return this.Stoperica2.IsRunning; }
        }

        public void Stop1()
        {
            this.Stoperica1.Stop();
            NotifyPropertyChanged("Elapsed1");
            NotifyPropertyChanged("Radi1");
        }
        public void Stop2()
        {
            this.Stoperica2.Stop();
            NotifyPropertyChanged("Elapsed2");
            NotifyPropertyChanged("Radi2");
        }

        public void Start1()
        {
            this.Stoperica1.Start();
            NotifyPropertyChanged("Elapsed1");
            NotifyPropertyChanged("Radi1");
        }        
        public void Start2()
        {
            this.Stoperica2.Start();
            NotifyPropertyChanged("Elapsed1");
            NotifyPropertyChanged("Radi2");
        }
        public void Reset1()
        {
            this.Stoperica1.Restart();
            NotifyPropertyChanged("Elapsed1");
            NotifyPropertyChanged("Radi1");
        }
        public void Reset2()
        {
            this.Stoperica2.Reset();
            NotifyPropertyChanged("Elapsed2");
            NotifyPropertyChanged("Radi2");
        }

        //public static readonly Stoperica Vreme1 = new Stoperica("5.0 min", new TimeSpan(0, 5, 0));
        //public static readonly Stoperica Vreme2 = new Stoperica("15.0 min ", new TimeSpan(0, 15, 0));
        //public static readonly Stoperica Vreme3 = new Stoperica("30.0 min", new TimeSpan(0, 30, 0));
        //public static readonly Stoperica[] Vremena = new Stoperica[] { Vreme1, Vreme2, Vreme3 };
        public static readonly TimeSpan Vreme1 = new TimeSpan(0, 5, 0);
        public static readonly TimeSpan Vreme2 = new TimeSpan(0, 15, 0);
        public static readonly TimeSpan Vreme3 = new TimeSpan(0, 30, 0);
        //public static readonly TimeSpan Vreme4 = new TimeSpan(0, 0, 10);

        public static readonly TimeSpan[] Vremena = new TimeSpan[] { Vreme1, Vreme2, Vreme3 };

        public string Naziv { get; private set; }
        private TimeSpan maxVreme; //new TimeSpan(0, 30, 0);
        public TimeSpan MaxVreme 
        {
            get { return maxVreme; }
            set
            {
                if (maxVreme != value)
                {
                    maxVreme = value;
                    NotifyPropertyChanged();
                }
            }
        }

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
