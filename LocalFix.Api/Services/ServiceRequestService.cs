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
}

    