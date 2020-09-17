using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Model.Entities
{
    [Table("ASSDocenten")]
    public class ASSDocent
    { 
        // ---------- 
        // Properties 
        // ---------- 
        [Key] 
        public int DocentId { get; set; } 
        public string Voornaam { get; set; } 
        public string Familienaam { get; set; } 
        [Column("Maandwedde")] 
        public decimal Wedde { get; set; } 
        [Column(TypeName = "date")] 
        public DateTime InDienst { get; set; } 
        public bool? HeeftRijbewijs { get; set; } 
        public virtual Adres Adres { get; set; } 
        [ForeignKey(nameof(ASSCampus))] public int CampusId { get; set; } // (1) 
        //
        public void Opslag(decimal percentage) 
        { 
            Wedde *= (1M + percentage / 100M); 
        }

        // --------------------- 
        // Navigation properties 
        // --------------------- 

        [ForeignKey(nameof(CampusId))] public virtual ASSCampus ASSCampus { get; set; }
        public virtual ICollection<ASSDocentActiviteit> DocentenActiviteiten { get; set; } = new List<ASSDocentActiviteit>();
    } 
}