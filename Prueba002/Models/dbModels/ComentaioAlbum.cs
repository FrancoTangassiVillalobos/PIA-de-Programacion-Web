using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prueba002.Models.dbModels
{
    [Table("ComentaioAlbum")]
    public partial class ComentaioAlbum
    {
        [Key]
        public int IdComentarioAlbum { get; set; }
        public int IdUsuario { get; set; }
        public int IdAlbum { get; set; }
        public string Descripcion { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime FechaComentario { get; set; }

        [ForeignKey("IdAlbum")]
        [InverseProperty("ComentaioAlbums")]
        public virtual Album IdAlbumNavigation { get; set; } = null!;
        [ForeignKey("IdUsuario")]
        [InverseProperty("ComentaioAlbums")]
        public virtual ApplicationUser IdUsuarioNavigation { get; set; } = null!;
    }
}
