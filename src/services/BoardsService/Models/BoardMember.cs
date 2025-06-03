using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BoardsService.Models;

[Table("BOARD_MEMBER", Schema = "board_service")]
[PrimaryKey( nameof(BoardId), nameof(UserId) )]
public class BoardMember
{
    [Column("BOARD_id")]
    public Guid BoardId { get; init; } // Foreign & primary key

    [Column("USERS_id")]
    public Guid UserId { get; init; } // Foreign & primary key

    [Column("joining_date")]
    [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
    public DateTime JoiningDate { get; init; }

    [Column("BOARD_ROLES_id")]
    public byte BoardRolesId { get; set; } // Foreign key

    //  Reference-navigation: if <nullable> is active then, the reference-navigation must match the foreign key's nullability
    public BoardRoles Role { get; init; }

    public Board Board { get; init; }
}

