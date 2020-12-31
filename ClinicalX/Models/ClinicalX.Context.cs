﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ClinicalXEntities : DbContext
    {
        public ClinicalXEntities()
            : base("name=ClinicalXEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BloodGroup> BloodGroups { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Donner> Donners { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Hospital> Hospitals { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Speciality> Specialities { get; set; }
        public virtual DbSet<vDoctor> vDoctors { get; set; }
        public virtual DbSet<vDonner> vDonners { get; set; }
        public virtual DbSet<BookedSeat> BookedSeats { get; set; }
        public virtual DbSet<TotalSeat> TotalSeats { get; set; }
        public virtual DbSet<vHospital> vHospitals { get; set; }
        public virtual DbSet<Ambulance> Ambulances { get; set; }
        public virtual DbSet<vAmbulance> vAmbulances { get; set; }
    }
}
