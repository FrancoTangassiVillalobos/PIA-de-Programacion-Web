using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prueba002.Models.dbModels
{
    [Table("Album")]
    public partial class Album
    {
        public Album()
        {
            ComentaioAlbums = new HashSet<ComentaioAlbum>();
            Favoritos = new HashSet<Favorito>();
            ListaAlbums = new HashSet<ListaAlbum>();
        }

        [Key]
        public int IdAlbum { get; set; }
        public string NombreAlbum { get; set; } = null!;
        public int IdGenero { get; set; }
        public int IdArtista { get; set; }
        public string FotoAlbum { get; set; } = null!;

        [ForeignKey("IdArtista")]
        [InverseProperty("Albums")]
        public virtual Artistum IdArtistaNavigation { get; set; } = null!;
        [ForeignKey("IdGenero")]
        [InverseProperty("Albums")]
        public virtual Genero IdGeneroNavigation { get; set; } = null!;
        [InverseProperty("IdAlbumNavigation")]
        public virtual ICollection<ComentaioAlbum> ComentaioAlbums { get; set; }
        [InverseProperty("IdAlbumNavigation")]
        public virtual ICollection<Favorito> Favoritos { get; set; }
        [InverseProperty("IdAlbumNavigation")]
        public virtual ICollection<ListaAlbum> ListaAlbums { get; set; }
    }
}
