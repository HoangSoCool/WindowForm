//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyKho.Model
{
    using System;
    using System.Collections.Generic;
    using QuanLyKho.ViewModel;

    public partial class InputInfo : BaseViewModel
    {
        private string _Id_InputInfo;
        public string Id_InputInfo { get => _Id_InputInfo; set { _Id_InputInfo = value; OnPropertyChanged(); } }

        private string _Id_Object;
        public string Id_Object { get => _Id_Object; set { _Id_Object = value; OnPropertyChanged(); } }

        private string _Id_Input;
        public string Id_Input { get => _Id_Input; set { _Id_Input = value; OnPropertyChanged(); } }

        private Nullable<int> _Count;
        public Nullable<int> Count { get => _Count; set { _Count = value; OnPropertyChanged(); } }

        private Nullable<double> _Price_Input;
        public Nullable<double> Price_Input { get => _Price_Input; set { _Price_Input = value; OnPropertyChanged(); } }

        private Nullable<double> _Price_Output;
        public Nullable<double> Price_Output { get => _Price_Output; set { _Price_Output = value; OnPropertyChanged(); } }

        private string _Status_Input;
        public string Status_InputInfo { get => _Status_Input; set { _Status_Input = value; OnPropertyChanged(); } }

        //public virtual Input Input { get; set; }
        private Input _Input;
        public virtual Input Input { get => _Input; set { _Input = value; OnPropertyChanged(); } }
        private Object _Object;
        public virtual Object Object { get => _Object; set { _Object = value; OnPropertyChanged(); } }
        //public virtual Object Object { get; set; }
    }
}
