using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class Docent
    {
        // ---------- 
        // Properties 
        // ---------- 
        public int DocentId { get; set; } 
        
        public string Voornaam { get; set; } 
        
        public string Familienaam { get; set; } 
        
        public decimal Wedde { get; set; } 
        
        public bool? HeeftRijbewijs { get; set; } 
        
        public string LandCode { get; set; } 
        
        public DateTime InDienst { get; set; }

        public virtual Adres AdresThuis { get; set; }
        public virtual Adres AdresWerk { get; set; }
        public int CampusId { get; set; } 
        
        
        // --------------------- 
        // Navigation properties 
        // --------------------- 
        
        public virtual Campus Campus { get; set; }
    }
}
