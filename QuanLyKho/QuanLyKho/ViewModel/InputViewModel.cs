using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKho.Model;
using System.Windows.Input;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace QuanLyKho.ViewModel
{
    public class InputViewModel : BaseViewModel
    {
        private ObservableCollection<Model.InputInfo> _List;
        public ObservableCollection<Model.InputInfo> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private Model.InputInfo _SelectedItem;
        public Model.InputInfo SelectedItem
        {
            get => _SelectedItem; set
            {
                _SelectedItem = value; OnPropertyChanged();
                if (SelectedItem != null)
                {
                    SelectedItem_Input = SelectedItem.Input;
                    SelectedItem_Object = SelectedItem.Object;
                    Price_Input = SelectedItem.Price_Input;
                    Price_Output = SelectedItem.Price_Output;
                    Count = SelectedItem.Count.ToString();
                    Status_Input = SelectedItem.Status_InputInfo;
                }
            }
        }

        private Input _SelectedItem_Input;
        public Input SelectedItem_Input
        {
            get => _SelectedItem_Input; set
            {
                _SelectedItem_Input = value;
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
        private string _Count;
        public string Count { get => _Count; set { _Count = value; OnPropertyChanged(); } }

        private double? _Price_Input;
        public double? Price_Input { get => _Price_Input; set { _Price_Input = value; OnPropertyChanged(); } }
        private double? _Price_Output;
        public double? Price_Output { get => _Price_Output; set { _Price_Output = value; OnPropertyChanged(); } }

        private string _Status_Input;
        public string Status_Input { get => _Status_Input; set { _Status_Input = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public InputViewModel()
        {
            List = new ObservableCollection<Model.InputInfo>(DataProvider.Ins.DB.InputInfoes);
            AddCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem_Input == null || SelectedItem_Object == null)
                    return false;
                return true;
            }, (p) =>
            {
                var InputInfo = new Model.InputInfo() { Price_Input = SelectedItem.Price_Input, Price_Output = SelectedItem.Price_Output, Count = SelectedItem.Count, Status_InputInfo = SelectedItem.Status_InputInfo, Id_Object = SelectedItem_Object.Id_Object, Id_Input = SelectedItem_Input.Id_Input };

                DataProvider.Ins.DB.InputInfoes.Add(InputInfo);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(InputInfo);
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null || SelectedItem_Input == null || SelectedItem_Object == null || string.IsNullOrEmpty(Count) || Price_Input == null || Price_Output == null)
                    return false;

                var existingInputInfo = DataProvider.Ins.DB.InputInfoes.SingleOrDefault(x => x.Id_InputInfo == SelectedItem.Id_InputInfo);
                return existingInputInfo != null;
            }, (p) =>
            {
                var existingInputInfo = DataProvider.Ins.DB.InputInfoes.SingleOrDefault(x => x.Id_InputInfo == SelectedItem.Id_InputInfo);
                if (existingInputInfo != null)
                {
                    // Cập nhật thông tin
                    existingInputInfo.Id_Object = SelectedItem_Object.Id_Object;
                    existingInputInfo.Id_Input = SelectedItem_Input.Id_Input;
                    existingInputInfo.Price_Input = Price_Input;
                    existingInputInfo.Price_Output = Price_Output;
                    existingInputInfo.Count = int.Parse(Count);
                    existingInputInfo.Status_InputInfo = Status_Input;

                    // Lưu thay đổi vào cơ sở dữ liệu
                    DataProvider.Ins.DB.SaveChanges();

                    // Cập nhật lại ObservableCollection
                    int index = List.IndexOf(SelectedItem);
                    List[index] = existingInputInfo;
                    OnPropertyChanged(nameof(List));
                }
            });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                return SelectedItem != null;
            }, (p) =>
            {
                var inputInfoToDelete = DataProvider.Ins.DB.InputInfoes.SingleOrDefault(x => x.Id_InputInfo == SelectedItem.Id_InputInfo);
                if (inputInfoToDelete != null)
                {
                    // Xóa khỏi cơ sở dữ liệu
                    DataProvider.Ins.DB.InputInfoes.Remove(inputInfoToDelete);
                    DataProvider.Ins.DB.SaveChanges();

                    // Xóa khỏi ObservableCollection
                    List.Remove(SelectedItem);
                    SelectedItem = null; // Hủy chọn
                }
            });
        }
    }
}