using FFF_App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FFF_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilmDetailPage : ContentPage
    {
        public FilmDetailPage()
        {
            InitializeComponent();
            BindingContext = new FilmScreeningViewModel();
        }
    }
}