using Consul;

namespace AdminService.Service
{
  public class ConsulServiceResolver
  {
    public readonly IConsulClient _consulClient;
    public ConsulServiceResolver(IConsulClient consulClient)
    {
      _consulClient = consulClient;
    }

    public async Task<string?> GetService(string serviceName)
    {
      var services = await _consulClient.Agent.Services();
      var service = services.Response.Values.FirstOrDefault(s => s.Service.Equals(serviceName, StringComparison.OrdinalIgnoreCase));
      if (service == null) return null;
      return $"http://{service.Address}:{service.Port}";
    }
  }
}