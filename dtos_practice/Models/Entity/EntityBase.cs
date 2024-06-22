using System.ComponentModel.DataAnnotations.Schema;

namespace dtos_practice.Models.Entity
{
    public class EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
