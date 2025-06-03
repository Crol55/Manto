using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BoardsService.Models
{
    [Table("LIST", Schema = "board_service")]
    [PrimaryKey(nameof(Name), nameof(BoardId))]
    public class BoardList
    {
        /*  this class is a Weak entity
         *  So it will have a composite primary key (because of the identifying relationship)
         */
        [MaxLength(100)]
        public string Name { get; set; }

        public int Position { get; set; }

        [Column("created_at")]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public DateOnly CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } 

        [Column("BOARD_id")]
        public Guid BoardId { get; set; }  // Foreign-key property

        //  Reference-navigation: if <nullable> is active then, the reference-navigation must match the foreign key's nullability [BoardId]
        public Board Board { get; set; }  // reference-navigation  
    }
}
