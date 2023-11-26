using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prueba002.Models
{
    public class PreguntaTestHR
    {
        public int IdPregunta { get; set; }
        public int IdTest { get; set; }
        public string Descripcion { get; set; } = null!;
    }
}
