//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LeHoangLong_2210900037.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Lhl_Sach
    {
        public string Lhl_MaSach { get; set; }
        public string Lhl_TenSach { get; set; }
        public Nullable<int> Lhl_SoTrang { get; set; }
        public Nullable<int> Lhl_NamXB { get; set; }
        public string Lhl_MaTG { get; set; }
        public Nullable<bool> Lhl_TrangThai { get; set; }
    
        public virtual Lhl_TacGia Lhl_TacGia { get; set; }
    }
}
