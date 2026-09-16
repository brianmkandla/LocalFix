namespace LocalFix.Api.Models;

public class ServiceRequest
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Category { get; set; }
    public required string Description { get; set; }
    public RequestStatus Status { get; set; }
    public DateTime CreatedAt { get; private set; }
    
    public ServiceRequest()
    {
        CreatedAt = DateTime.Now;
    }
}