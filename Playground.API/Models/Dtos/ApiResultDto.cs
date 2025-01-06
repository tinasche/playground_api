namespace Playground.API.Models.Dtos;

public record ApiResultDto(string Message, bool Success, object? Data = null);