using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestMVC.Models
{
    public class TestMVCContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TestMVCContext() : base("name=TestMVCContext")
        {
        }

        public DbSet<Producto> Producto { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }

    [Table("Producto")]
    public class Producto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id_producto { get; set; }
        public string descripcion { get; set; }
        public string marca { get; set; }
        public decimal cantidad { get; set; }
        public decimal costo { get; set; }
        public bool activo { get; set; }
        public int id_usuario { get; set; }
    }

    [Table("Persona")]
    public class Persona
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id_persona { get; set; }
        public string cedula { get; set; }
        public string nombre { get; set; }
        public char sexo { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string direccion { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public bool activo { get; set; }
        public int id_usuario { get; set; }
    }

    [Table("Usuario")]
    public class Usuario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id_usuario { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El login no puede estar vacio.")]
        public string login { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "La clave no puede estar vacia.")]
        public string clave { get; set; }
        public DateTime fecha_registro { get; set; }
        public bool activo { get; set; }
    }
}
