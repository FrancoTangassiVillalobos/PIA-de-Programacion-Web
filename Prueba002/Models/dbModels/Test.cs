using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prueba002.Models.dbModels
{
    [Table("Test")]
    public partial class Test
    {
        public Test()
        {
            PreguntaTests = new HashSet<PreguntaTest>();
        }

        [Key]
        public int IdTest { get; set; }
        public string TituloTest { get; set; } = null!;

        [InverseProperty("IdTestNavigation")]
        public virtual ICollection<PreguntaTest> PreguntaTests { get; set; }
    }
}
