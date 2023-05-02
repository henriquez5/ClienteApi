using FourBioApi.Interfaces;
using FourBioApi.Models;
using FourBioApi.Repository;
using System.Net;

namespace FourBioApi.Services
{
    public class ClienteService : IClienteService
    {

        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public List<ClienteModel> ListarClientes(string? filtro)
        {
            try
            {
                if (String.IsNullOrEmpty(filtro))
                    filtro = "";

                List<ClienteModel> buscarClientes = new List<ClienteModel>();

                buscarClientes = _clienteRepository.ListarClientes(filtro);

                return buscarClientes;
            }
            catch (Exception ex) 
            {
                throw new Exception("Houve um erro ao buscar o(s) cliente(s) : " + ex.Message);
            }
        }

        public ClienteModel AdicionarCliente(ClienteModel clienteModel)
        {
            try
            {
                if(!ValidarCpf.IsCpf(clienteModel.Cpf))
                    throw new Exception("Cpf não é valido!!");

                ClienteModel adicionarCliente = new ClienteModel();

                adicionarCliente = _clienteRepository.AdicionarCliente(clienteModel);

                return adicionarCliente;
            }
            catch(Exception ex) 
            {
                throw new Exception("Houve um erro ao adicionar o cliente : " + ex.Message);
            }
        }

        public ClienteModel AtualizarCliente(int idCliente, ClienteModel clienteModel)
        {
            try
            {
                ClienteModel atualizarCliente = new ClienteModel();

                atualizarCliente = _clienteRepository.AtualizarCliente(idCliente, clienteModel);

                return atualizarCliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao adicionar o cliente : " + ex.Message);
            }
        }

        public ClienteModel RemoverCliente(int idCliente)
        {
            try
            {
                ClienteModel atualizarCliente = new ClienteModel();

                atualizarCliente = _clienteRepository.RemoverCliente(idCliente);

                return atualizarCliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao adicionar o cliente : " + ex.Message);
            }
        }
    }
}
