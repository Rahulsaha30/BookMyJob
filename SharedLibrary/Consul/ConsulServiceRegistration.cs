using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SharedLibrary.Consul
{
  public static class ConsulServiceRegistration
  {
    public static void RegisterConsul(this IApplicationBuilder app, IConfiguration config)
    {
      var lifetime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();
      var consulClient = new ConsulClient(c => c.Address = new Uri("http://localhost:8500"));
      var registration = new AgentServiceRegistration()
      {
        ID = $"studentservice-{Guid.NewGuid()}",
        Name = config["ServiceConfig:ServiceName"],
        Address = config["ServiceConfig:ServiceHost"],
        Port = int.Parse(config["ServiceConfig:ServicePort"])
      };
      consulClient.Agent.ServiceRegister(registration).Wait();
          lifetime.ApplicationStopping.Register(() =>
        {
            consulClient.Agent.ServiceDeregister(registration.ID).Wait();
        });
      
    }
  }
}