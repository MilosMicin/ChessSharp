using ChessSharp.ChessLogicF;
using ChessSharp.Model;
using ChessSharp.Properties;
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
    /// Interaction logic for NovaIgraDialog.xaml
    /// </summary>
    public partial class NovaIgraDialog : Window
    {
        private Igra igra;
        
        public Igra Igra
        {
            get { return igra; }
        }
        private Stoperica stoperica;

        public Stoperica Stoperica
        {
            get { return stoperica; }
        }

        public NovaIgraDialog(Igra igra, Stoperica stoperica)
        {
            InitializeComponent();
            this.igra = igra;
            this.stoperica = stoperica;
            this.DataContext = this;

            if (this.igra.TrenutniIgracPublic == Igrac.Crni)
                rbBeli.IsChecked = true;
            else
                rbCrni.IsChecked = true;

            if (this.Igra.DifficultyLevel == SettingSearchMode.DifficultyLevelE.VeryEasy)
                rbNajlakse.IsChecked = true;
            else if (this.Igra.DifficultyLevel == SettingSearchMode.DifficultyLevelE.Easy)
                rbLako.IsChecked = true;
            else if (this.Igra.DifficultyLevel == SettingSearchMode.DifficultyLevelE.Intermediate)
                rbSrednje.IsChecked = true;
            else if (this.Igra.DifficultyLevel == SettingSearchMode.DifficultyLevelE.Hard)
                rbTesko.IsChecked = true;
            else if (this.Igra.DifficultyLevel == SettingSearchMode.DifficultyLevelE.VeryHard)
                rbNajteze.IsChecked = true;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (rbBeli.IsChecked == true)
                this.igra.TrenutniIgracPublic = Igrac.Crni;
            else if (rbCrni.IsChecked == true)
                this.igra.TrenutniIgracPublic = Igrac.Beli;

            if (rbNajlakse.IsChecked == true)
                this.Igra.DifficultyLevel = SettingSearchMode.DifficultyLevelE.VeryEasy;
            else if(rbLako.IsChecked == true)
                this.Igra.DifficultyLevel = SettingSearchMode.DifficultyLevelE.Easy;
            else if (rbSrednje.IsChecked == true)
                this.Igra.DifficultyLevel = SettingSearchMode.DifficultyLevelE.Intermediate;
            else if (rbTesko.IsChecked == true)
                this.Igra.DifficultyLevel = SettingSearchMode.DifficultyLevelE.Hard;
            else if (rbNajteze.IsChecked == true)
                this.Igra.DifficultyLevel = SettingSearchMode.DifficultyLevelE.VeryHard;

            foreach (BindingExpression expression in BindingOperations.GetSourceUpdatingBindings(null))
                expression.UpdateSource();
            
            this.DialogResult = true;            
            this.DataContext = this;           
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            Settings.Default.Save();
            base.OnClosing(e);
        }
    }
}
