using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class ASSBoekCursus
    {
        // ---------- 
        // Properties 
        // ---------- 
        public int CursusId { get; set; }
        // Key 
        public int BoekId { get; set; }
        // Key 
        public int VolgNr { get; set; }

        // --------------------- 
        // Navigation Properties 
        // --------------------- 
        public virtual ASSBoek Boek { get; set; }
        public virtual ASSCursus Cursus { get; set; }
    }
    }
