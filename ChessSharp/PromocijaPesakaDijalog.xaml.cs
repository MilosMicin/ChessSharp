using ChessSharp.ChessLogicF;
using ChessSharp.Model;
using FileReadWrite;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for PromocijaPesakaDijalog.xaml
    /// </summary>
    public partial class PromocijaPesakaDijalog : Window
    {
        private Igra igra;
        public Igra Igra
        {
            get { return igra; }
        }
        
        public PromocijaPesakaDijalog(Igra igra)
        {
            InitializeComponent();
            InitializedCommand();
            this.igra = igra;
            this.DataContext = this;
        }
        #region Komande
        public RelayCommand Kraljica { get; set; }
        public RelayCommand Topp { get; set; }
        public RelayCommand Lovac { get; set; }
        public RelayCommand Skakac { get; set; }
        #endregion
        
        #region InitializeCOmmands
        private void InitializedCommand()
        {
            this.Kraljica = new RelayCommand
            (
                delegate(object o)
                {
                    Igra.PromocijaPesakaPublic = ChessLogicF.ChessBoard.ValidPawnPromotionE.Queen;
                    this.DialogResult = true;
                },
                o => true
            );
            this.Topp = new RelayCommand
            (
                delegate(object o)
                {
                    Igra.PromocijaPesakaPublic = ChessLogicF.ChessBoard.ValidPawnPromotionE.Rook;
                    this.DialogResult = true;
                },
                o => true
            );
            this.Lovac = new RelayCommand
            (
                delegate(object o)
                {
                    Igra.PromocijaPesakaPublic = ChessLogicF.ChessBoard.ValidPawnPromotionE.Bishop;
                    this.DialogResult = true;
                },
                o => true
            );
            this.Skakac = new RelayCommand
            (
                delegate(object o)
                {
                    Igra.PromocijaPesakaPublic = ChessLogicF.ChessBoard.ValidPawnPromotionE.Knight;
                    this.DialogResult = true;
                },
                o => true
            );
        }
        #endregion
    }
}
