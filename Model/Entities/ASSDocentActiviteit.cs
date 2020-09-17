using System;
using System.Collections.Generic;
using System.Text;
namespace Model.Entities
{
    public class ASSDocentActiviteit
    { 
        // ---------- 
        // Properties 
        // ---------- 
        public int DocentId { get; set; } // Key 
        public int ActiviteitId { get; set; } // Key 
        public int AantalUren { get; set; } 
        
            // --------------------- 
            // Navigation Properties 
            // --------------------- 
        public virtual ASSDocent Docent { get; set; } 
        public virtual ASSActiviteit Activiteit { get; set; } 
    } 
}
