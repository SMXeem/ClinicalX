//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClinicalX.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TotalSeat
    {
        public int Id { get; set; }
        public Nullable<int> HospitalId { get; set; }
        public Nullable<int> ACCabin { get; set; }
        public Nullable<int> NonACCabin { get; set; }
        public Nullable<int> MaleWard { get; set; }
        public Nullable<int> FemaleWard { get; set; }
        public Nullable<int> ICU { get; set; }
    }
}