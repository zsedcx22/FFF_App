using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;
using Xamarin.Forms;
using FFF_App.Models;

namespace FFF_App.ViewModels
{
    [QueryProperty(nameof(FilmName), nameof(FilmName))]
    class FilmScreeningViewModel : BaseViewModel
    {
        private string image;//link to the image
        private string filmName;//film name in English
        private string filmNameFrench;//film name in French
        private string section;//category of film as divided on the French Film Festival website
        private string cast;//cast of the film
        private string rating;//the age rating given to the film
        private string director;//the director of the film
        private int year;//year of release of the film
        private string country;//country of origin of the film
        private int runningTime;//running time of the film in minutes
        private string synopsis;//short synopsis of the film
        private string quote;//quotes associated with the film (press etc)
        private bool hasQAndA;//if the film in particular has a Q&A at the end

        private List<Screening> filmScreenings;//list of all of the screenings involved in the festival
        public string FilmName
        {
            get
            {
                return filmName;
            }
            set
            {
                filmName = value;
                LoadFilmName(value);
            }
        }
        public string FilmNameFrench
        {
            get => filmNameFrench;
            set => SetProperty(ref filmNameFrench, value);
        }

        public string Section
        {
            get => section;
            set => SetProperty(ref section, value);
        }

        public string Cast
        {
            get => cast;
            set => SetProperty(ref cast, value);
        }

        public string Rating
        {
            get => rating;
            set => SetProperty(ref rating, value);
        }

        public string Director
        {
            get => director;
            set => SetProperty(ref director, value);
        }

        public int Year
        {
            get => year;
            set => SetProperty(ref year, value);
        }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
        public string Country
        {
            get => country;
            set => SetProperty(ref country, value);
        }

        public int RunningTime
        {
            get => runningTime;
            set => SetProperty(ref runningTime, value);
        }

        public string Synopsis
        {
            get => synopsis;
            set => SetProperty(ref synopsis, value);
        }

        public string Quote
        {
            get => quote;
            set => SetProperty(ref quote, value);
        }

        public bool HasQAndA
        {
            get => hasQAndA;
            set => SetProperty(ref hasQAndA, value);
        }

        public string Image
        {
            get => image;
            set => SetProperty(ref image, value);
        }

        public List<Screening> FilmScreenings
        {
            get => filmScreenings;
            set => SetProperty(ref filmScreenings, value);
        }

        public async void LoadFilmName(string filmName)//for each film the view obtains the information from this function
        {
            try
            {
                var films = await ScreeningDataStore.GetFilmsAsync();
                var filmList = films.ToList();
                var film = filmList.Find(e => e.FilmNameEnglish == filmName);

                var screenings = await ScreeningDataStore.GetItemsByNameAsync(film.FilmNameEnglish);
                var screeningList = screenings.ToList();

                FilmScreenings = screeningList;

                FilmName = film.FilmNameEnglish;
                FilmNameFrench = film.FilmNameFrench;
                Section = film.Section;
                Cast = string.Join(", ", film.Cast);
                Rating = film.Rating;
                Director = film.Director;
                Year = film.Year;
                Country = film.Country;
                RunningTime = film.RunningTime;
                Synopsis = film.Synopsis;
                Quote = film.Quote;
                HasQAndA = film.HasQAndA;

            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Film");
            }
        }
    }
}
