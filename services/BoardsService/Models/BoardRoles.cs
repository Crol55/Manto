using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardsService.Models;

[Table("BOARD_ROLES", Schema = "board_service")]
public class BoardRoles
{
    [Key]
    public byte Id { get; init; }

    [Column("role_name")]
    [MaxLength(50)]
    public string RoleName { get; init; }

    [MaxLength(500)]
    public string Description { get; init; }
}
