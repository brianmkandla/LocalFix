using LocalFix.Api.Models;

namespace LocalFix.Api.DTOs;

public class UpdateServiceRequestDto
{
    public required string Title { get; set; }
    public required string Category { get; set; }
    public required string Description { get; set; }
    public required RequestStatus Status { get; set; }
}