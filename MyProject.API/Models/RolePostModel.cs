using System.ComponentModel.DataAnnotations;

namespace MyProject.API.Models
{
    public class RolePostModel
    {
        public string Name { get; set; }

        [MaxLength(100)]
        public string? Description { get; set; }
    }
}
