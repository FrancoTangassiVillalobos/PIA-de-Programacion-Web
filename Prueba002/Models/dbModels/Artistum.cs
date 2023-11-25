using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prueba002.Models.dbModels
{
    public partial class Artistum
    {
        public Artistum()
        {
            Albums = new HashSet<Album>();
        }

        [Key]
        public int IdArtista { get; set; }
        public string Nombre { get; set; } = null!;

        [InverseProperty("IdArtistaNavigation")]
        public virtual ICollection<Album> Albums { get; set; }
    }
}
