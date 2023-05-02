using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace FourBioApi.Models
{
    public class ClienteModel 
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Nome { get; set; }

        public ContatoModel Contato { get; set; }

        [Required]
        [MaxLength(11)]
        public string Cpf { get; set; }

        public string Rg { get; set; }

        public EnderecoModel Endereco { get; set; }

    }
}
