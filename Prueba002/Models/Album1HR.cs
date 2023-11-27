using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prueba002.Models
{
    public class Album1HR
    {
        public int IdAlbum { get; set; }
        public string NombreAlbum { get; set; } = null!;
        public int IdGenero { get; set; }
        public int IdArtista { get; set; }
        public string FotoAlbum { get; set; } = null!;
    }
}
