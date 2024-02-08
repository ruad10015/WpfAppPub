using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAppPub3.Command;
using WpfAppPub3.Models;

namespace WpfAppPub3.ViewModels
{
    public class MainViewModels:BaseViewModels
    {
        private ObservableCollection<Beer> allBeers;

        private ObservableCollection<Payment> allPayments;

        public ObservableCollection<Payment> AllPayments
        {
            get { return allPayments; }
            set { allPayments = value; OnPropertyChanged(); }
        }


        public ObservableCollection<Beer> AllBeers
        {
            get { return allBeers; }
            set { allBeers = value; OnPropertyChanged(); }
        }

        private Beer selectedBeer;
        public Beer SelectedBeer
        {
            get { return selectedBeer; }
            set {  selectedBeer = value; OnPropertyChanged(); }
        }

        private string selectedBeerName;
        public string SelectedBeerName
        {
            get { return selectedBeerName; }
            set { selectedBeerName = value; OnPropertyChanged(); }
        }

        private double selectedBeerPrice;
        public double SelectedBeerPrice
        {
            get { return selectedBeerPrice; }
            set { selectedBeerPrice = value; OnPropertyChanged(); }
        }

        private double selectedBeerVolume;
        public double SelectedBeerVolume
        {
            get { return selectedBeerVolume; }
            set { selectedBeerVolume = value; OnPropertyChanged(); }
        }

        private string selectedBeerImage;
        public string SelectedBeerImage
        {
            get { return selectedBeerImage; }
            set { selectedBeerImage = value; OnPropertyChanged(); }
        }

        private double selectedBeerTotal;
        public double SelectedBeerTotal
        {
            get { return selectedBeerTotal; }
            set { selectedBeerTotal = value; OnPropertyChanged(); }
        }

        private int selectedBeerCount;
        public int SelectedBeerCount
        {
            get { return selectedBeerCount; }
            set { selectedBeerCount = value; OnPropertyChanged(); }
        }

        public RelayCommand IncreaseCommand {  get; set; }
        public RelayCommand DecreaseCommand {  get; set; }
        public RelayCommand BuyCommand { get; set; }
        public RelayCommand ShowCommand { get; set; }
        public RelayCommand ResetCommand { get; set; }

        public MainViewModels()
        {

            AllBeers = new ObservableCollection<Beer>()
            {
                new Beer{ Name="Corona",Price=5.50,Volume=0.33,Count=0,Image="/Images/beer5.jpg"},
                new Beer{ Name="Erdinger",Price=7.50,Volume=0.50,Count=0,Image="/Images/erdinger2.jpg"},
                new Beer{ Name="Stella", Price=6.00, Volume=0.5, Count=0, Image="/Images/stella3.jpg"},
                new Beer{ Name="Stout", Price=6.50, Volume=0.33, Count=0, Image="/Images/stout.jpg"},
                new Beer{ Name="Heineken", Price=4.50, Volume=0.33, Count=0, Image="/Images/heineken2.jpg"},
            };

            SelectedBeer = AllBeers[0];
            AllPayments = new ObservableCollection<Payment>();

            IncreaseCommand = new RelayCommand((obj) =>
            {
                SelectedBeer.Count++;
                SelectedBeerCount = SelectedBeer.Count;
                SelectedBeerTotal = SelectedBeer.Count * SelectedBeer.Price;
            });

            DecreaseCommand = new RelayCommand((obj) =>
            {
                if(SelectedBeer.Count > 0)
                SelectedBeer.Count--;
                SelectedBeerCount= SelectedBeer.Count;
                SelectedBeerTotal=SelectedBeer.Count*SelectedBeer.Price;
            });

            BuyCommand = new RelayCommand((obj) =>
            {
                SelectedBeerName = SelectedBeer.Name; // Set the SelectedBeerName
                var payment = new Payment
                {
                    Name = SelectedBeerName,
                    Price = SelectedBeer.Price,
                    Volume = SelectedBeer.Volume,
                    Count = SelectedBeerCount,
                };
                AllPayments.Add(payment);
                MessageBox.Show($"You bought {SelectedBeerCount} {SelectedBeerName} for a total of {SelectedBeerTotal:C2}");
            });

            ShowCommand = new RelayCommand((obj) =>
            {

                var vm = new ShowHistroyModels();
                vm.AllPayments = AllPayments;
                var view = new ShowHistory();

                view.DataContext = vm;
                view.Show();
            });

            ResetCommand = new RelayCommand((obj) =>
            {
                SelectedBeer.Count = 0;
                SelectedBeerCount = 0;
                SelectedBeerTotal = 0;
                SelectedBeer = AllBeers[0];
            });
        }
    }
}
