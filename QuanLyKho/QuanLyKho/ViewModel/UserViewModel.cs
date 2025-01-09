using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKho.Model;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace QuanLyKho.ViewModel
{
    public class UserViewModel : BaseViewModel
    {
        private ObservableCollection<Model.User> _List;
        public ObservableCollection<Model.User> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private ObservableCollection<UserRole> _UserRole;
        public ObservableCollection<UserRole> UserRole { get => _UserRole; set { _UserRole = value; OnPropertyChanged(); } }

        private Model.User _SelectedItem;
        public Model.User SelectedItem
        {
            get => _SelectedItem; set
            {
                _SelectedItem = value; OnPropertyChanged();
                if (SelectedItem != null)
                {
                    Id_User = SelectedItem.Id_Users.ToString();
                    DisplayName_User = SelectedItem.DisplayName_Users;
                    SelectedItem_UserRole = SelectedItem.UserRole;
                    Name_User = SelectedItem.UserName;
                }
            }
        }

        private UserRole _SelectedItem_UserRole;
        public UserRole SelectedItem_UserRole
        {
            get => _SelectedItem_UserRole; set
            {
                _SelectedItem_UserRole = value;
                OnPropertyChanged();
            }
        }


        private string _DisplayName_User;
        public string DisplayName_User { get => _DisplayName_User; set { _DisplayName_User = value; OnPropertyChanged(); } }

        private string _Id_User;
        public string Id_User { get => _Id_User; set { _Id_User = value; OnPropertyChanged(); } }

        private string _Name_User;
        public string Name_User { get => _Name_User; set { _Name_User = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand ChangePasswordCommand { get; set; }

        public UserViewModel()
        {
            List = new ObservableCollection<Model.User>(DataProvider.Ins.DB.Users);
            UserRole = new ObservableCollection<UserRole>(DataProvider.Ins.DB.UserRoles);
            // Nút Thêm
            AddCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(DisplayName_User) || string.IsNullOrEmpty(Name_User) || SelectedItem_UserRole == null)
                    return false;

                // Kiểm tra xem tên người dùng đã tồn tại trong cơ sở dữ liệu chưa
                var existingUser = DataProvider.Ins.DB.Users.SingleOrDefault(x => x.UserName == Name_User);
                if (existingUser != null)
                    return false;

                return true;
            }, (p) =>
            {
                // Tạo một người dùng mới
                var user = new Model.User()
                {
                    DisplayName_Users = DisplayName_User,
                    UserName = Name_User,
                    UserRole = SelectedItem_UserRole // Gán quyền cho người dùng
                };

                // Thêm người dùng vào cơ sở dữ liệu
                DataProvider.Ins.DB.Users.Add(user);
                DataProvider.Ins.DB.SaveChanges();

                // Thêm người dùng vào danh sách hiển thị
                List.Add(user);
            });

            // Nút Sửa
            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null || string.IsNullOrEmpty(DisplayName_User) || string.IsNullOrEmpty(Name_User) || SelectedItem_UserRole == null)
                    return false;

                var existingUser = DataProvider.Ins.DB.Users.SingleOrDefault(x => x.Id_Users == SelectedItem.Id_Users);
                if (existingUser == null)
                    return false;

                return true;
            }, (p) =>
            {
                var user = DataProvider.Ins.DB.Users.SingleOrDefault(x => x.Id_Users == SelectedItem.Id_Users);
                if (user != null)
                {
                    user.DisplayName_Users = DisplayName_User;
                    user.UserName = Name_User;
                    user.UserRole = SelectedItem_UserRole;

                    DataProvider.Ins.DB.SaveChanges();

                    SelectedItem.DisplayName_Users = DisplayName_User;
                    SelectedItem.UserName = Name_User;
                    SelectedItem.UserRole = SelectedItem_UserRole;
                }
            });

            // Nút Xóa
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                return SelectedItem != null;
            }, (p) =>
            {
                if (SelectedItem != null)
                {
                    var userToDelete = DataProvider.Ins.DB.Users.SingleOrDefault(x => x.Id_Users == SelectedItem.Id_Users);
                    if (userToDelete != null)
                    {
                        DataProvider.Ins.DB.Users.Remove(userToDelete);
                        DataProvider.Ins.DB.SaveChanges();

                        List.Remove(SelectedItem);
                        SelectedItem = null;
                    }
                }
            });
        }
    }
}