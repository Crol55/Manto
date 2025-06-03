using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BoardsService.Models;

namespace BoardsService.Models
{
    [Table("BOARD", Schema = "board_service")]
    public class Board
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [Column("created_at")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }

        [Column("USER_id")]
        public Guid UserId { get; set;}

        [Column("PROJECT_id")]
        public Guid? ProjectId { get; set; }  //Foreign key property

        // Reference navigation: if <nullable> is active then the reference-navigation must match the foreign key [ProjectId]
        public Project? Project { get; set; } = null; // Reference-navigation

    }
}
