using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BoardsService.Models
{
    [Table("LIST", Schema = "board_service")]
    public class BoardList
    {
        /*  This class represents a Weak entity
         *  for a non-identifying relationship
         */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public short Position { get; set; }

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
