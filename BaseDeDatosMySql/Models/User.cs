using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeDatosMySql.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string TipoDeDoc { get; set; }

        [Required]
        public int NumeroDeDocumento { get; set; }

        [Required]
        public string Cargo { get; set; }

        [Required]
        public string Contraseña { get; set; }

        public bool EstadoVacacional { get; set; }
    }
}
