public class Program
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddScoped<UserRepository>(provider => new UserRepository(Configuration.GetConnectionString("DefaultConnection")));
        services.AddEndpointsApiExplorer();
    }
}