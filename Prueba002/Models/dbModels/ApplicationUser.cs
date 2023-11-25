using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Prueba002.Models.dbModels
{
    public class ApplicationUser : IdentityUser<int>
    {
        public ApplicationUser()
        {
            ComentaioAlbums = new HashSet<ComentaioAlbum>();
            Favoritos = new HashSet<Favorito>();
            Lista = new HashSet<Listum>();
            RespuestaPreguntaTests = new HashSet<RespuestaPreguntaTest>();
            Sugerencia = new HashSet<Sugerencium>();
        }

        public string Nombre { get; set; } = null!;
        public string DescripciónPersonal { get; set; } = null!;

        public virtual ICollection<ComentaioAlbum> ComentaioAlbums { get; set; }
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Favorito> Favoritos { get; set; }
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Listum> Lista { get; set; }
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<RespuestaPreguntaTest> RespuestaPreguntaTests { get; set; }
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Sugerencium> Sugerencia { get; set; }
    }
}
