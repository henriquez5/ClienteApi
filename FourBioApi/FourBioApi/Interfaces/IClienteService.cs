using FourBioApi.Models;

namespace FourBioApi.Interfaces
{
    public interface IClienteService
    {
        ClienteModel AdicionarCliente(ClienteModel clienteModel);

        ClienteModel AtualizarCliente(int idCliente, ClienteModel clienteModel);

        ClienteModel RemoverCliente(int idCliente);

        public List<ClienteModel> ListarClientes(string? filtro);

    }
}
