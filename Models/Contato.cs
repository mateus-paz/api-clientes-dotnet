using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientesAPI.Models
{
    [Table("tb_contatos")]
    public class Contato
    {
        [Key]
        public int id { get; set; } 
        public string tipo { get; set; }
        public string texto { get; set; }
    }
}
