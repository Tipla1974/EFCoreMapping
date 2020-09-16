using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    
        [Table("TPHCursussen")] 
        public abstract class TPHCursus 
        { 
            public int Id { get; set; } 
            public string Naam { get; set; } 
        }
   
}
