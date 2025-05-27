using System.ComponentModel.DataAnnotations;

namespace BoardsService.DTO
{
    public class ListCreateDto
    {
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int? Position { get; set; } 

        [Required]
        public Guid? BoardId { get; set; }
    }
}
