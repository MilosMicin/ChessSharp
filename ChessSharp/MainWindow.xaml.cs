using ChessSharp.ChessLogicF;
using ChessSharp.Model;
using ChessSharp.Properties;
using FileReadWrite;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ChessSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [Serializable]
    public partial class MainWindow : Window, INotifyPropertyChanged
    {        
        private Igra igra = new Igra();
        public Igra Igra
        {
            get { return igra; }
            set { SetAndNotify(ref igra, value); }
        }      
        private SahovskeFigurice sahovkaFigura = new SahovskeFigurice();
        public SahovskeFigurice SahovskaFiguraPublic
        {
            get { return sahovkaFigura; }
            set { SetAndNotify(ref sahovkaFigura, value); }
        }

        Point prethodnaPozicijaMisa;
        Image selektovanaFigura;        
        Point selektovanaFiguraPrethodnaPozicija = new Point();
        

        public MainWindow()
        {
            InitializeComponent();
            InitializeCommands();
            this.DataContext = this;
            
            CloseSave();
            Igra.PrikaziTablu();           
            Igra.StopericaPublic.Start1();
            Igra.NadjiNajboljiPotez();
        }

        #region Komande

        public RelayCommand New { get; set; }
        public RelayCommand Opcije { get; set; }
        public RelayCommand Open { get; set; }
        public RelayCommand Undo { get; set; }
        public RelayCommand About { get; set; }

        #endregion

        #region Metode
       
        private void CentarY()
        {
            SahovskeFigurice sahovkaFigura = selektovanaFigura.Tag as SahovskeFigurice;
            if (sahovkaFigura.Pozicija.Y < 0.6)
                sahovkaFigura.Pozicija = new Point(sahovkaFigura.Pozicija.X, 0);
            else if (sahovkaFigura.Pozicija.Y < 1.6)
                sahovkaFigura.Pozicija = new Point(sahovkaFigura.Pozicija.X, 1);
            else if (sahovkaFigura.Pozicija.Y < 2.6)
                sahovkaFigura.Pozicija = new Point(sahovkaFigura.Pozicija.X, 2);
            else if (sahovkaFigura.Pozicija.Y < 3.6)
                sahovkaFigura.Pozicija = new Point(sahovkaFigura.Pozicija.X, 3);
            else if (sahovkaFigura.Pozicija.Y < 4.6)
                sahovkaFigura.Pozicija = new Point(sahovkaFigura.Pozicija.X, 4);
            else if (sahovkaFigura.Pozicija.Y < 5.6)
                sahovkaFigura.Pozicija = new Point(sahovkaFigura.Pozicija.X, 5);
            else if (sahovkaFigura.Pozicija.Y < 6.6)
                sahovkaFigura.Pozicija = new Point(sahovkaFigura.Pozicija.X, 6);
            else if (sahovkaFigura.Pozicija.Y > 6.6 || sahovkaFigura.Pozicija.Y < 7.6)
                sahovkaFigura.Pozicija = new Point(sahovkaFigura.Pozicija.X, 7);

        }      
        //Dogadjaj za pomeranje misa
        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point pozicijaMisa = e.GetPosition(null);
                Vector diff = pozicijaMisa - prethodnaPozicijaMisa;

                SahovskeFigurice sahovkaFigura = selektovanaFigura.Tag as SahovskeFigurice;
                sahovkaFigura.Pozicija = new Point(sahovkaFigura.Pozicija.X + diff.X / Igra.SahovskeFigurice.ZoomPublic, sahovkaFigura.Pozicija.Y + diff.Y / Igra.SahovskeFigurice.ZoomPublic);
                prethodnaPozicijaMisa = pozicijaMisa;
            }
        }
        //Dogadjaj pozvan pritiskom na mis
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {           
            prethodnaPozicijaMisa = e.GetPosition(null);
            selektovanaFigura = sender as Image;
            this.sahovkaFigura = selektovanaFigura.Tag as SahovskeFigurice;
            selektovanaFiguraPrethodnaPozicija = sahovkaFigura.Pozicija;
        }
        //Dogadjaj pozvan spustanjem na mis
        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released)
            {
                Point trenutnaPozicijaMisa = e.GetPosition(null);
                this.sahovkaFigura = selektovanaFigura.Tag as SahovskeFigurice;
                    
                if (sahovkaFigura.Pozicija.X < 0.6)
                {
                    sahovkaFigura.Pozicija = new Point(0, sahovkaFigura.Pozicija.Y);
                    CentarY();
                }
                else if (sahovkaFigura.Pozicija.X < 1 || sahovkaFigura.Pozicija.X < 1.6)
                {
                    sahovkaFigura.Pozicija = new Point(1, sahovkaFigura.Pozicija.Y);
                    CentarY();
                }
                else if (sahovkaFigura.Pozicija.X < 2 || sahovkaFigura.Pozicija.X < 2.6)
                {
                    sahovkaFigura.Pozicija = new Point(2, sahovkaFigura.Pozicija.Y);
                    CentarY();
                }
                else if (sahovkaFigura.Pozicija.X < 3 || sahovkaFigura.Pozicija.X < 3.6)
                {
                    sahovkaFigura.Pozicija = new Point(3, sahovkaFigura.Pozicija.Y);
                    CentarY();
                }
                else if (sahovkaFigura.Pozicija.X < 4 || sahovkaFigura.Pozicija.X < 4.6)
                {
                    sahovkaFigura.Pozicija = new Point(4, sahovkaFigura.Pozicija.Y);
                    CentarY();
                }
                else if (sahovkaFigura.Pozicija.X < 5 || sahovkaFigura.Pozicija.X < 5.6)
                {
                    sahovkaFigura.Pozicija = new Point(5, sahovkaFigura.Pozicija.Y);
                    CentarY();
                }
                else if (sahovkaFigura.Pozicija.X < 6 || sahovkaFigura.Pozicija.X < 6.6)
                {
                    sahovkaFigura.Pozicija = new Point(6, sahovkaFigura.Pozicija.Y);
                    CentarY();
                }
                else if (sahovkaFigura.Pozicija.X < 7 || sahovkaFigura.Pozicija.X > 7)
                {
                    sahovkaFigura.Pozicija = new Point(7, sahovkaFigura.Pozicija.Y);
                    CentarY();
                }

                Igra.PomeriFiguru(selektovanaFiguraPrethodnaPozicija, sahovkaFigura);

                if (Igra.CBoard.CurrentPlayer == ChessBoard.PlayerE.Black)
                {
                    Igra.StopericaPublic.Stop1();
                    Igra.StopericaPublic.Start2();
                }
                if (Igra.CBoard.CurrentPlayer == ChessBoard.PlayerE.White)
                {
                    Igra.StopericaPublic.Stop2();
                    Igra.StopericaPublic.Start1();
                }
                
                if (ListaPoteza.Items.Count > 4)
                {
                    var border = VisualTreeHelper.GetChild(ListaPoteza, 0) as Decorator;
                    if (border != null)
                    {
                        var scroll = border.Child as ScrollViewer;
                        if (scroll != null) scroll.ScrollToEnd();
                    }
                }
                Igra.PrikaziTablu();
                Igra.ZvukFigure();
            }
        }
        protected void CloseSave()
        {
            Igra.SahovskeFigurice.ZoomPublic = Settings.Default.Zoom;
            Igra.StopericaPublic.MaxVreme = Settings.Default.Tajmer;
        }
        protected void NovaIgra()
        {
            this.Igra.CBoard.ResetBoard();
            Igra.NadjiNajboljiPotez();
            Igra.ListePotezaPublic.Clear();
            Igra.KonteinerBeliPublic.Clear();
            Igra.KonteinerCrniPublic.Clear();
        }

        #endregion
              
        #region InitializeCOmmands
        private void InitializeCommands()
        {
            //Nova igra
            this.New = new RelayCommand
            (
                delegate(object o)
                {
                    if (MessageBox.Show("Zelite li da sacuvate partiju?", "Nova igra", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
                    {
                        SaveFileDialog save = new SaveFileDialog();
                        save.Filter = "Chess Sharp file (*.csf)|*.csf";
                        if (save.ShowDialog() ?? false == true)
                        {
                            using (FileStream stream = File.Open(save.FileName, FileMode.Create))
                            {
                                BinaryFormatter formatter = new BinaryFormatter();
                                formatter.Serialize(stream, this.Igra);
                                //formatter.Serialize(stream, this.Stoperica);
                            }                            
                            //this.Igra = new Igra();
                            NovaIgra();
                            Igra.PrikaziTablu();
                            Igra.StopericaPublic.Reset1();
                            Igra.StopericaPublic.Reset2();
                            Igra.PrikaziTablu();
                        }
                    }
                    else
                    {
                        NovaIgraDialog newDialog = new NovaIgraDialog(Igra, Igra.StopericaPublic);
                        newDialog.ShowDialog();

                        if (newDialog.DialogResult == true)
                        {
                            NovaIgra();
                            Igra.PrikaziTablu();
                            Igra.StopericaPublic.Reset1();
                        }
                    }
                },
                o => true
            );
            this.Open = new RelayCommand
            (
                delegate(object o)
                {
                    OpenFileDialog load = new OpenFileDialog();
                    load.Filter = "Chess Sharp file (*.csf)|*.csf";
                    if (load.ShowDialog() ?? false == true)
                    {
                        using (FileStream stream = File.OpenRead(load.FileName))
                        {
                            BinaryFormatter formatter = new BinaryFormatter();
                            this.Igra = formatter.Deserialize(stream) as Igra;
                            //this.Stoperica = formatter.Deserialize(stream) as Stoperica;
                        }
                        Igra.PrikaziTablu();
                        Igra.StopericaPublic.Start1();
                    }                    
                },
                o => true
            );
            this.Opcije = new RelayCommand
            (
                delegate(object o)
                {
                    OpcijeDijalog opcijeD = new OpcijeDijalog(Igra);
                    opcijeD.ShowDialog();
                },
                o => true
            );
            this.Undo = new RelayCommand
            (
                delegate(object o)
                {
                    MovePosStack mps = Igra.CBoard.MovePosStack;
                    if (Igra.CBoard.MovePosStack.PositionInList >= 0)
                    {
                        
                        if (mps.CurrentMove.Move.Type == Move.TypeE.PieceEaten)
                        {
                            for (int i = 0; i < Igra.KonteinerCrniPublic.Count; i++)
                                Igra.KonteinerCrniPublic.Move(Igra.KonteinerCrniPublic.Count - 1, i);
                            Igra.KonteinerCrniPublic.RemoveAt(0);
                            for (int i = 0; i < Igra.KonteinerCrniPublic.Count; i++)
                                Igra.KonteinerCrniPublic.Move(Igra.KonteinerCrniPublic.Count - 1, i);
                        }
                        Igra.CBoard.UndoMove();
                        if (mps.CurrentMove.Move.Type == Move.TypeE.PieceEaten)
                        {
                            for (int i = 0; i < Igra.KonteinerBeliPublic.Count; i++)
                                Igra.KonteinerBeliPublic.Move(Igra.KonteinerBeliPublic.Count - 1, i);
                            Igra.KonteinerBeliPublic.RemoveAt(0);
                            for (int i = 0; i < Igra.KonteinerBeliPublic.Count; i++)
                                Igra.KonteinerBeliPublic.Move(Igra.KonteinerBeliPublic.Count - 1, i);
                        }
                        Igra.CBoard.UndoMove();
                        Igra.ListePotezaPublic.Remove(Igra.ListePotezaPublic.Last());
                        Igra.ListePotezaPublic.Remove(Igra.ListePotezaPublic.Last());
                    }
                    Igra.PrikaziTablu();
                },
                o => true
            );
            this.About = new RelayCommand
            (
                delegate(object o)
                {
                    AboutDialog about = new AboutDialog();
                    about.ShowDialog();
                },
                o => true
            );
        }
        #endregion

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
        
        protected override void OnClosing(CancelEventArgs e)
        {
            Settings.Default.Tajmer = Igra.StopericaPublic.MaxVreme;
            Settings.Default.Zoom = Igra.SahovskeFigurice.ZoomPublic;
            Settings.Default.Save();
            base.OnClosing(e);
        }
    }
}
