//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class AdisyonSiparisDetay
    {
        public int AdisyonSiparisDetayID { get; set; }
        public int SiparisID { get; set; }
        public int AdisyonID { get; set; }
    
        public virtual Adisyon Adisyon { get; set; }
        public virtual Sipari Sipari { get; set; }
    }
}