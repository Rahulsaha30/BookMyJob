using Microsoft.Identity.Client;
using SharedLibrary.Dto;

namespace StudentService.Service
{
  public class JobServiceClient
  {
    private readonly ConsulServiceResolver _resolver;
    private readonly HttpClient _httpclient;
    public JobServiceClient(ConsulServiceResolver resolver, HttpClient httpClient)
    {
      _httpclient = httpClient;
      _resolver = resolver;
    }

    public async Task<List<JobPostDetails>> Getalljobs()
    {
      var serviceuri = await _resolver.GetService("adminservice");
      if (serviceuri == null) return new List<JobPostDetails>();
      var response = await _httpclient.GetFromJsonAsync<List<JobPostDetails>>($"{serviceuri}/api/admin/JobPost");
      return response ?? new();
    }
    
     public async Task<bool> JobExistsAsync(Guid jobId)
    {
        var serviceUri = await _resolver.GetService("adminservice");
        if (serviceUri == null) return false;

        var response = await _httpclient.GetAsync($"{serviceUri}/api/admin/JobPost/{jobId}");
        return response.IsSuccessStatusCode;
    }
  }
}