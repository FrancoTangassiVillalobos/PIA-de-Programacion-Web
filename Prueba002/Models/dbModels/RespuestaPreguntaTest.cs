using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prueba002.Models.dbModels
{
    [Table("RespuestaPreguntaTest")]
    public partial class RespuestaPreguntaTest
    {
        [Key]
        public int IdUsuario { get; set; }
        [Key]
        public int IdOpcionRespuesta { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaRespuesta { get; set; }

        [ForeignKey("IdOpcionRespuesta")]
        [InverseProperty("RespuestaPreguntaTests")]
        public virtual OpcionRespuestum IdOpcionRespuestaNavigation { get; set; } = null!;
        [ForeignKey("IdUsuario")]
        [InverseProperty("RespuestaPreguntaTests")]
        public virtual ApplicationUser IdUsuarioNavigation { get; set; } = null!;
    }
}
