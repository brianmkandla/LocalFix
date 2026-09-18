namespace LocalFix.Api.DTOs;

public class CreateServiceRequestDto
{
    public required string Title { get; set; }
    public required string Category { get; set; }
    public required string Description { get; set; }
}