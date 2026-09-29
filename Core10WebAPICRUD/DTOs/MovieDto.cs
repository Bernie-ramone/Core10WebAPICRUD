namespace Core10WebAPICRUD.DTOs;

public record MovieDto(
    Guid id,
    string Title,
    string Genre,
    DateTimeOffset ReleaseDate,
    double Rating);
