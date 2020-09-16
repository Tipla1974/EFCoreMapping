using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Model.Entities
{
    [Table("ASSCampussen")]
    public class ASSCampus
    { 
        // ---------- 
        // Properties 
        // ---------- 
        [Key] 
        public int CampusId { get; set; } 
        [Required] 
        [StringLength(50)] 
        public string Naam { get; set; } 
        public virtual Adres Adres { get; set; } 
        
        // --------------------- 
        // Navigation Properties 
        // --------------------- 
        public virtual ICollection<ASSDocent> ASSDocenten { get; set; } = new List<ASSDocent>(); // (1) 
    }
    }
