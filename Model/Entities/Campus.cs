using System.Collections.Generic;

namespace Model.Entities
{
    public class Campus
    {
        // ---------- 
        // Properties 
        // ---------- 

        public int CampusId { get; set; }
        public string Naam { get; set; }
        public virtual Adres Adres { get; set; }

        //public string Straat { get; set; }
        //public string Huisnummer { get; set; }
        //public string Postcode { get; set; }
        //public string Gemeente { get; set; }
        public string Commentaar { get; set; }

        // --------------------- 
        // Navigation Properties 
        // --------------------- 
        public virtual ICollection<Docent> Docenten { get; set; } = new List<Docent>();
    }
}