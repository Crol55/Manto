namespace BoardsService.DTO
{
    public record BoardResponseDto(Guid BoardId, string Name, DateTime CreatedAt, Guid UserId, Guid? ProjectId);
}
