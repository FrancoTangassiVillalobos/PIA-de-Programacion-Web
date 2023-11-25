using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prueba002.Models.dbModels
{
    [Table("Genero")]
    public partial class Genero
    {
        public Genero()
        {
            Albums = new HashSet<Album>();
        }

        [Key]
        public int IdGenero { get; set; }
        public string Descripcion { get; set; } = null!;
        public string ImagenGenero { get; set; } = null!;

        [InverseProperty("IdGeneroNavigation")]
        public virtual ICollection<Album> Albums { get; set; }
    }
}
