using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Model.Entities
{
    public class ASSWerknemer
    {
        // ---------- 
        // Properties 
        // ---------- 

        [Key] 
        public int WerknemerId { get; set; } 
        public string Voornaam { get; set; } 
        public string Familienaam { get; set; }
        public int? OversteId { get; set; }

        // --------------------- 
        // Navigation properties 
        // --------------------- 
        public virtual ICollection<ASSWerknemer> Werknemers {get;set;} = new List<ASSWerknemer>(); // (1) 
        
        [InverseProperty("Werknemers")] // (2) 
        [ForeignKey("OversteId")]
        public virtual ASSWerknemer Overste { get; set; } // (3)
    }
}
