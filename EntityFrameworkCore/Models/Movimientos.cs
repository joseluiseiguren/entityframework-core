using System;
using System.Collections.Generic;

namespace EntityFrameworkCore.Models
{
    public partial class Movimientos
    {
        public int Id { get; set; }
        public int IdPersona { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Importe { get; set; }

        public Personas IdPersonaNavigation { get; set; }
    }
}
