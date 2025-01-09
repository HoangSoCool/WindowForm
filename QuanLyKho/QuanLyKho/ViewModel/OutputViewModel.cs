using QuanLyKho.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace QuanLyKho.ViewModel
{
    public class OutputViewModel : BaseViewModel
    {
        private ObservableCollection<Model.OutputInfo> _List;
        public ObservableCollection<Model.OutputInfo> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private ObservableCollection<Customer> _Customer;
        public ObservableCollection<Customer> Customer { get => _Customer; set { _Customer = value; OnPropertyChanged(); } }
        private Model.OutputInfo _SelectedItem;
        public Model.OutputInfo SelectedItem
        {
            get => _SelectedItem; set
            {
                _SelectedItem = value; OnPropertyChanged();
                if (SelectedItem != null)
                {
                    SelectedItem_Output = SelectedItem.Output;
                    SelectedItem_Object = SelectedItem.Object;
                    SelectedItem_InputInfo = SelectedItem.Object.InputInfoes.FirstOrDefault();
                    SelectedItem_Customer = SelectedItem.Customer;
                    Count = SelectedItem.Count.ToString();
                    Status_Output = SelectedItem.Status_OutputInfo;
                }
            }
        }

        private Output _SelectedItem_Output;
        public Output SelectedItem_Output
        {
            get => _SelectedItem_Output; set
            {
                _SelectedItem_Output = value;
                OnPropertyChanged();
            }
        }

        private InputInfo _SelectedItem_InputInfo;
        public InputInfo SelectedItem_InputInfo
        {
            get => _SelectedItem_InputInfo; set
            {
                _SelectedItem_InputInfo = value;
                OnPropertyChanged();
            }
        }

        private Model.Object _SelectedItem_Object;
        public Model.Object SelectedItem_Object
        {
            get => _SelectedItem_Object; set
            {
                _SelectedItem_Object = value;
                OnPropertyChanged();
            }
        }

        private Model.Customer _SelectedItem_Customer;
        public Model.Customer SelectedItem_Customer
        {
            get => _SelectedItem_Customer; set
            {
                _SelectedItem_Customer = value;
                OnPropertyChanged();
            }
        }
        private string _Count;
        public string Count { get => _Count; set { _Count = value; OnPropertyChanged(); } }

        private string _Status_Output;
        public string Status_Output { get => _Status_Output; set { _Status_Output = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public OutputViewModel()
        {
            List = new ObservableCollection<Model.OutputInfo>(DataProvider.Ins.DB.OutputInfoes);
            Customer = new ObservableCollection<Model.Customer>(DataProvider.Ins.DB.Customers);
            AddCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem_Output == null || SelectedItem_Object == null)
                    return false;
                return true;
            }, (p) =>
            {
                var OutputInfo = new Model.OutputInfo() { Count = SelectedItem.Count, Status_OutputInfo = SelectedItem.Status_OutputInfo, Id_Customer = SelectedItem_Customer.Id_Customer, Id_Object = SelectedItem_Object.Id_Object, Id_Output = SelectedItem_Output.Id_Output};

                DataProvider.Ins.DB.OutputInfoes.Add(OutputInfo);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(OutputInfo);
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null || SelectedItem_Output == null || SelectedItem_Object == null)
                    return false;

                var displayList = DataProvider.Ins.DB.OutputInfoes.Where(x => x.Id_OutputInfo == SelectedItem.Id_OutputInfo);
                if (displayList != null && displayList.Count() != 0)
                    return true;
                return false;

            }, (p) =>
            {
                var OutputInfo = DataProvider.Ins.DB.OutputInfoes.Where(x => x.Id_OutputInfo == SelectedItem.Id_OutputInfo).SingleOrDefault();
                OutputInfo.Id_Object = SelectedItem_Object.Id_Object;
                OutputInfo.Id_Output = SelectedItem_Output.Id_Output;
                OutputInfo.Id_Customer = SelectedItem_Customer.Id_Customer;
                OutputInfo.Count = int.Parse(Count);
                OutputInfo.Status_OutputInfo = Status_Output;
                DataProvider.Ins.DB.SaveChanges();
            });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                return SelectedItem != null;
            }, (p) =>
            {
                // Kiểm tra nếu có mục được chọn
                var outputInfoToDelete = DataProvider.Ins.DB.OutputInfoes.SingleOrDefault(x => x.Id_OutputInfo == SelectedItem.Id_OutputInfo);
                if (outputInfoToDelete != null)
                {
                    // Xóa khỏi cơ sở dữ liệu
                    DataProvider.Ins.DB.OutputInfoes.Remove(outputInfoToDelete);
                    DataProvider.Ins.DB.SaveChanges();

                    // Xóa khỏi ObservableCollection
                    List.Remove(SelectedItem);

                    // Hủy chọn item sau khi xóa
                    SelectedItem = null;
                }
            });
        }
    }
}