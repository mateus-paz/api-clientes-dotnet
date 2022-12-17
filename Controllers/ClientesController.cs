using ClientesAPI.Data;
using ClientesAPI.DTO;
using ClientesAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientesAPI.Controllers
{

    [EnableCors("Policy1")]
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : Controller
    {
        private readonly ClientesApiDbContext dbContext;
        public ClientesController(ClientesApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult ListarClientes()
        {
            var retorno = dbContext.Clientes.Include(cliente => cliente.Contato).ToList();

            List<ClienteDTO> clientes = new List<ClienteDTO>(); 

            foreach (Cliente cli in retorno)
            {
                clientes.Add(new ClienteDTO(cli));
            }
            
            return Ok(clientes);
        }


        [HttpPost]
        public IActionResult SalvarCliente(Cliente cliente)
        {

            cliente.datacadastro = DateTime.Now.ToString();

            dbContext.Clientes.Add(cliente);

            dbContext.SaveChanges();

            var clientedto = new ClienteDTO(cliente);

            return Ok(clientedto);
        }


        [HttpGet]
        [Route("{id:int}")]
        public IActionResult ConsultarCliente([FromRoute] int id)
        {
            var cliente = dbContext.Clientes.Find(id);

            if (cliente == null)
            {
                return NotFound();
            }

            var contato = dbContext.Contatos.Find(cliente.contatoid);
            cliente.Contato = contato;

            ClienteDTO cliDto = new ClienteDTO(cliente);

            return Ok(cliDto);

        }

        [HttpGet]
        [Route("query/{valor}")]
        public IActionResult PesquisarCliente([FromRoute] string valor)
        {
            var result = dbContext.Clientes.Where(c => c.nome.Contains(valor)).ToList();

            List<ClienteDTO> clientes = new List<ClienteDTO>();

            foreach (Cliente cli in result)
            {
                var contato = dbContext.Contatos.Find(cli.contatoid);
                cli.Contato = contato;
                clientes.Add(new ClienteDTO(cli));
            }

            return Ok(clientes);

        }


        [HttpPut]
        [Route("{id:int}")]
        public IActionResult AlterarCliente([FromRoute] int id, Cliente cliente)
        {
            var cli = dbContext.Clientes.Find(id);

            if (cli == null)
            {
                return NotFound();
            }

            cli.nome = cliente.nome;
            
            var contato = dbContext.Contatos.Find(cli.contatoid);

            contato.tipo = cliente.Contato.tipo;
            contato.texto = cliente.Contato.texto;

            dbContext.SaveChanges();

            ClienteDTO clienteDto = new ClienteDTO(cli);

            return Ok(clienteDto);

        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeletarCliente([FromRoute] int id)
        {
            var cliente = dbContext.Clientes.Find(id);

            if (cliente == null)
            {
                return NotFound();
            }

            var contato = dbContext.Contatos.Find(cliente.contatoid);

            dbContext.Remove(cliente);
            dbContext.Remove(contato);

            dbContext.SaveChanges();

            ClienteDTO cliDto = new ClienteDTO(cliente);

            return Ok(cliDto);

        }


    }
}
