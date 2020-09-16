using System.Collections.Generic;
namespace Model.Entities
{
    public class ASSBoek
    { 
        // ---------- 
        // Properties 
        // ---------- 
        public int BoekId { get; set; } 
        public string IsbnNr { get; set; } 
        public string Titel { get; set; } 
        
        // ----------- 
        // Associaties 
        // ----------- 
        public virtual ICollection<ASSBoekCursus> BoekenCursussen { get; set; } = new List<ASSBoekCursus>(); 
    } 
}
