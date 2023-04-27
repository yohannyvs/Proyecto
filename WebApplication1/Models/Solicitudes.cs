using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class Solicitudes
    {
        [Key]
        public int Id { get; set; }
        [StringLength(450)]
        public string Usuario { get; set; } = null!;
        [Column("Id_Producto", TypeName = "numeric(38, 0)")]
        public int IdProducto { get; set; }

        public int Cantidad { get; set; }

    }
}
