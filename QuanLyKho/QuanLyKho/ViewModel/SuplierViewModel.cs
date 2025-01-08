using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKho.Model;
using System.Windows.Input;
using System.Windows.Documents;
using System.Net;
using System.Security.Policy;

namespace QuanLyKho.ViewModel
{
    public class SuplierViewModel : BaseViewModel
    {
        private ObservableCollection<Suplier> _List;
        public ObservableCollection<Suplier> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private Suplier _SelectedItem;
        public Suplier SelectedItem
        {
            get => _SelectedItem; set
            {
                _SelectedItem = value; OnPropertyChanged();
                if (SelectedItem != null)
                {
                    DisplayName = SelectedItem.DisplayName_Suplier;
                    Phone = SelectedItem.Phone_Suplier;
                    Address = SelectedItem.Address_Suplier;
                    Email = SelectedItem.Email_Suplier;
                    MoreInfo = SelectedItem.MoreInfo_Suplier;
                    ContractDate = SelectedItem.ContractDate_Suplier;
                }
            }
        }
        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }

        private string _Phone;
        public string Phone { get => _Phone; set { _Phone = value; OnPropertyChanged(); } }

        private string _Address;
        public string Address { get => _Address; set { _Address = value; OnPropertyChanged(); } }

        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }

        private string _MoreInfo;
        public string MoreInfo { get => _MoreInfo; set { _MoreInfo = value; OnPropertyChanged(); } }

        private DateTime? _ContractDate;
        public DateTime? ContractDate { get => _ContractDate; set { _ContractDate = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public SuplierViewModel()
        {
            List = new ObservableCollection<Suplier>(DataProvider.Ins.DB.Supliers);
            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                var Suplier = new Suplier() { DisplayName_Suplier = DisplayName, Address_Suplier = Address, Phone_Suplier = Phone, Email_Suplier = Email, MoreInfo_Suplier = MoreInfo, ContractDate_Suplier = ContractDate };

                DataProvider.Ins.DB.Supliers.Add(Suplier);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(Suplier);
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.Supliers.Where(x => x.Id_Suplier == SelectedItem.Id_Suplier);
                if (displayList != null && displayList.Count() != 0)
                    return true;
                return false;

            }, (p) =>
            {
                var Suplier = DataProvider.Ins.DB.Supliers.Where(x => x.Id_Suplier == SelectedItem.Id_Suplier).SingleOrDefault();
                Suplier.DisplayName_Suplier = DisplayName;
                Suplier.Address_Suplier = Address;
                Suplier.Phone_Suplier = Phone;
                Suplier.Email_Suplier = Email;
                Suplier.MoreInfo_Suplier = MoreInfo;
                Suplier.ContractDate_Suplier = ContractDate;
                DataProvider.Ins.DB.SaveChanges();
                SelectedItem.DisplayName_Suplier = DisplayName;
            });
        }
    }
}