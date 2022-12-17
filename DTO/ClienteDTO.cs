using ClientesAPI.Models;

namespace ClientesAPI.DTO
{
    public class ClienteDTO
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string datacadastro { get; set; }
        public Contato contato { get; set; }


        public ClienteDTO (Cliente cliente)
        {
            this.id = cliente.id;
            this.nome = cliente.nome;
            this.datacadastro = cliente.datacadastro;
            this.contato = cliente.Contato;
        }

    }
}
