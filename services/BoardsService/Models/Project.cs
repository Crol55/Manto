using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardsService.Models
{
    /* 
     * If nullable is enabled, then [required] attribute is not neccesary
     * on every property (all are required by 'convention'), unless its annotated with '?'.
     */
    [Table("PROJECT", Schema = "board_service")]
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [StringLength(100)]
        public string Nombre { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("Updated_at")]
        public DateTime UpdatedAt { get; set; }

        [Column("USER_id")]
        public string UserId { get; set; }
    }
}
