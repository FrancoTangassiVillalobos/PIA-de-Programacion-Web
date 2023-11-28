using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prueba002.Models
{
    public class ListaAlbumHR
    {
        public int IdLista { get; set; }
        public int IdAlbum { get; set; }
        public DateTime FechaAgregado { get; set; }
    }
}
