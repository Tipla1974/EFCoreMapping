using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;

namespace Model.Entities
{
    public class ASSWerknemer1
    { 
        // ---------- 
        // Properties 
        // ---------- 
        public int WerknemerId { get; set; } 
        public string Voornaam { get; set; } 
        public string Familienaam { get; set; } 
        public int? OversteId { get; set; } 
        
        // --------------------- 
        // Navigation Properties 
        // --------------------- 
        public virtual ICollection<ASSWerknemer1> Werknemers { get; set; } = new List<ASSWerknemer1>(); 
        public virtual ASSWerknemer1 Overste { get; set; } }
    }
