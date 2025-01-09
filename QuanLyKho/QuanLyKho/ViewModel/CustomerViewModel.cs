using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKho.Model;
using System.Windows.Input;

namespace QuanLyKho.ViewModel
{
    public class CustomerViewModel : BaseViewModel
    {
        private ObservableCollection<Customer> _List;
        public ObservableCollection<Customer> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private Customer _SelectedItem;
        public Customer SelectedItem
        {
            get => _SelectedItem; set
            {
                _SelectedItem = value; OnPropertyChanged();
                if (SelectedItem != null)
                {
                    DisplayName = SelectedItem.DisplayName_Customer;
                    Phone = SelectedItem.Phone_Customer;
                    Address = SelectedItem.Address_Customer;
                    Email = SelectedItem.Email_Customer;
                    MoreInfo = SelectedItem.MoreInfo_Customer;
                    ContractDate = SelectedItem.ContractDate_Customer;
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

        public CustomerViewModel()
        {
            List = new ObservableCollection<Customer>(DataProvider.Ins.DB.Customers);
            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                var Customer = new Customer() { DisplayName_Customer = DisplayName, Address_Customer = Address, Phone_Customer = Phone, Email_Customer = Email, MoreInfo_Customer = MoreInfo, ContractDate_Customer = ContractDate };

                DataProvider.Ins.DB.Customers.Add(Customer);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(Customer);
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.Customers.Where(x => x.Id_Customer == SelectedItem.Id_Customer);
                if (displayList != null && displayList.Count() != 0)
                    return true;
                return false;

            }, (p) =>
            {
                var Customer = DataProvider.Ins.DB.Customers.Where(x => x.Id_Customer == SelectedItem.Id_Customer).SingleOrDefault();
                Customer.DisplayName_Customer = DisplayName;
                Customer.Address_Customer = Address;
                Customer.Phone_Customer = Phone;
                Customer.Email_Customer = Email;
                Customer.MoreInfo_Customer = MoreInfo;
                Customer.ContractDate_Customer = ContractDate;
                DataProvider.Ins.DB.SaveChanges();
                SelectedItem.DisplayName_Customer = DisplayName;
            });

            // Command Xóa
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                // Kiểm tra xem có khách hàng nào được chọn không
                return SelectedItem != null;
            }, (p) =>
            {
                // Xóa khách hàng khỏi cơ sở dữ liệu
                var customerToDelete = DataProvider.Ins.DB.Customers.Where(x => x.Id_Customer == SelectedItem.Id_Customer).SingleOrDefault();
                if (customerToDelete != null)
                {
                    DataProvider.Ins.DB.Customers.Remove(customerToDelete);
                    DataProvider.Ins.DB.SaveChanges();

                    // Cập nhật lại danh sách khách hàng
                    List.Remove(customerToDelete);
                }
            });
        }
    }
}