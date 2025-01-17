﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QuanLyKho.Model;

namespace QuanLyKho.ViewModel
{
    public class UnitViewModel : BaseViewModel
    {
        private ObservableCollection<Unit> _List;
        public ObservableCollection<Unit> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private Unit _SelectedItem;
        public Unit SelectedItem
        {
            get => _SelectedItem; set
            {
                _SelectedItem = value; OnPropertyChanged();
                if (SelectedItem != null)
                {
                    DisplayName = SelectedItem.DisplayName_Unit;
                }
            }
        }

        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public UnitViewModel()
        {
            List = new ObservableCollection<Unit>(DataProvider.Ins.DB.Units);
            AddCommand = new RelayCommand<object>((p) =>
            { if(string.IsNullOrEmpty(DisplayName))
                    return false;

            var displayList = DataProvider.Ins.DB.Units.Where(x => x.DisplayName_Unit == DisplayName);
                if (displayList == null || displayList.Count() != 0)
                    return false;

                return true;
            }, (p) => 
            {
                var unit = new Unit() { DisplayName_Unit = DisplayName };

                DataProvider.Ins.DB.Units.Add(unit);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(unit);
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(DisplayName) || SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.Units.Where(x => x.DisplayName_Unit == DisplayName);
                if (displayList == null || displayList.Count() != 0)
                    return false;
                return true;

            }, (p) =>
            {
                var unit = DataProvider.Ins.DB.Units.Where(x => x.Id_Unit == SelectedItem.Id_Unit).SingleOrDefault();
                unit.DisplayName_Unit = DisplayName;
                DataProvider.Ins.DB.SaveChanges();
                SelectedItem.DisplayName_Unit = DisplayName;
            });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                return SelectedItem != null; // Kiểm tra nếu có item được chọn
            }, (p) =>
            {
                if (SelectedItem != null)
                {
                    var unitToDelete = DataProvider.Ins.DB.Units.SingleOrDefault(x => x.Id_Unit == SelectedItem.Id_Unit);
                    if (unitToDelete != null)
                    {
                        // Xóa khỏi cơ sở dữ liệu
                        DataProvider.Ins.DB.Units.Remove(unitToDelete);
                        DataProvider.Ins.DB.SaveChanges();

                        // Xóa khỏi ObservableCollection
                        List.Remove(SelectedItem);

                        // Hủy chọn item sau khi xóa
                        SelectedItem = null;
                    }
                }
            });
        }
            
            
    }
}
