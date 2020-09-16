using System.Collections.Generic;
namespace Model.Entities
{
    public class ASSCursus
    { 
        // ---------- 
        // Properties 
        // ---------- 
        public int CursusId { get; set; } 
        public string Naam { get; set; }

        // ----------- 
        // Associaties 
        // ----------- 
        public virtual ICollection<ASSBoekCursus> BoekenCursussen { get; set; }= new List<ASSBoekCursus>(); 
    } 
}
