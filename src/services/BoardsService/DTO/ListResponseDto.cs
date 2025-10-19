namespace BoardsService.DTO;

public record ListResponseDto (Guid Id, string Name, short Position, Guid BoardId);
