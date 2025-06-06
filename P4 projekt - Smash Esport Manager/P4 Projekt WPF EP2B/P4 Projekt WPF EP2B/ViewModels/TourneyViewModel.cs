using Microsoft.EntityFrameworkCore.Metadata.Internal;
using P4_Projekt_WPF_EP2B.Models;
using P4_Projekt_WPF_EP2B.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace P4_Projekt_WPF_EP2B.ViewModels
{
    public class TourneyViewModel : BaseViewModel
    {
        public ObservableCollection<TourneyModel> Tourneys { get; set; }
        // ObservableCollection działa jak list<T>, tylko przy zmianie wartości zmiany są synchronizowane z elementami
        // wyświetlających/korzystających z tych danych

        private int _curTId;
        private string _curTName;
        private string _curTWhichSite;
        private string _curTSiteLink;
        private DateOnly _curTStartDate;
        private DateOnly _curTEndDate;
        private bool _curTIsOnline;
        private string _curTAdress;
        private string _curTCity;
        private string _curTZipCode;
        private string _curTCountry;
        private string _curTNotes;

        // zmienne prywatne, a poniżej znajdują się zmienne publiczne, do których wykonuje się wpisywanie i czytanie
        // danych ze zmiennych prywatnych, bez pełnego dostępu do samej zmiennej
        // (Zmienne publiczne są też używane do Bindowania z elementami interfejsu w Views)

        public int CurTId{ get => _curTId; set { _curTId = value; OnPropertyChanged(); }	}
        public string CurTName{ get => _curTName; set { _curTName = value; OnPropertyChanged(); }	}
        public string CurTWhichSite{ get => _curTWhichSite; set { _curTWhichSite = value; OnPropertyChanged(); }	}
        public string CurTSiteLink{ get => _curTSiteLink; set { _curTSiteLink = value; OnPropertyChanged(); }	}
        public DateOnly CurTStartDate{ get => _curTStartDate; set { _curTStartDate = value; OnPropertyChanged(); }	}
        public DateOnly CurTEndDate{ get => _curTEndDate; set { _curTEndDate = value; OnPropertyChanged(); }	}
        public bool CurTIsOnline{ get => _curTIsOnline; set { _curTIsOnline = value; OnPropertyChanged(); }	}
        public string CurTAdress{ get => _curTAdress; set { _curTAdress = value; OnPropertyChanged(); }	}
        public string CurTCity{ get => _curTCity; set { _curTCity = value; OnPropertyChanged(); }	}
        public string CurTZipCode{ get => _curTZipCode; set { _curTZipCode = value; OnPropertyChanged(); }	}
        public string CurTCountry{ get => _curTCountry; set { _curTCountry = value; OnPropertyChanged(); }	}
        public string CurTNotes{ get => _curTNotes; set { _curTNotes = value; OnPropertyChanged(); }	}
        public ICommand TCreateCommand { get; set; }
        public ICommand TUpdateCommand { get; set; }
        public ICommand TDeleteCommand { get; set; }
        public ICommand TSelectCommand { get; set; }

        private int _tSelectedIndex;
        public int TSelectedIndex {  get => _tSelectedIndex; set 
            {
                _tSelectedIndex = value;
                PlayersInTourneys = PlayersInTourneys;
                // ^ Służy do odświeżenia listy pośrednictw przy wybraniu turnieju/gracza
                if (TSelectedIndex > -1 && TSelectedIndex < Tourneys.Count)
                {
                    CurTId = Tourneys[TSelectedIndex].tId;
                    CurTName = Tourneys[TSelectedIndex].tName;
                    CurTWhichSite = Tourneys[TSelectedIndex].tWhichSite;
                    CurTSiteLink = Tourneys[TSelectedIndex].tSiteLink;
                    CurTStartDate = Tourneys[TSelectedIndex].tStartDate;
                    CurTEndDate = Tourneys[TSelectedIndex].tEndDate;
                    CurTIsOnline = Tourneys[TSelectedIndex].tIsOnline;
                    CurTAdress = Tourneys[TSelectedIndex].tAdress;
                    CurTCity = Tourneys[TSelectedIndex].tCity;
                    CurTZipCode = Tourneys[TSelectedIndex].tZipCode;
                    CurTCountry = Tourneys[TSelectedIndex].tCountry;
                    CurTNotes = Tourneys[TSelectedIndex].tNotes;
                }
                OnPropertyChanged();
            } 
        }

        public TourneyViewModel()
        {
            Tourneys = new ObservableCollection<TourneyModel>(ReadTourney());
            // Załadowanie danych z Baz Danych przy uruchomieniu (przez ReadTourney())

            TCreateCommand = new RelayCommand(CreateTourney, () => true);
            //TReadCommand = new RelayCommand(ReadTourney, (IQueryable<TourneyModel>) => true);
            TUpdateCommand = new RelayCommand(UpdateTourney, () => true);
            TDeleteCommand = new RelayCommand(DeleteTourney, () => true);
            // Zbindowane komendy uruchamiają funkcje
            CurTId = 0;
            CurTName = "Nazwa turnieju";
            CurTWhichSite = "start.gg";
            CurTSiteLink = "Link do strony";
            CurTStartDate = DateOnly.FromDateTime(DateTime.Now);
            CurTEndDate = DateOnly.FromDateTime(DateTime.Now);
            CurTIsOnline = false;
            CurTAdress = "Ul. Pszczyńska 1";
            CurTCity = "Pszczyna";
            CurTZipCode = "43-200";
            CurTCountry = "Polska";
            CurTNotes = "Opcjonalne notatki";
            // Wartości podstawowe

            TSelectedIndex = -1;
            // Index to numer wybranego element na liście

            Players = new ObservableCollection<PlayerModel>(ReadPlayer());

            PCreateCommand = new RelayCommand(CreatePlayer, () => true);
            //PReadCommand = new RelayCommand(ReadPlayer, (IQueryable<PlayerModel>) => true);
            PUpdateCommand = new RelayCommand(UpdatePlayer, () => true);
            PDeleteCommand = new RelayCommand(DeletePlayer, () => true);

            CurPId = 0;
            CurPName = "Nazwa gracza";
            CurPPrefix = "Prefix";
            CurPPronouns = "Zaimek";
            CurPMainName = "Mario";
            CurPDifficulty = 0;
            CurPCountry = "Kraj";
            CurPJoinDate = DateOnly.FromDateTime(DateTime.Now);
            CurPLink = "Link do Strony";
            CurPIsAccountless = false;
            CurPNotes = "Opcjonalne notatki";

            PSelectedIndex = -1;


            PlayersInTourneys = new ObservableCollection<PlayerInTourneyModel>(ReadPlayerInTourney());

            PitCreateCommand = new RelayCommand(CreatePlayerInTourney, () => true);
            //PitReadCommand = new RelayCommand(ReadPlayer, (IQueryable<PlayerInTourneyModel>) => true);
            PitUpdateCommand = new RelayCommand(UpdatePlayerInTourney, () => true);
            PitDeleteCommand = new RelayCommand(DeletePlayerInTourney, () => true);

            CurPitId = 0;
            CurPitIsPlaying = true;
            CurPitIsTO = false;
            CurPitSeeding = 0;

            PitSelectedIndex_ForT = -1;
            PitSelectedIndex_ForP = -1;
        }


        private void CreateTourney()
        {
            var newTourney = new TourneyModel
            {
                tId = Tourneys.Count + 1,
                tName = CurTName,
                tWhichSite = CurTWhichSite,
                tSiteLink = CurTSiteLink,
                tStartDate = CurTStartDate,
                tEndDate = CurTEndDate,
                tIsOnline = CurTIsOnline,
                tAdress = CurTAdress,
                tCity = CurTCity,
                tZipCode = CurTZipCode,
                tCountry = CurTCountry,
                tNotes = CurTNotes,
            };
            Tourneys.Add(newTourney);
            newTourney.tId = default(int);
            using (var context = new SmashTourneysDBContext())
            { // połączenie się z bazą, dodanie nowego turnieju do niej, i zapisanie zmian
                context.Add(newTourney);
                context.SaveChanges();
            }
        }

        public IQueryable<TourneyModel> ReadTourney()
        { // załadowanie danych z Bazy Danych
            using (var context = new SmashTourneysDBContext())
            {
                return context.Tourneys.ToList().AsQueryable();
            }
        }

        private void UpdateTourney()
        { // Aktualizacja danych
            if (TSelectedIndex > -1 && TSelectedIndex < Tourneys.Count)
            {
                CurTId = Tourneys[TSelectedIndex].tId;
            }
            var tourneyToUpdateIndex = Tourneys
                .IndexOf(Tourneys.SingleOrDefault(x => x.tId == CurTId));
            // znalezienie danych turnieju zaznaczonego z listy
            if (tourneyToUpdateIndex >= 0)
            {
                var newTourney = new TourneyModel
                {
                    tId = CurTId,
                    tName = CurTName,
                    tWhichSite = CurTWhichSite,
                    tSiteLink = CurTSiteLink,
                    tStartDate = CurTStartDate,
                    tEndDate = CurTEndDate,
                    tIsOnline = CurTIsOnline,
                    tAdress = CurTAdress,
                    tCity = CurTCity,
                    tZipCode = CurTZipCode,
                    tCountry = CurTCountry,
                    tNotes = CurTNotes,
                };
                Tourneys[tourneyToUpdateIndex]= newTourney;
                using (var context = new SmashTourneysDBContext())
                {
                    var upd = context.Tourneys.Where(x => x.tId == CurTId).Single();
                    upd.tName = newTourney.tName; upd.tWhichSite=newTourney.tWhichSite; 
                    upd.tSiteLink=newTourney.tSiteLink; upd.tStartDate=newTourney.tStartDate; 
                    upd.tEndDate=newTourney.tEndDate; upd.tIsOnline=newTourney.tIsOnline; 
                    upd.tAdress=newTourney.tAdress; upd.tCity=newTourney.tCity; 
                    upd.tZipCode=newTourney.tZipCode; upd.tCountry=newTourney.tCountry; 
                    upd.tNotes=newTourney.tNotes;
                    context.SaveChanges();
                }
            }
        }

        private void DeleteTourney()
        { // usunięcie danych
            if (TSelectedIndex > -1 && TSelectedIndex < Tourneys.Count)
            {
                CurTId = Tourneys[TSelectedIndex].tId;
            }
            var tourneyToRemove = Tourneys.FirstOrDefault(x => x.tId == CurTId);
            if (tourneyToRemove != null)
            {
                Tourneys.Remove(tourneyToRemove);
                using (var context = new SmashTourneysDBContext())
                {
                    context.Remove(context.Tourneys.Where(x => x.tId == CurTId).Single());
                    context.SaveChanges();
                }
            }
        }

        // Players


        public ObservableCollection<PlayerModel> Players { get; set; }

        private int _curPId;
        private string _curPName;
        private string _curPPrefix;
        private string _curPPronouns;
        private string _curPMainName;
        private int _curPDifficulty;
        private string _curPCountry;
        private DateOnly _curPJoinDate;
        private string _curPLink;
        private bool _curPIsAccountless;
        private string _curPNotes;

        public int CurPId { get => _curPId; set { _curPId = value; OnPropertyChanged(); } }
        public string CurPName { get => _curPName; set { _curPName = value; OnPropertyChanged(); } }
        public string CurPPrefix { get => _curPPrefix; set { _curPPrefix = value; OnPropertyChanged(); } }
        public string CurPPronouns { get => _curPPronouns; set { _curPPronouns = value; OnPropertyChanged(); } }
        public string CurPMainName { get => _curPMainName; set { _curPMainName = value; OnPropertyChanged(); } }
        public int CurPDifficulty { get => _curPDifficulty; set { _curPDifficulty = value; OnPropertyChanged(); } }
        public string CurPCountry { get => _curPCountry; set { _curPCountry = value; OnPropertyChanged(); } }
        public DateOnly CurPJoinDate { get => _curPJoinDate; set { _curPJoinDate = value; OnPropertyChanged(); } }
        public string CurPLink { get => _curPLink; set { _curPLink = value; OnPropertyChanged(); } }
        public required bool CurPIsAccountless { get => _curPIsAccountless; set { _curPIsAccountless = value; 
                OnPropertyChanged(); } }
        public string CurPNotes { get => _curPNotes; set { _curPNotes = value; OnPropertyChanged(); } }
        public ICommand PCreateCommand { get; set; }
        public ICommand PUpdateCommand { get; set; }
        public ICommand PDeleteCommand { get; set; }
        public ICommand PSelectCommand { get; set; }

        private int _pSelectedIndex;
        public int PSelectedIndex
        {
            get => _pSelectedIndex; set
            {
                _pSelectedIndex = value;
                PlayersInTourneys = PlayersInTourneys;
                if (PSelectedIndex > -1 && PSelectedIndex < Players.Count)
                {
                    CurPId = Players[PSelectedIndex].pId;
                    CurPName = Players[PSelectedIndex].pName;
                    CurPPrefix = Players[PSelectedIndex].pPrefix;
                    CurPPronouns = Players[PSelectedIndex].pPronouns;
                    CurPMainName = Players[PSelectedIndex].pMainName;
                    CurPDifficulty = (int)Players[PSelectedIndex].pDifficulty;
                    CurPCountry = Players[PSelectedIndex].pCountry;
                    CurPJoinDate = (DateOnly)Players[PSelectedIndex].pJoinDate;
                    CurPLink = Players[PSelectedIndex].pLink;
                    CurPIsAccountless = Players[PSelectedIndex].pIsAccountless;
                    CurPNotes = Players[PSelectedIndex].pNotes;
                }
                OnPropertyChanged();
            }
        }


        private void CreatePlayer()
        {
            var newPlayer = new PlayerModel
            {
                pId = Players.Count + 1,
                pName = CurPName,
                pPrefix = CurPPrefix,
                pPronouns = CurPPronouns,
                pMainName = CurPMainName,
                pDifficulty = CurPDifficulty,
                pCountry = CurPCountry,
                pJoinDate = CurPJoinDate,
                pLink = CurPLink,
                pIsAccountless = CurPIsAccountless,
                pNotes = CurPNotes,
            };
            Players.Add(newPlayer);
            newPlayer.pId = default(int);
            using (var context = new SmashTourneysDBContext())
            {
                context.Add(newPlayer);
                context.SaveChanges();
            }
        }

        public IQueryable<PlayerModel> ReadPlayer()
        {
            using (var context = new SmashTourneysDBContext())
            {
                return context.Players.ToList().AsQueryable();
            }
        }

        private void UpdatePlayer()
        {
            if (PSelectedIndex > -1 && PSelectedIndex < Players.Count)
            {
                CurPId = Players[PSelectedIndex].pId;
            }
            var playerToUpdateIndex = Players
                .IndexOf(Players.SingleOrDefault(x => x.pId == CurPId));

            if (playerToUpdateIndex >= 0)
            {
                var newPlayer = new PlayerModel
                {
                    pId = CurPId,
                    pName = CurPName,
                    pPrefix = CurPPrefix,
                    pPronouns = CurPPronouns,
                    pMainName = CurPMainName,
                    pDifficulty = CurPDifficulty,
                    pCountry = CurPCountry,
                    pJoinDate = CurPJoinDate,
                    pLink = CurPLink,
                    pIsAccountless = CurPIsAccountless,
                    pNotes = CurPNotes,
                };
                Players[playerToUpdateIndex] = newPlayer;
                using (var context = new SmashTourneysDBContext())
                {
                    var upd = context.Players.Where(x => x.pId == CurPId).Single();
                    upd.pName = newPlayer.pName; upd.pPrefix = newPlayer.pPrefix;
                    upd.pPronouns = newPlayer.pPronouns; upd.pMainName = newPlayer.pMainName;
                    upd.pDifficulty = newPlayer.pDifficulty; upd.pCountry = newPlayer.pCountry;
                    upd.pJoinDate = newPlayer.pJoinDate; upd.pLink = newPlayer.pLink;
                    upd.pIsAccountless = newPlayer.pIsAccountless; upd.pNotes = newPlayer.pNotes;
                    context.SaveChanges();
                }
            }
        }

        private void DeletePlayer()
        {
            if (PSelectedIndex > -1 && PSelectedIndex < Players.Count)
            {
                CurPId = Players[PSelectedIndex].pId;
            }
            var playerToRemove = Players.FirstOrDefault(x => x.pId == CurPId);
            if (playerToRemove != null)
            {
                Players.Remove(playerToRemove);
                using (var context = new SmashTourneysDBContext())
                {
                    context.Remove(context.Players.Where(x => x.pId == CurPId).Single());
                    context.SaveChanges();
                }
            }
        }



        // Players in Tournaments


        private ObservableCollection<PlayerInTourneyModel> _playersInTourneys;
        public ObservableCollection<PlayerInTourneyModel> PlayersInTourneys { get => _playersInTourneys; 
            set 
            {
                _playersInTourneys = value;
                if (TSelectedIndex > -1 && PSelectedIndex > -1)
                { // Gdy zostanie dodany nowy pośrednik między graczem a turniejem (gracz dodany do turnieju),
                  // to zostaną wyświetlone pośrednictwa przy danych turniejach czy graczach
                    PlayersInTourneys_ForT = new ObservableCollection<PlayerInTourneyModel>(PlayersInTourneys
                        .Where(x => x.tourney == Tourneys[TSelectedIndex]));
                    PlayersInTourneys_ForP = new ObservableCollection<PlayerInTourneyModel>(PlayersInTourneys
                        .Where(x => x.player == Players[PSelectedIndex]));
                }
                

                OnPropertyChanged();
            } 
        }

        private ObservableCollection<PlayerInTourneyModel> _playersInTourneys_ForT;
        public ObservableCollection<PlayerInTourneyModel> PlayersInTourneys_ForT 
        { get => _playersInTourneys_ForT; set { _playersInTourneys_ForT = value; OnPropertyChanged(); } }
        private ObservableCollection<PlayerInTourneyModel> _playersInTourneys_ForP;
        public ObservableCollection<PlayerInTourneyModel> PlayersInTourneys_ForP
        { get => _playersInTourneys_ForP; set { _playersInTourneys_ForP = value; OnPropertyChanged(); } }

        // Dwie kolekcje pośrednictw, jedne z danego turnieju, a drugie z danego gracza

        private int _curPitId;
        private TourneyModel _curTourney;
        private PlayerModel _curPlayer;
        private bool _curPitIsPlaying;
        private bool _curPitIsTO;
        private int _curPitSeeding;

        public int CurPitId{ get => _curPitId; set { _curPitId = value; OnPropertyChanged(); } }
        public TourneyModel CurTourney{ get => _curTourney; set { _curTourney = value; OnPropertyChanged(); } }
        public PlayerModel CurPlayer{ get => _curPlayer; set { _curPlayer = value; OnPropertyChanged(); } }
        public bool CurPitIsPlaying{ get => _curPitIsPlaying; set { _curPitIsPlaying = value; OnPropertyChanged(); } }
        public bool CurPitIsTO{ get => _curPitIsTO; set { _curPitIsTO = value; OnPropertyChanged(); } }
        public int CurPitSeeding{ get => _curPitSeeding; set { _curPitSeeding = value; OnPropertyChanged(); } }
        
        public ICommand PitCreateCommand { get; set; }
        public ICommand PitUpdateCommand { get; set; }
        public ICommand PitDeleteCommand { get; set; }
        public ICommand PitSelectCommand { get; set; }

        public bool Pit_ForT_last = true; // T
        // która lista (kolekcja) została ostatnio wybrana

        private int _pitSelectedIndex_ForT;
        public int PitSelectedIndex_ForT
        {
            get => _pitSelectedIndex_ForT; set
            {
                _pitSelectedIndex_ForT = value;
                if (PitSelectedIndex_ForT > -1 && PitSelectedIndex_ForT < PlayersInTourneys_ForT.Count)
                {
                    CurPitId = PlayersInTourneys_ForT[PitSelectedIndex_ForT].pitId;
                    CurTourney = PlayersInTourneys_ForT[PitSelectedIndex_ForT].tourney;
                    CurPlayer = PlayersInTourneys_ForT[PitSelectedIndex_ForT].player;
                    CurPitIsPlaying = PlayersInTourneys_ForT[PitSelectedIndex_ForT].pitIsPlaying;
                    CurPitIsTO = PlayersInTourneys_ForT[PitSelectedIndex_ForT].pitIsTO;
                    CurPitSeeding = (int)PlayersInTourneys_ForT[PitSelectedIndex_ForT].pitSeeding;
                }
                Pit_ForT_last = true;
                OnPropertyChanged();
            }
        }

        private int _pitSelectedIndex_ForP;
        public int PitSelectedIndex_ForP
        {
            get => _pitSelectedIndex_ForP; set
            {
                _pitSelectedIndex_ForP = value;
                if (PitSelectedIndex_ForP > -1 && PitSelectedIndex_ForP < PlayersInTourneys_ForP.Count)
                {
                    CurPitId = PlayersInTourneys_ForP[PitSelectedIndex_ForP].pitId;
                    CurTourney = PlayersInTourneys_ForP[PitSelectedIndex_ForP].tourney;
                    CurPlayer = PlayersInTourneys_ForP[PitSelectedIndex_ForP].player;
                    CurPitIsPlaying = PlayersInTourneys_ForP[PitSelectedIndex_ForP].pitIsPlaying;
                    CurPitIsTO = PlayersInTourneys_ForP[PitSelectedIndex_ForP].pitIsTO;
                    CurPitSeeding = (int)PlayersInTourneys_ForP[PitSelectedIndex_ForP].pitSeeding;
                }
                Pit_ForT_last = false;
                OnPropertyChanged();
            }
        }


        private void CreatePlayerInTourney()
        {
            var t = Tourneys[TSelectedIndex];
            var p = Players[PSelectedIndex];
            t.tId = default(int);
            p.pId = default(int);
            var newPlayerInTourney = new PlayerInTourneyModel
            {
                pitId = PlayersInTourneys.Count + 1,
                tourney = t,
                player = p,
                pitIsPlaying = CurPitIsPlaying,
                pitIsTO = CurPitIsTO,
                pitSeeding = CurPitSeeding,
            };
            PlayersInTourneys.Add(newPlayerInTourney);
            newPlayerInTourney.pitId = default(int);
            using (var context = new SmashTourneysDBContext())
            {
                context.Add(newPlayerInTourney);
                context.SaveChanges();
                PlayersInTourneys = PlayersInTourneys;
            }
        }

        public IQueryable<PlayerInTourneyModel> ReadPlayerInTourney()
        {
            using (var context = new SmashTourneysDBContext())
            {
                return context.PlayersInTourneys.ToList().AsQueryable();
            }
        }

        private void UpdatePlayerInTourney()
        {
            if (PitSelectedIndex_ForT > -1 && PitSelectedIndex_ForT < PlayersInTourneys_ForT.Count && Pit_ForT_last == true)
            {
                CurPitId = PlayersInTourneys_ForT[PitSelectedIndex_ForT].pitId;
            }
            if (PitSelectedIndex_ForP > -1 && PitSelectedIndex_ForP < PlayersInTourneys_ForP.Count && Pit_ForT_last == false)
            {
                CurPitId = PlayersInTourneys_ForP[PitSelectedIndex_ForP].pitId;
            }
            var playerInTourneyToUpdateIndex = PlayersInTourneys
                .IndexOf(PlayersInTourneys.SingleOrDefault(x => x.pitId == CurPitId));

            if (playerInTourneyToUpdateIndex >= 0)
            {
                var newPlayerInTourney = new PlayerInTourneyModel
                {
                    pitId = CurPitId,
                    pitIsPlaying = CurPitIsPlaying,
                    pitIsTO = CurPitIsTO,
                    pitSeeding = CurPitSeeding,
                };
                PlayersInTourneys[playerInTourneyToUpdateIndex] = newPlayerInTourney;
                using (var context = new SmashTourneysDBContext())
                {
                    var upd = context.PlayersInTourneys.Where(x => x.pitId == CurPitId).Single();
                    upd.pitId = newPlayerInTourney.pitId; upd.pitIsPlaying = newPlayerInTourney.pitIsPlaying;
                    upd.pitIsTO = newPlayerInTourney.pitIsTO; upd.pitSeeding = newPlayerInTourney.pitSeeding;
                    context.SaveChanges();
                }
            }
        }

        private void DeletePlayerInTourney()
        {
            if (PitSelectedIndex_ForT > -1 && PitSelectedIndex_ForT < PlayersInTourneys_ForT.Count && Pit_ForT_last == true)
            {
                CurPitId = PlayersInTourneys_ForT[PitSelectedIndex_ForT].pitId;
            }
            if (PitSelectedIndex_ForP > -1 && PitSelectedIndex_ForP < PlayersInTourneys_ForP.Count && Pit_ForT_last == false)
            {
                CurPitId = PlayersInTourneys_ForP[PitSelectedIndex_ForP].pitId;
            }
            var playerInTourneyToRemove = PlayersInTourneys.FirstOrDefault(x => x.pitId == CurPitId);
            if (playerInTourneyToRemove != null)
            {
                PlayersInTourneys.Remove(playerInTourneyToRemove);
                using (var context = new SmashTourneysDBContext())
                {
                    context.Remove(context.PlayersInTourneys.Where(x => x.pitId == CurPitId).Single());
                    context.SaveChanges();
                }
            }
        }
    }

}
