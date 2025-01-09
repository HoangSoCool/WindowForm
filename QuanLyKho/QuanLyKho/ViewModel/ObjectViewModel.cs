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
    public class ObjectViewModel : BaseViewModel
    {
        private ObservableCollection<Model.Object> _List;
        public ObservableCollection<Model.Object> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private ObservableCollection<Unit> _Unit;
        public ObservableCollection<Unit> Unit { get => _Unit; set { _Unit = value; OnPropertyChanged(); } }

        private ObservableCollection<Suplier> _Suplier;
        public ObservableCollection<Suplier> Suplier { get => _Suplier; set { _Suplier = value; OnPropertyChanged(); } }

        private Model.Object _SelectedItem;
        public Model.Object SelectedItem
        {
            get => _SelectedItem; set
            {
                _SelectedItem = value; OnPropertyChanged();
                if (SelectedItem != null)
                {
                    DisplayName = SelectedItem.DisplayName_Object;
                    SelectedItem_Unit = SelectedItem.Unit;
                    SelectedItem_Suplier = SelectedItem.Suplier;
                    QRCode = SelectedItem.QRCode;
                    BarCode = SelectedItem.BarCode;
                }
            }
        }

        private Unit _SelectedItem_Unit;
        public Unit SelectedItem_Unit
        {
            get => _SelectedItem_Unit; set
            {
                _SelectedItem_Unit = value;
                OnPropertyChanged();
            }
        }
        private Suplier _SelectedItem_Suplier;
        public Suplier SelectedItem_Suplier
        {
            get => _SelectedItem_Suplier; set
            {
                _SelectedItem_Suplier = value;
                OnPropertyChanged();
            }
        }

        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }

        private string _QRCode;
        public string QRCode { get => _QRCode; set { _QRCode = value; OnPropertyChanged(); } }

        private string _BarCode;
        public string BarCode { get => _BarCode; set { _BarCode = value; OnPropertyChanged(); } }
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public ObjectViewModel()
        {
            List = new ObservableCollection<Model.Object>(DataProvider.Ins.DB.Objects);
            Unit = new ObservableCollection<Unit>(DataProvider.Ins.DB.Units);
            Suplier = new ObservableCollection<Suplier>(DataProvider.Ins.DB.Supliers);
            AddCommand = new RelayCommand<object>((p) =>
            {
                if(SelectedItem_Unit == null || SelectedItem_Suplier == null)
                    return false;
                return true;
            }, (p) =>
            {
                var Object = new Model.Object() { Id_Object = Guid.NewGuid().ToString(),DisplayName_Object = DisplayName, Id_Unit = SelectedItem_Unit.Id_Unit, Id_Suplier = SelectedItem_Suplier.Id_Suplier, QRCode = QRCode, BarCode = BarCode };

                DataProvider.Ins.DB.Objects.Add(Object);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(Object);
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null || SelectedItem_Unit == null || SelectedItem_Suplier == null)
                    return false;

                var displayList = DataProvider.Ins.DB.Objects.Where(x => x.Id_Object == SelectedItem.Id_Object);
                if (displayList != null && displayList.Count() != 0)
                    return true;
                return false;

            }, (p) =>
            {
                var Object = DataProvider.Ins.DB.Objects.Where(x => x.Id_Object == SelectedItem.Id_Object).SingleOrDefault();
                Object.DisplayName_Object = DisplayName;
                Object.Id_Unit = SelectedItem_Unit.Id_Unit;
                Object.Id_Suplier = SelectedItem_Suplier.Id_Suplier;
                Object.QRCode = QRCode;
                Object.BarCode = BarCode;
                DataProvider.Ins.DB.SaveChanges();
            });
            // Lệnh Xóa
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                return SelectedItem != null; // Kiểm tra nếu có đối tượng được chọn
            }, (p) =>
            {
                var objectToDelete = DataProvider.Ins.DB.Objects.SingleOrDefault(x => x.Id_Object == SelectedItem.Id_Object);
                if (objectToDelete != null)
                {
                    DataProvider.Ins.DB.Objects.Remove(objectToDelete); // Xóa khỏi cơ sở dữ liệu
                    DataProvider.Ins.DB.SaveChanges();

                    List.Remove(SelectedItem); // Xóa khỏi ObservableCollection
                    SelectedItem = null; // Hủy chọn
                }
            });
        }
    }
}