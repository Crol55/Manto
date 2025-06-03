using System.ComponentModel.DataAnnotations;

namespace BoardsService.DTO
{
    public class ProjectRequestDto
    {
        [MaxLength(100)]
        public string Nombre { get; set; }
    }
}
