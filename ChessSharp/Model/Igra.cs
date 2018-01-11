using ChessSharp.ChessLogicF;
using ChessSharp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;


namespace ChessSharp.Model
{
    public enum TipIgraca
    {
        Covek, Masina
    }
    [Serializable]
    public class Igra : INotifyPropertyChanged/*, ISerializable*/
    {             
        public Igra()
        {
            this.CBoard = new ChessBoard();
           
            this.SahovskeFigurice = new SahovskeFigurice();
            this.PoljeSvetlo = new PoljeSvetlo();
            this.PoljeTamno = new PoljeTamno();

            Thread thread = new Thread(delegate()
            {
                while (true)
                {
                    Thread.Sleep(500);
                    if (StopericaPublic.Elapsed1 < TimeSpan.Zero)
                    {
                        StopericaPublic.Stop1();
                        if (MessageBox.Show("Vreme je isteklo Belom igracu", "sss", MessageBoxButton.OK) == MessageBoxResult.OK)
                        {
                            StopericaPublic.Reset1();
                            StopericaPublic.Stop1();
                            Rezultat = ChessBoard.GameResultE.OnGoing;
                            Rezultat = CBoard.GetCurrentResult();
                        }
                    }
                    else if(StopericaPublic.Elapsed2 < TimeSpan.Zero)
                    {
                        StopericaPublic.Stop2();
                        if (MessageBox.Show("Vreme je isteklo CRNOM igracu", "sss", MessageBoxButton.OK) == MessageBoxResult.OK)
                        {
                            StopericaPublic.Reset2();
                            StopericaPublic.Stop2();
                            Rezultat = ChessBoard.GameResultE.OnGoing;
                            Rezultat = CBoard.GetCurrentResult();
                        }
                    }
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }


        public ChessBoard CBoard;

        public SettingSearchMode.DifficultyLevelE DifficultyLevel;
        public ChessBoard.ValidPawnPromotionE PromocijaPesakaPublic {get; set;}
        public ChessBoard.GameResultE Rezultat { get; set; }
        public Move Potez { get; set; }
        public SahovskeFigurice SahovskeFigurice { get; set; }
        public bool Mute { get; set; }
       
        private Stoperica stoperica = new Stoperica();
        public Stoperica StopericaPublic
        {
            get { return stoperica; }
        }

        private ObservableCollection<SahovskeFigurice> kolekcijaFigurica = new ObservableCollection<SahovskeFigurice>();
        
        public ObservableCollection<SahovskeFigurice> KolekcijaFigurica
        {
            get { return kolekcijaFigurica; }
        }
        private ObservableCollection<SahovskeFigurice> konteinerBeli = new ObservableCollection<SahovskeFigurice>();

        public ObservableCollection<SahovskeFigurice> KonteinerBeliPublic
        {
            get { return konteinerBeli; }
        }
        private ObservableCollection<SahovskeFigurice> konteinerCrni = new ObservableCollection<SahovskeFigurice>();

        public ObservableCollection<SahovskeFigurice> KonteinerCrniPublic
        {
            get { return konteinerCrni; }
        }
        private ObservableCollection<ListaPoteza> listePoteza = new ObservableCollection<ListaPoteza>();
        public ObservableCollection<ListaPoteza> ListePotezaPublic
        {
            get { return listePoteza; }
            set { SetAndNotify(ref listePoteza, value); }
        }

        private PoljeSvetlo poljeSvetlo;
        public PoljeSvetlo PoljeSvetlo
        {
            get { return poljeSvetlo; }
            set
            {
                if (poljeSvetlo != value)
                {
                    poljeSvetlo = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private PoljeTamno poljeTamno;
        public PoljeTamno PoljeTamno
        {
            get { return poljeTamno; }
            set
            {
                if (poljeTamno != value)
                {
                    poljeTamno = value;
                    NotifyPropertyChanged();
                }
            }
        }        
        private Igrac trenutniIgrac;
        public Igrac TrenutniIgracPublic 
        { 
            get { return trenutniIgrac; } 
            set{ trenutniIgrac = value;} 
        }
        #region MetodeKomunikacijeSaVirtuelnomTablom              

        //Prikaz kolekcije figurica
        public void PrikaziTablu()
        {            
            kolekcijaFigurica.Clear();
            for (int i = 0; i < 64; i++)
            {
                SahovskeFigurice = new SahovskeFigurice { Pozicija = Int2Pozicija(i), TipFigurice = PieceE2Figurice(CBoard[i]), Igrac = PieceE2Igrac(CBoard[i])};        
                if (CBoard[i] != 0)
                {                    
                    kolekcijaFigurica.Add(SahovskeFigurice);
                }
            }
            Pravila();
        }
        public void PomeriFiguru(Point pozicija, SahovskeFigurice figura)
        {
            Move m = CBoard.FindIfValid(CBoard.CurrentPlayer, Pozicija2Int(pozicija), Pozicija2Int(figura.Pozicija));
            MoveExt me = new MoveExt(m);
            PromocijaPesakaPublic = CBoard.FindValidPawnPromotion(CBoard.CurrentPlayer, Pozicija2Int(pozicija), Pozicija2Int(figura.Pozicija));
            if (PromocijaPesakaPublic != ChessBoard.ValidPawnPromotionE.None)
            {
                PromocijaPesakaDijalog promocija = new PromocijaPesakaDijalog(this);
                if (promocija.ShowDialog() ?? false == true)
                {
                    switch (PromocijaPesakaPublic)
                    {
                        case ChessBoard.ValidPawnPromotionE.Queen:
                            me.Move.Type = Move.TypeE.PawnPromotionToQueen;
                            break;
                        case ChessBoard.ValidPawnPromotionE.Rook:
                            me.Move.Type = Move.TypeE.PawnPromotionToRook;
                            break;
                        case ChessBoard.ValidPawnPromotionE.Bishop:
                            me.Move.Type = Move.TypeE.PawnPromotionToBishop;
                            break;
                        case ChessBoard.ValidPawnPromotionE.Knight:
                            me.Move.Type = Move.TypeE.PawnPromotionToKnight;
                            break;
                        default:
                            break;
                    }
                }
            }
            if (CBoard.IsMoveValid(m))
            {
                CBoard.DoMove(me);
                NadjiNajboljiPotez();
                listePoteza.Add(new ListaPoteza(CBoard.GetHumanPos(me), figura.Igrac.ToString(), TipIgraca.Covek.ToString()));               
                ZvukFigure();
            }
            else
            {
                MediaPlayer PlayPotez = new MediaPlayer();
                PlayPotez.Open(new Uri(@"../../Zvuk/pogresan_potez.wav", UriKind.Relative));
                PlayPotez.Play();
            }
            if (m.Type == Move.TypeE.PieceEaten)
            {

                SahovskeFigurice = new SahovskeFigurice { TipFigurice = PieceE2Figurice(m.OriginalPiece), Igrac = PieceE2Igrac(m.OriginalPiece) };
                if (CBoard.LastMovePlayer == ChessBoard.PlayerE.White)
                {
                    konteinerCrni.Add(SahovskeFigurice);
                    PrikazPojedenihCrnihFigura();
                }
                else
                {
                    konteinerBeli.Add(SahovskeFigurice);
                    PrikazPojedenihBelihFigura();
                }                
            }
            //PrikaziTablu();
        }

        public int Pozicija2Int(Point p)
        {
            return (int)Math.Round(7 - p.X + (8 * (7 - p.Y)));
        }

        public Point Int2Pozicija(int p) //Prebacivanje iz int(njegove poziciju) u poziciju x,y(moje kordinate)
        {
            int x = 7 - (p % 8);
            int y = 7 - (int)Math.Floor((double)(p / 8));
            return new Point(x, y);
        }

        public Figurice PieceE2Figurice(ChessBoard.PieceE f) //Prebacivanje njegovih u moje figurice
        {
            f &= ChessBoard.PieceE.PieceMask;
            switch (f)
            {
                case ChessBoard.PieceE.Pawn:
                    return Figurice.Pesak;

                case ChessBoard.PieceE.Knight:
                    return Figurice.Skakac;

                case ChessBoard.PieceE.Bishop:
                    return Figurice.Lovac;

                case ChessBoard.PieceE.Rook:
                    return Figurice.Top;

                case ChessBoard.PieceE.Queen:
                    return Figurice.Kraljica;

                case ChessBoard.PieceE.King:
                    return Figurice.Kralj;

                default:
                    return Figurice.Nista;

            }

        }

        public Igrac PieceE2Igrac(ChessBoard.PieceE f) //Prebacivanje njegove u moju boju
        {
            f &= ~ChessBoard.PieceE.PieceMask;
            switch (f)
            {
                case ChessBoard.PieceE.Black:
                    return Igrac.Crni;
                default:
                    return Igrac.Beli;
            }
        }
        protected Igrac PlayerE2Igrac(ChessBoard.PlayerE f)
        {
            switch (f)
            {
                case ChessBoard.PlayerE.Black:
                    return Igrac.Crni;
                default:
                    return Igrac.Beli;
            }
        }
        public ChessBoard.PlayerE Igrac2PlayerE(Igrac f)
        {
            byte b = 0;
            switch (f)
            {
                case Igrac.Beli:
                    b = (byte)ChessBoard.PlayerE.White;
                    break;
                case Igrac.Crni:
                    b = (byte)ChessBoard.PlayerE.Black;
                    break;
                default:
                    break;
            }
            return (ChessBoard.PlayerE)b;
        }
        
        #endregion

        #region MetodeLogike
        [Serializable]
        private class FindBestMoveCookie<Igra>
        {
            public FindBestMoveCookie(Action<Igra, MoveExt> oriAction, Igra oriCookie)
            {
                m_oriAction = oriAction;
                m_oriCookie = oriCookie;
                m_dtStartFinding = DateTime.Now;
            }
            public Action<Igra, MoveExt> m_oriAction;
            public Igra m_oriCookie;
            public DateTime m_dtStartFinding;
        }

        private FindBestMoveCookie<Igra> cookieCallBack;
        public void NadjiNajboljiPotez()
        {           
            cookieCallBack = new FindBestMoveCookie<Igra>((x, y) => FindBestMoveEnd(x, y), this);
            bool potez = CBoard.FindBestMove(Igrac2PlayerE(trenutniIgrac), GetSearchMode(), Dispatcher.CurrentDispatcher, (x, y) => FindBestMoveEnd(x, y), cookieCallBack);          
        }

        private void FindBestMoveEnd<Igra>(FindBestMoveCookie<Igra> cookieCallBack, MoveExt move)
        {           
            if (move != null)
            {
                move.TimeToCompute = DateTime.Now - cookieCallBack.m_dtStartFinding;
            }           
            cookieCallBack.m_oriAction(cookieCallBack.m_oriCookie, move);    
        }
        private void FindBestMoveEnd<Igra>(Igra cookieCallBack, MoveExt move)
        {           
            if (move != null)
            {
                while (CBoard.CurrentPlayer == Igrac2PlayerE(trenutniIgrac))
                {
                    CBoard.CancelSearch();//Prekidamo pretragu najboljeg poteza  
                    CBoard.DoMove(move);//Igramo potez                                       
                    PrikaziTablu();//Prikazujemo u tabli ono sto smo odigrali
                    ZvukFigure();
                    listePoteza.Add(new ListaPoteza(CBoard.GetHumanPos(move), 
                        PlayerE2Igrac(Igrac2PlayerE(trenutniIgrac)).ToString(), TipIgraca.Masina.ToString()));

                    if (CBoard.CurrentPlayer == ChessBoard.PlayerE.Black)
                    {
                        StopericaPublic.Stop1();
                        StopericaPublic.Start2();
                    }
                    if (CBoard.CurrentPlayer == ChessBoard.PlayerE.White)
                    {
                        StopericaPublic.Stop2();
                        StopericaPublic.Start1();
                    }
                    
                }                
                if (move.Move.Type == Move.TypeE.PieceEaten)
                {
                    SahovskeFigurice = new SahovskeFigurice { Pozicija = Int2Pozicija(move.Move.EndPos), TipFigurice = PieceE2Figurice(move.Move.OriginalPiece), Igrac = PieceE2Igrac(move.Move.OriginalPiece) };
                    if (trenutniIgrac == Igrac.Beli)
                    {
                        konteinerCrni.Add(SahovskeFigurice);
                        PrikazPojedenihCrnihFigura();
                    }
                    else
                    {
                        konteinerBeli.Add(SahovskeFigurice);
                        PrikazPojedenihBelihFigura();
                    }
                    PrikaziTablu();
                }
            }
        }       
        //Tezina igre
        public SearchMode GetSearchMode()
        {
            SearchMode searchModeRetVal;
            Book bookComputer;
            SearchMode.OptionE eOption;
            SearchMode.ThreadingModeE eThreadingMode;
            int iTimeOutInSec;


            eOption = SearchMode.OptionE.UseAlphaBeta | SearchMode.OptionE.UseIterativeDepthSearch | SearchMode.OptionE.UseTransTable;
            eThreadingMode = SearchMode.ThreadingModeE.OnePerProcessorForSearch;
            iTimeOutInSec = 0;
            bookComputer = null;

            switch (DifficultyLevel)
            {
                case SettingSearchMode.DifficultyLevelE.VeryEasy:
                    searchModeRetVal = new SearchMode(new BoardEvaluationWeak(),
                                                         new BoardEvaluationWeak(),
                                                         eOption,
                                                         eThreadingMode,
                                                         2 /*iSearchDepth*/,
                                                         iTimeOutInSec,
                                                         SearchMode.RandomModeE.On,
                                                         SearchMode.Book2500,
                                                         bookComputer);
                    break;
                case SettingSearchMode.DifficultyLevelE.Easy:
                    searchModeRetVal = new SearchMode(new BoardEvaluationBasic(),
                                                         new BoardEvaluationBasic(),
                                                         eOption,
                                                         eThreadingMode,
                                                         2 /*iSearchDepth*/,
                                                         iTimeOutInSec,
                                                         SearchMode.RandomModeE.On,
                                                         SearchMode.Book2500,
                                                         bookComputer);
                    break;
                case SettingSearchMode.DifficultyLevelE.Intermediate:
                    searchModeRetVal = new SearchMode(new BoardEvaluationBasic(),
                                                         new BoardEvaluationBasic(),
                                                         eOption,
                                                         eThreadingMode,
                                                         4 /*iSearchDepth*/,
                                                         iTimeOutInSec,
                                                         SearchMode.RandomModeE.On,
                                                         SearchMode.Book2500,
                                                         bookComputer);
                    break;
                case SettingSearchMode.DifficultyLevelE.Hard:
                    searchModeRetVal = new SearchMode(new BoardEvaluationBasic(),
                                                         new BoardEvaluationBasic(),
                                                         eOption,
                                                         eThreadingMode,
                                                         5 /*iSearchDepth*/,
                                                         iTimeOutInSec,
                                                         SearchMode.RandomModeE.On,
                                                         SearchMode.Book2500,
                                                         bookComputer);
                    break;
                case SettingSearchMode.DifficultyLevelE.VeryHard:
                    searchModeRetVal = new SearchMode(new BoardEvaluationBasic(),
                                                         new BoardEvaluationBasic(),
                                                         eOption,
                                                         eThreadingMode,
                                                         5 /*iSearchDepth*/,
                                                         iTimeOutInSec,
                                                         SearchMode.RandomModeE.On,
                                                         SearchMode.Book2500,
                                                         bookComputer);
                    break;
                default:
                    searchModeRetVal = new SearchMode(new BoardEvaluationWeak(),
                                                         new BoardEvaluationWeak(),
                                                         eOption,
                                                         eThreadingMode,
                                                         2 /*iSearchDepth*/,
                                                         iTimeOutInSec,
                                                         SearchMode.RandomModeE.On,
                                                         SearchMode.Book2500,
                                                         bookComputer);
                    break;
            }
            return (searchModeRetVal);
        }
        protected void Pravila()
        {
            Rezultat = CBoard.GetCurrentResult();
            switch (Rezultat)
            {
                case ChessBoard.GameResultE.TieNoMove:
                    MessageBox.Show("Remi, nema poteza za igrače");
                    stoperica.Stop1();
                    stoperica.Stop2();
                    break;
                case ChessBoard.GameResultE.TieNoMatePossible:
                    MessageBox.Show("Remi, nemoguć mat!");
                    stoperica.Stop1();
                    stoperica.Stop2();
                    break;
                case ChessBoard.GameResultE.Check:
                    MediaPlayer sah = new MediaPlayer();
                    sah.Open(new Uri(@"../../Zvuk/sah.wav", UriKind.Relative));
                    sah.Play();
                    break;
                case ChessBoard.GameResultE.Mate:                    
                    stoperica.Stop1();
                    stoperica.Stop2();
                    MessageBox.Show("Šah-Mat");
                    MediaPlayer sah_mat = new MediaPlayer();
                    sah_mat.Open(new Uri(@"../../Zvuk/sah_mat.wav", UriKind.Relative));
                    sah_mat.Play();
                    break;
                default:
                    break;
            }
        }
        protected void PrikazPojedenihBelihFigura()
        {
            for (int i = 0; i < konteinerBeli.Count; i++)
            {
                if (SahovskeFigurice == konteinerBeli[i])
                {
                    SahovskeFigurice.Pozicija = new Point(i, 0);
                    if (i > 5 && i < 12)
                    {
                        for (int j = 0; j < i - 5; j++)
                        {
                            SahovskeFigurice.Pozicija = new Point(j, 1);
                        }
                    }
                    if (i > 11)
                    {
                        for (int c = 0; c < i - 11; c++)
                        {
                            SahovskeFigurice.Pozicija = new Point(c, 2);
                        }
                    }
                }

            }
        }
        protected void PrikazPojedenihCrnihFigura()
        {
            for (int i = 0; i < konteinerCrni.Count; i++)
            {
                if (SahovskeFigurice == konteinerCrni[i])
                {
                    SahovskeFigurice.Pozicija = new Point(i, 0);
                    if (i > 5 && i < 12)
                    {
                        for (int j = 0; j < i - 5; j++)
                        {
                            SahovskeFigurice.Pozicija = new Point(j, 1);
                        }
                    }
                    if (i > 11)
                    {
                        for (int c = 0; c < i - 11; c++)
                        {
                            SahovskeFigurice.Pozicija = new Point(c, 2);
                        }
                    }
                }
            }
        }
        public void ZvukFigure()
        {
            MediaPlayer PlayPotez = new MediaPlayer(); 
            PlayPotez.Open(new Uri(@"../../Zvuk/piece_move.wav", UriKind.Relative));
            PlayPotez.Play();
            if (this.Mute == true)
                PlayPotez.IsMuted = true;
            else
                PlayPotez.IsMuted = false;
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

    }
}
