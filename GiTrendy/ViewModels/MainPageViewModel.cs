using GiTrendy.Models;
using ReactiveUI;
using Refit;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;

namespace GiTrendy.ViewModels
{
    public class MainPageViewModel : ReactiveObject
    {
        private GitProgLanguages _selectedProgLang;
        public GitProgLanguages SelectedProgLang { get => _selectedProgLang; set => this.RaiseAndSetIfChanged(ref _selectedProgLang, value); }

        private string _selectedTime = TimeConsts.Daily;
        public string SelectedTime { get => _selectedTime; set => this.RaiseAndSetIfChanged(ref _selectedTime, value); }

        private SpeakLang _selectedSpeakLang;
        public SpeakLang SelectedSpeakLang { get => _selectedSpeakLang; set => this.RaiseAndSetIfChanged(ref _selectedSpeakLang, value); }


        private readonly IGitTrendingAPI _api;

        public List<string> TimeRanges { get; set; } = TimeConsts.GetTimeRangeList();
        public List<SpeakLang> SpeakLangs { get; set; }
        public ObservableCollection<GitTrending> Trendings { get; set; } = new ObservableCollection<GitTrending>();
        public List<GitProgLanguages> ProgLangs { get; set; }
        public ReactiveCommand<Unit, Unit> LoadTrendingsCommand { get; }
        public ReactiveCommand<Unit, Unit> LoadProgLangsCommand { get; }

        public MainPageViewModel()
        {
            _selectedProgLang = new GitProgLanguages() { name = "Any", urlParam = "" };
            ProgLangs = new List<GitProgLanguages>();
            ProgLangs.Add(_selectedProgLang);

            SpeakLangs = SpeakLang.GetAvailableSpeakingLangs();
            _selectedSpeakLang = SpeakLangs[0];
            _api = RestService.For<IGitTrendingAPI>("https://gitrendy.herokuapp.com/");

            LoadProgLangsCommand = ReactiveCommand.CreateFromTask(LoadProgLangs);
            LoadProgLangsCommand.Execute();

            LoadTrendingsCommand = ReactiveCommand.CreateFromTask(LoadTrending);
            LoadTrendingsCommand.Execute();
        }

        private async Task LoadTrending()
        {
            var resp = await _api.GetTrending(_selectedProgLang.name == "Any" ? "" : SelectedProgLang.name, SelectedTime, SelectedSpeakLang.ShortName);
            Trendings.Clear();
            foreach (var i in resp.OrderByDescending(x => x.currentPeriodStars))
                Trendings.Add(i);
        }

        private async Task LoadProgLangs()
        {
            if (ProgLangs.Count != 1)
                return;

            var resp = await _api.GetProgLangs();
            foreach (var i in resp)
                ProgLangs.Add(i);
        }
    }
}
