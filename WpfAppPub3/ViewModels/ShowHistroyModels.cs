using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppPub3.Models;

namespace WpfAppPub3.ViewModels
{
    public class ShowHistroyModels:BaseViewModels
    {
        private ObservableCollection<Payment> allPayments;

        public ObservableCollection<Payment> AllPayments
        {
            get { return allPayments; }
            set { allPayments = value; OnPropertyChanged(); }
        }
    }
}
