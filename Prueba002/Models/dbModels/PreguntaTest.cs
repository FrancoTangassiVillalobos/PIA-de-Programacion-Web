using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prueba002.Models.dbModels
{
    [Table("PreguntaTest")]
    public partial class PreguntaTest
    {
        public PreguntaTest()
        {
            OpcionRespuesta = new HashSet<OpcionRespuestum>();
        }

        [Key]
        public int IdPregunta { get; set; }
        public int IdTest { get; set; }
        public string Descripcion { get; set; } = null!;

        [ForeignKey("IdTest")]
        [InverseProperty("PreguntaTests")]
        public virtual Test IdTestNavigation { get; set; } = null!;
        [InverseProperty("IdPreguntaNavigation")]
        public virtual ICollection<OpcionRespuestum> OpcionRespuesta { get; set; }
    }
}
