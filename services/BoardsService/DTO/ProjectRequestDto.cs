using System.ComponentModel.DataAnnotations;

namespace BoardsService.DTO
{
    public class ProjectRequestDto
    {
        [MaxLength(50)]
        public string Nombre { get; set; }
    }
}
