using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Areas.Identity.Data;

namespace WebApplication1.Models
{
    public class Producto
    {
        [Key]
        [Column(TypeName = "numeric(38, 0)")]
        public int Id { get; set; }
        [StringLength(2000)]
        [Unicode(false)]
        public string Descripcion { get; set; } = null!;
        [Column(TypeName = "numeric(38, 0)")]
        public int Cantidad { get; set; }
        [StringLength(1000)]
        [Unicode(false)]
        public string? Proveedor { get; set; }
        [Column(TypeName = "numeric(38, 0)")]
        public int Categoria { get; set; }

    }
}
