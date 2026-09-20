using LocalFix.Api.Models;

namespace LocalFix.Api.Services;

public class ServiceRequestService
{
    private readonly List<ServiceRequest> _requests = [];

    // Returns a list of all service requests
    public List<ServiceRequest> GetAllRequests()
    {
        return _requests;
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

        _requests.Add(request);
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
    public void UpdateRequest(int id, string newTitle, string newDescription, string newCategory, RequestStatus newStatus)
    {
        // Avoids duplicate logic across different methods
        ServiceRequest request = GetById(id);

        request.Title = newTitle;
        request.Description = newDescription;
        request.Category = newCategory;
        request.Status = newStatus;
    }

    // Delete a request using a specified ID
    public void DeleteRequest(int id)
    {
        // Avoids duplicate logic across different methods
        ServiceRequest request = GetById(id);

        _requests.Remove(request);
    }
}

    