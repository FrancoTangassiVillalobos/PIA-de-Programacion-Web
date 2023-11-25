using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prueba002.Models.dbModels
{
    [Table("Favorito")]
    public partial class Favorito
    {
        [Key]
        public int IdUsuario { get; set; }
        [Key]
        public int IdAlbum { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaFavorito { get; set; }

        [ForeignKey("IdAlbum")]
        [InverseProperty("Favoritos")]
        public virtual Album IdAlbumNavigation { get; set; } = null!;
        [ForeignKey("IdUsuario")]
        [InverseProperty("Favoritos")]
        public virtual ApplicationUser IdUsuarioNavigation { get; set; } = null!;
    }
}
