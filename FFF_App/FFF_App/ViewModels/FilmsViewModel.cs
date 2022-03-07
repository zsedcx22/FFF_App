using FFF_App.Models;
using FFF_App.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FFF_App.ViewModels
{
    public class FilmsViewModel : BaseViewModel
    {
        private Film _selectedFilm;

        public ObservableCollection<Film> Films { get; }
        public ICommand LoadFilmsCommand { get; }
        public Command<Film> FilmTapped { get; }

        public FilmsViewModel()
        {
            Title = "Browse";
            Films = new ObservableCollection<Film>();
            ExecuteLoadFilmsCommand();
            LoadFilmsCommand = new Command(async () => await ExecuteLoadFilmsCommand());
            FilmTapped = new Command<Film>(OnFilmSelected);

        }

        async Task ExecuteLoadFilmsCommand()
        {
            IsBusy = true;

            try
            {
                Films.Clear();
                var films = await ScreeningDataStore.GetFilmsAsync();
                foreach (Film film in films)
                {
                    Films.Add(film);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedFilm = null;
        }

        public Film SelectedFilm
        {
            get => _selectedFilm;
            set
            {
                
                SetProperty(ref _selectedFilm, value);
                OnFilmSelected(value);
            }
        }

        async void OnFilmSelected(Film film)
        {
            if (film == null)
                return;

            // This will push the FilmDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(FilmDetailPage)}?{nameof(FilmScreeningViewModel.FilmName)}={film.FilmNameEnglish}");
        }
    }
}
