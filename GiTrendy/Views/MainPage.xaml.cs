using GiTrendy.ViewModels;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GiTrendy.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MainPageViewModel _viewModel;
        public MainPage()
        {
            this.InitializeComponent();
            DataContext = _viewModel = new MainPageViewModel();
        }

        private void Flyout_Closed(object sender, object e)
        {
            _viewModel.LoadTrendingsCommand.Execute();
        }
    }
}
