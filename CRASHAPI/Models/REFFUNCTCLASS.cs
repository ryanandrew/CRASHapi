//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRASHAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class REFFUNCTCLASS
    {
        public decimal ID { get; set; }
        public string DESCRIPTION { get; set; }
        public Nullable<decimal> FAUAREAID { get; set; }
        public decimal URBANFLAG { get; set; }
        public string ABREVIATEDNAME { get; set; }
        public Nullable<decimal> SORTORDER { get; set; }
    
        public virtual REFTA1FUNCGRPS REFTA1FUNCGRPS { get; set; }
    }
}
