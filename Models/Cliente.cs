using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientesAPI.Models
{
    [Table("tb_clientes")]
    public class Cliente
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public string datacadastro { get; set; }
        public int contatoid { get; set; }
        public Contato Contato { get; set; }
        
    }
}
