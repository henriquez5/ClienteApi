using System.ComponentModel.DataAnnotations;

namespace FourBioApi.Models.BaseEntity
{
    public abstract class BaseModel
    {
        [Required]
        public int Id { get; set; }
    }
}
