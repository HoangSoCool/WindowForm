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

    public partial class Suplier : BaseViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Suplier()
        {
            this.Objects = new HashSet<Object>();
        }
        private int _Id_Suplier;
        public int Id_Suplier { get => _Id_Suplier; set { _Id_Suplier = value; OnPropertyChanged(); } }

        private string _DisplayName_Suplier;
        public string DisplayName_Suplier { get => _DisplayName_Suplier; set { _DisplayName_Suplier = value; OnPropertyChanged(); } }

        private string _Phone_Suplier;
        public string Phone_Suplier { get => _Phone_Suplier; set { _Phone_Suplier = value; OnPropertyChanged(); } }

        private string _Address_Suplier;
        public string Address_Suplier { get => _Address_Suplier; set { _Address_Suplier = value; OnPropertyChanged(); } }

        private string _Email_Suplier;
        public string Email_Suplier { get => _Email_Suplier; set { _Email_Suplier = value; OnPropertyChanged(); } }

        private string _MoreInfo_Suplier;
        public string MoreInfo_Suplier { get => _MoreInfo_Suplier; set { _MoreInfo_Suplier = value; OnPropertyChanged(); } }

        private Nullable<System.DateTime> _ContractDate_Suplier;
        public Nullable<System.DateTime> ContractDate_Suplier { get => _ContractDate_Suplier; set { _ContractDate_Suplier = value; OnPropertyChanged(); } }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Object> Objects { get; set; }
    }
}