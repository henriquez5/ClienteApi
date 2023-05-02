using FourBioApi.Models;
using FourBioApi.Services;
using FourBioApi.Repository;
using Microsoft.AspNetCore.Mvc;
using FourBioApi.Interfaces;

namespace FourBioApi.Controllers
{
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        [Route("listar/{filtro?}")]
        public IActionResult ListarClientes(string? filtro)
        {
            try
            {
                List<ClienteModel> buscarClientes = _clienteService.ListarClientes(filtro);

                if (buscarClientes.Count == 0)
                    throw new Exception("Nenhum Cliente foi localizado.");

                return Ok(buscarClientes);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [Route("criar")]
        public IActionResult AdicionarCliente([FromBody] ClienteModel clienteModel)
        {
            try
            {
                ClienteModel clienteAdd = _clienteService.AdicionarCliente(clienteModel);

                if (clienteAdd == null)
                    throw new Exception("Nenhum Cliente foi adicionado.");

                return Ok(clienteAdd);
            }
            catch(Exception ex) 
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [Route("atualizar/{idCliente}")]
        public IActionResult AtualizarCliente(int idCliente, [FromBody] ClienteModel clienteModel)
        {
            try
            {
                ClienteModel clienteUpdate = _clienteService.AtualizarCliente(idCliente, clienteModel);

                if (clienteUpdate == null)
                    throw new Exception("Nenhum Cliente foi adicionado.");

                return Ok(clienteUpdate);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        [Route("remover/{idCliente}")]
        public IActionResult RemoverCliente(int idCliente)
        {
            try
            {
                ClienteModel clienteUpdate = _clienteService.RemoverCliente(idCliente);

                if (clienteUpdate == null)
                    throw new Exception("Nenhum Cliente foi adicionado.");

                return Ok(clienteUpdate);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
