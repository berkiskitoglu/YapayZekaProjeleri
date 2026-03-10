using NetCoreAI.Project02_ApiConsumeUI.Services.Abstract;
using NetCoreAI.Project02_ApiConsumeUI.Services.Concrete;

namespace NetCoreAI.Project02_ApiConsumeUI.Extension
{
    public static class ApiServiceExtensions
    {
        public static IServiceCollection AddApiServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var baseUrl = configuration.GetValue<string>("ApiSettings:BaseUrl");

            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                throw new InvalidOperationException("ApiSettings:BaseUrl appsettings.json içinde bulunamadı.");
            }

            services.AddHttpClient("CustomerApi", client =>
            {
                client.BaseAddress = new Uri(baseUrl);
            });
            services.AddScoped<ICustomerService, CustomerService>();



            return services;
        }


    }

}
