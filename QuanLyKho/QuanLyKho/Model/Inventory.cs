using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKho.ViewModel;

namespace QuanLyKho.Model
{
    public class Inventory : BaseViewModel
    {
        //public Object Object { get; set; }
        private Object _Object;
        public Object Object { get => _Object; set { _Object = value; OnPropertyChanged(); } }
        //public int STT { get; set; }
        private int _STT;
        public int STT { get => _STT; set { _STT = value; OnPropertyChanged(); } }
        //public int Amount { get; set; }
        private int _Amount;
        public int Amount { get => _Amount; set { _Amount = value; OnPropertyChanged(); } }
    }
}