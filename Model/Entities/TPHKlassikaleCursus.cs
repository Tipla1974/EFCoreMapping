using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class TPHKlassikaleCursus : TPHCursus 
    { 
        public DateTime Van { get; set; } 
        public DateTime Tot { get; set; } 
    }
}
