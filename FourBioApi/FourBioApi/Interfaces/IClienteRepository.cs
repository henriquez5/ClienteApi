using FourBioApi.Models;

namespace FourBioApi.Interfaces
{
    public interface IClienteRepository
    {
        ClienteModel AdicionarCliente(ClienteModel clienteModel);

        ClienteModel AtualizarCliente(int idCliente, ClienteModel clienteModel);

        ClienteModel RemoverCliente(int idCliente);

        List<ClienteModel> ListarClientes(string? filtro);

    }
}
