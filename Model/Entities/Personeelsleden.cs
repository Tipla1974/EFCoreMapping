using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Model.Entities
{
    public class Personeelsleden
    {
        // ---------- 
        // Properties 
        // ---------- 

        [Key]
        public int PersoneelsIdId { get; set; }
        public string Voornaam { get; set; }
        public int? ManagerId { get; set; }

        // --------------------- 
        // Navigation properties 
        // --------------------- 
        public virtual ICollection<Personeelsleden> Ondergeschikten { get; set; } = new List<Personeelsleden>();
        [InverseProperty("Ondergeschikten")] 
        [ForeignKey("OversteId")]   
        public virtual Personeelsleden Overste { get; set; }
    }
}
