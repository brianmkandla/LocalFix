using LocalFix.Api.Models;
using LocalFix.Api.Data;

namespace LocalFix.Api.Services;

public class ServiceRequestService
{
    private readonly List<ServiceRequest> _requests = [];
    private readonly LocalFixDbContext _dbContext;
    public ServiceRequestService(LocalFixDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    // Returns a list of all service requests
    public List<ServiceRequest> GetAllRequests()
    {
        return _dbContext.ServiceRequests.ToList();
    }

    // Creates and returns service request
    public ServiceRequest CreateRequest(string title, string category, string description)
    {
        ServiceRequest request = new ServiceRequest
        {
            Title = title,
            Category = category,
            Description = description
        };

        if (_requests.Count == 0)
        {
            request.Id = 1;
        }
        else
        {
            request.Id = _requests.Max(request => request.Id) + 1;
        }

        request.Status = RequestStatus.Open;

        // Add to database and save 
        _dbContext.ServiceRequests.Add(request);
        _dbContext.SaveChanges();

        return request;
    }

    // Retrieve a request by ID
    public ServiceRequest? GetById(int id)
    {
       return _requests.FirstOrDefault(request => request.Id == id);
    }

    // Retrieve requests by category
    public List<ServiceRequest> GetByCategory(string category)
    {
        return _requests.Where(request => request.Category == category).ToList();
    } 

    // Retrieve requests by status
    public List<ServiceRequest> GetByStatus(RequestStatus status)
    {
        return _requests.Where(request => request.Status == status).ToList();
    }

    // Updates a request using specified ID
    public ServiceRequest? UpdateRequest(int id, string newTitle, string newDescription, string newCategory, RequestStatus newStatus)
    {
        // Avoids duplicate logic across different methods
        ServiceRequest? request = GetById(id);

        if (request is null)
        {
            return null;
        }

        request.Title = newTitle;
        request.Description = newDescription;
        request.Category = newCategory;
        request.Status = newStatus;

        return request;
    }

    // Delete a request using a specified ID
    public bool DeleteRequest(int id)
    {
        // Avoids duplicate logic across different methods
        ServiceRequest? request = GetById(id);

        if (request is null)
        {
            return false;
        }

        _requests.Remove(request);
        return true;
    }
}

    