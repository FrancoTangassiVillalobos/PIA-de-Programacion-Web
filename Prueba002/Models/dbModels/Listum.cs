using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prueba002.Models.dbModels
{
    public partial class Listum
    {
        public Listum()
        {
            ListaAlbums = new HashSet<ListaAlbum>();
        }

        [Key]
        public int IdLista { get; set; }
        public int IdUsuario { get; set; }
        public string NombreLista { get; set; } = null!;

        [ForeignKey("IdUsuario")]
        [InverseProperty("Lista")]
        public virtual ApplicationUser IdUsuarioNavigation { get; set; } = null!;
        [InverseProperty("IdListaNavigation")]
        public virtual ICollection<ListaAlbum> ListaAlbums { get; set; }
    }
}
