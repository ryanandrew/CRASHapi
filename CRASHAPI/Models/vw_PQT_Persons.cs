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
    
    public partial class vw_PQT_Persons
    {
        public string REPORTINGAGENCY { get; set; }
        public string REPORTNUMBER { get; set; }
        public decimal UNITID { get; set; }
        public decimal PERSONID { get; set; }
        public Nullable<decimal> PERSONTYPEid { get; set; }
        public string PersonType { get; set; }
        public string OPRLICENSESTATECODE { get; set; }
        public string OPRLICENSECLASSid { get; set; }
        public string OprLicenseClass { get; set; }
        public string STATECODE { get; set; }
        public string SEX { get; set; }
        public string AGE { get; set; }
        public Nullable<decimal> SEATBELT { get; set; }
        public Nullable<decimal> CDL { get; set; }
        public Nullable<decimal> SEATLOCATIONid { get; set; }
        public string SeatLocation { get; set; }
        public Nullable<decimal> INJURYid { get; set; }
        public string Injury { get; set; }
        public Nullable<decimal> EJECTEDid { get; set; }
        public string Ejected { get; set; }
        public Nullable<decimal> RESTRAINTid { get; set; }
        public string Restraint { get; set; }
        public Nullable<decimal> PEDESTRIANCYCLEACTIONid { get; set; }
        public string PedCycleAction { get; set; }
        public Nullable<decimal> PEDESTRIANCYCLELOCATIONid { get; set; }
        public string PedCycleLocation { get; set; }
        public string INSURANCENAMEARS { get; set; }
        public string EQUIPMENT1ARS { get; set; }
        public Nullable<decimal> AIRBAGDEPLOYED { get; set; }
        public Nullable<decimal> EXTRACTED { get; set; }
        public Nullable<short> PerceivedRace { get; set; }
    }
}