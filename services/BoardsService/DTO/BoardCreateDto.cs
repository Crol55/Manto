using System.ComponentModel.DataAnnotations;

namespace BoardsService.DTO
{
    public record BoardCreateDto
    {
        /*
           'Referenced types' have an implicit [required] annotation
           if <nullable> is active in the project

            The '?' will remove the implicit [required] on a REFERENCE-TYPE
       */
        [MaxLength(50)]
        public string Name { get; set; }

        // Guid is a Value-type
        public Guid? ProjectId { get; set; }
    }
}
