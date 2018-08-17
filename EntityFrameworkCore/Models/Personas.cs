using System;
using System.Collections.Generic;

namespace EntityFrameworkCore.Models
{
    public partial class Personas
    {
        public Personas()
        {
            Movimientos = new HashSet<Movimientos>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime? FehcaNacimiento { get; set; }
        public int Estado { get; set; }

        public ICollection<Movimientos> Movimientos { get; set; }
    }
}
