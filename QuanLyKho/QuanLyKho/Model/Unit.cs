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

    public partial class Unit  : BaseViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Unit()
        {
            this.Objects = new HashSet<Object>();
        }

        private int _Id_Unit;
        public int Id_Unit { get => _Id_Unit; set { _Id_Unit = value; OnPropertyChanged(); } }
        private string _DisplayName_Unit;
        public string DisplayName_Unit { get => _DisplayName_Unit; set { _DisplayName_Unit = value; OnPropertyChanged(); } }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Object> Objects { get; set; }
    }
}
