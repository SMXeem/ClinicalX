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
    
    public partial class vBookedSeatPatient
    {
        public int Id { get; set; }
        public Nullable<int> HospitalId { get; set; }
        public Nullable<int> PatientId { get; set; }
        public Nullable<int> BPACCabin { get; set; }
        public Nullable<int> BPNonACCabin { get; set; }
        public Nullable<int> BPMaleWard { get; set; }
        public Nullable<int> BPFemaleWard { get; set; }
        public Nullable<int> BPICU { get; set; }
        public string Name { get; set; }
    }
}