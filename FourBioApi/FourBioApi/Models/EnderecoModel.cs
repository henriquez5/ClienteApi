using System.ComponentModel.DataAnnotations;

namespace FourBioApi.Models
{
    public class EnderecoModel
    {
        [Required]
        public string CEP { get; set; }

        [Required]
        public string Logradouro { get; set; }

        public string? Numero { get; set; }

        [Required]
        public string Bairro { get; set; }

        public string? Complemento { get; set; }

        [Required]
        [MaxLength(70)]
        public string Cidade {  get; set; }

        [Required]
        public string Estado { get; set; }

        public string? Referencia { get; set; }

    }
}