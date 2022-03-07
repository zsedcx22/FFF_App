using FFF_App.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using System.Data.SqlClient;

namespace FFF_App.Services
{
    public class ScreeningDataStore : IScreeningDataStore<Screening>
    {
        readonly List<Screening> screenings;

        public static UserCredential GetCredential()
        {
            return null;
        }

        public ScreeningDataStore()
        {
            string connectionString = @"Server=.;Database=master;Trusted_Connection=true";
            string databaseTable = "dbo.films";
            string selectQuery = String.Format("SELECT * FROM dbo.screenings LEFT JOIN dbo.films ON dbo.screenings.FilmID = dbo.films.ID LEFT JOIN dbo.venues ON dbo.screenings.FilmID = dbo.venues.ID");
            using ( SqlConnection connection = new SqlConnection(connectionString))
            /*SheetsService sheetsService = new SheetsService(new BaseClientService.Initializer
            {
                HttpClientInitializer = GetCredential(),
                ApplicationName = x
            });
            var gSheetData = ;*/


            //from list of screenings create records for each and make a film list also?


            screenings = new List<Screening>();
            /*
            DriveService driveService = new DriveService();
            var request = driveService.Files.List();
            request.Q = "mimeType='image/jpeg'";
            request.OauthToken = account.Properties["access_token"];
            request.Fields = "nextPageToken,files(id, name, thumbnailLink, webViewLink)";
            request.PageToken = pageToken;
            request.PageSize = 20;
            var result = request.Execute();
            var DrivePhotos = new ObservableCollection<object>(result.Files);
            */

            screenings.Add(new Screening() { Cast = new List<string>() { "Bruce Spelt", "Ingrid Prolch" }, Cinema = "Filmhouse Cinema", Country = "France", Director = "Timothy Draik", FilmNameEnglish = "Two Cities", FilmNameFrench = "Deux Villes", HasQAndA = true, Quote = "Great Film!", Rating = "N/C 15", RunningTime = 123, ScreeningDateAndTime = new DateTime(2021, 11, 11, 14, 30, 0), Section = "Panorama", Synopsis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", Year = 2020 });
            screenings.Add(new Screening() { Cast = new List<string>() { "Bruce Spelt", "Ingrid Prolch" }, Cinema = "Filmhouse Cinema", Country = "France", Director = "Timothy Draik", FilmNameEnglish = "Two Cities", FilmNameFrench = "Deux Villes", HasQAndA = false, Quote = "Great Film!", Rating = "N/C 15", RunningTime = 123, ScreeningDateAndTime = new DateTime(2021, 11, 22, 18, 30, 0), Section = "Panorama", Synopsis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", Year = 2020 });
            screenings.Add(new Screening() { Cast = new List<string>() { "Bruce Spelt", "Ingrid Prolch" }, Cinema = "Filmhouse Cinema", Country = "France", Director = "Timothy Draik", FilmNameEnglish = "City Dwellers", FilmNameFrench = "Les Citadins", HasQAndA = false, Quote = "Greater Film!", Rating = "N/C 15", RunningTime = 111, ScreeningDateAndTime = new DateTime(2021, 11, 17, 12, 30, 0), Section = "Discovery", Synopsis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", Year = 2021 });
            screenings.Add(new Screening() { Cast = new List<string>() { "Bruce Spelt", "Ingrid Prolch" }, Cinema = "Filmhouse Cinema", Country = "France", Director = "Timothy Draik", FilmNameEnglish = "City Dwellers", FilmNameFrench = "Les Citadins", HasQAndA = true, Quote = "Greater Film!", Rating = "N/C 15", RunningTime = 111, ScreeningDateAndTime = new DateTime(2021, 11, 30, 19, 30, 0), Section = "Discovery", Synopsis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", Year = 2021 });
            screenings.Add(new Screening() { Cast = new List<string>() { "Bruce Spelt", "Ingrid Prolch" }, Cinema = "Filmhouse Cinema", Country = "France", Director = "Timothy Draik", FilmNameEnglish = "The Long Run Over", FilmNameFrench = "La Course Longe", HasQAndA = true, Quote = "Greatest Film!", Rating = "N/C 15", RunningTime = 92, ScreeningDateAndTime = new DateTime(2021, 11, 18, 10, 30, 0), Section = "Panorama", Synopsis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", Year = 2019 });
        }
        public async Task<IEnumerable<Screening>> GetAllItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Film>> GetFilmsAsync()//this gets and returns a list of each individual film
        {
            List<Film> films = new List<Film>();
            foreach(Screening s in screenings)
            { //take each film's details and put it into a separate list
                films.Add(new Film()
                {
                    Cast = s.Cast,
                    Country = s.Country,
                    Director = s.Director,
                    FilmNameEnglish = s.FilmNameEnglish,
                    FilmNameFrench = s.FilmNameFrench,
                    Rating = s.Rating,
                    HasQAndA = s.HasQAndA,
                    Quote = s.Quote,
                    RunningTime = s.RunningTime,
                    Section = s.Section,
                    Synopsis = s.Synopsis,
                    Year = s.Year
                });
            }
            List<Film> result = new List<Film>();
            foreach(Film f in films)
            {
                var temp = result.Find(e => e.FilmNameEnglish == f.FilmNameEnglish);
                if (temp == null)
                {
                    result.Add(f); //change this to another loop - messy for now will clarify it later
                }
            }    
            /*var x = films.Distinct().ToList();
            var result = await Task.FromResult(films.Distinct().ToList());*/
            return await Task.FromResult(result);//returns the list
        }

        public async Task<IEnumerable<Screening>> GetItemsByDateAsync(DateTime date)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Screening>> GetItemsByLocationAsync(string venue)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Screening>> GetItemsByNameAsync(string name)
        {
            List<Screening> tScreenings = new List<Screening>();
            foreach(Screening s in screenings)
            {
                if(s.FilmNameEnglish == name)
                {
                    tScreenings.Add(s);
                }
            }
            return await Task.FromResult(tScreenings);
        }


    }
}
