using FourBioApi.Interfaces;
using FourBioApi.Models;
using Newtonsoft.Json;
using System.Text.Json;

namespace FourBioApi.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        //Diretorio do arquivo JSON, altere se necessario
        private readonly string jsonDiretorio = "C:\\Projetos DOTNET\\FourBioApi\\FourBioApi\\DataJson\\cliente.json";

        public List<ClienteModel> ListarClientes(string? filtro)
        {
            try
            {
                List<ClienteModel> buscarClientesResult = new List<ClienteModel>();

                string jsonString = File.ReadAllText(jsonDiretorio);

                if (String.IsNullOrEmpty(jsonString))
                    throw new Exception("Não existe nenhum dado inserido no JSON");

                List<ClienteModel> list = JsonConvert.DeserializeObject<List<ClienteModel>>(jsonString);

                var query = (from Cli in list
                             where (Cli.Cpf.Contains(filtro) || Cli.Nome.Contains(filtro))
                             || (String.IsNullOrEmpty(filtro) || filtro == null)
                             select Cli).ToList();

                if (query.Count > 0)
                    buscarClientesResult = query;

                return buscarClientesResult;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar dado no arquivo JSON : " + ex.Message);
            }
        }

        public ClienteModel AdicionarCliente(ClienteModel clienteModel)
        {
            try
            {
                string jsonString = File.ReadAllText(jsonDiretorio);

                //Se o arquivo for vazio, realiza a primeira inserção
                if(String.IsNullOrEmpty(jsonString))
                {
                    var clienteFirst = new ClienteModel
                    {
                        Id = clienteModel.Id,
                        Nome = clienteModel.Nome,
                        Contato = clienteModel.Contato,
                        Cpf = clienteModel.Cpf,
                        Rg = clienteModel.Rg,
                        Endereco = clienteModel.Endereco
                    };

                    string clienteJson = JsonConvert.SerializeObject(clienteFirst, Formatting.Indented);

                    File.AppendAllText(jsonDiretorio, "[" + clienteJson + "]");

                    return clienteModel;
                }

                List<ClienteModel> list = JsonConvert.DeserializeObject<List<ClienteModel>>(jsonString);

                var cliente = new ClienteModel
                {
                    Id = clienteModel.Id,
                    Nome = clienteModel.Nome,
                    Contato = clienteModel.Contato,
                    Cpf = clienteModel.Cpf,
                    Rg = clienteModel.Rg,
                    Endereco = clienteModel.Endereco
                };

                list.Add(cliente);

                string clienteToJson = JsonConvert.SerializeObject(list, Formatting.Indented);

                File.WriteAllText(jsonDiretorio, clienteToJson);

                return clienteModel;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao adicionar no arquivo JSON : " + ex.Message);
            }
        }

        public ClienteModel AtualizarCliente(int idCliente, ClienteModel clienteModel)
        {
            try
            {
                ClienteModel atualizado = new ClienteModel();

                string jsonString = File.ReadAllText(jsonDiretorio);

                if (String.IsNullOrEmpty(jsonString))
                    throw new Exception("Não existe nenhum dado inserido no JSON");

                List<ClienteModel> list = JsonConvert.DeserializeObject<List<ClienteModel>>(jsonString);

                foreach (var item in list)
                {
                    if (item.Id == idCliente)
                    {
                        item.Id = idCliente;
                        item.Nome = clienteModel.Nome;
                        item.Contato = clienteModel.Contato;
                        item.Cpf = clienteModel.Cpf;
                        item.Rg = clienteModel.Rg;
                        item.Endereco = clienteModel.Endereco;
                    }
                    else 
                        continue;

                    atualizado = item;
                }

                string clienteToJson = JsonConvert.SerializeObject(list, Formatting.Indented);

                File.WriteAllText(jsonDiretorio, clienteToJson);

                return atualizado;

            }
            catch(Exception ex)
            {
                throw new Exception("Houve um erro ao atualizar dado no arquivo JSON : " + ex.Message);
            }
        }

        public ClienteModel RemoverCliente(int idCliente)
        {
            try
            {
                ClienteModel removerCliente = new ClienteModel();

                string jsonString = File.ReadAllText(jsonDiretorio);

                if (String.IsNullOrEmpty(jsonString))
                    throw new Exception("Não existe nenhum dado inserido no JSON");

                List<ClienteModel> list = JsonConvert.DeserializeObject<List<ClienteModel>>(jsonString);

                removerCliente = list.FirstOrDefault(c => c.Id == idCliente);

                if(removerCliente == null)
                    throw new Exception("Insira um id valido!!");

                list.Remove(removerCliente);

                string clienteToJson = JsonConvert.SerializeObject(list, Formatting.Indented);

                File.WriteAllText(jsonDiretorio, clienteToJson);

                return removerCliente;
            }
            catch(Exception ex)
            {
                throw new Exception("Houve um erro ao excluir no arquivo JSON : " + ex.Message);
            }
        }
    }
}
