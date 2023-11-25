using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prueba002.Models.dbModels
{
    public partial class Sugerencium
    {
        [Key]
        public int IdSugerencia { get; set; }
        public int IdUsuario { get; set; }
        public string TituloSugerencia { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime FechaSugerencia { get; set; }

        [ForeignKey("IdUsuario")]
        [InverseProperty("Sugerencia")]
        public virtual ApplicationUser IdUsuarioNavigation { get; set; } = null!;
    }
}
