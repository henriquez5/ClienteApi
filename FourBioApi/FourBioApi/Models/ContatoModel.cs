
using System.ComponentModel.DataAnnotations;

namespace FourBioApi.Models
{
    public class ContatoModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public short DDD { get; set; }

        public long Telefone { get; set; }
    }
}