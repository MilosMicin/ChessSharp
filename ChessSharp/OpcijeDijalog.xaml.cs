using ChessSharp.Model;
using FileReadWrite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ChessSharp
{
    /// <summary>
    /// Interaction logic for OpcijeDijalog.xaml
    /// </summary>
    public partial class OpcijeDijalog : Window, INotifyPropertyChanged
    {
        private Igra igra;
        public Igra Igra
        {
            get { return igra; }
        }

        public OpcijeDijalog(Igra igra)
        {
            InitializeComponent();
            InitializeCommands();
            this.igra = igra;
            this.DataContext = this;

            if (Igra.Mute == true)
                cbZvuk.IsChecked = false;
            else
                cbZvuk.IsChecked = true;
        }

        #region Komanda
        public RelayCommand Mute { get; set; }
        #endregion        

        #region InitialisedCommands
        private void InitializeCommands()
        {
            this.Mute = new RelayCommand
            (
                delegate(object o)
                {
                    if (cbZvuk.IsChecked == false)
                        Igra.Mute = true;
                    else
                        Igra.Mute = false;
                },
                o => true
            );
        }
        #endregion       
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            foreach (BindingExpression expression in BindingOperations.GetSourceUpdatingBindings(null))
                expression.UpdateSource();
            
            this.DialogResult = true;
            this.DataContext = this; 

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
