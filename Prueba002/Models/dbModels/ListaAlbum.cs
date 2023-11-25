using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prueba002.Models.dbModels
{
    [Table("Lista-Album")]
    public partial class ListaAlbum
    {
        [Key]
        public int IdLista { get; set; }
        [Key]
        public int IdAlbum { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaAgregado { get; set; }

        [ForeignKey("IdAlbum")]
        [InverseProperty("ListaAlbums")]
        public virtual Album IdAlbumNavigation { get; set; } = null!;
        [ForeignKey("IdLista")]
        [InverseProperty("ListaAlbums")]
        public virtual Listum IdListaNavigation { get; set; } = null!;
    }
}
