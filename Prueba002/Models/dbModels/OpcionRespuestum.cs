using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prueba002.Models.dbModels
{
    public partial class OpcionRespuestum
    {
        public OpcionRespuestum()
        {
            RespuestaPreguntaTests = new HashSet<RespuestaPreguntaTest>();
        }

        [Key]
        public int IdOpcionPredunta { get; set; }
        public int IdPregunta { get; set; }
        public string Descripcion { get; set; } = null!;

        [ForeignKey("IdPregunta")]
        [InverseProperty("OpcionRespuesta")]
        public virtual PreguntaTest IdPreguntaNavigation { get; set; } = null!;
        [InverseProperty("IdOpcionRespuestaNavigation")]
        public virtual ICollection<RespuestaPreguntaTest> RespuestaPreguntaTests { get; set; }
    }
}
