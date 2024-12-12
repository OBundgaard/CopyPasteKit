namespace API.Additional;

public class MyProgram
{
    public static void Main(string[] args)
    {
        //builder.Services.AddCors(options =>
        //{
        //    options.AddPolicy("AllowAllOrigins",
        //        builder =>
        //        {
        //            builder.AllowAnyOrigin()
        //                   .AllowAnyMethod()
        //                   .AllowAnyHeader();
        //        });
        //});

        //builder.Services.AddMemoryCache();

        //builder.Services.AddScoped<MyClassRepository>();
        //builder.Services.AddScoped<IRepository<MyClass>, MyClassCachedRepository>();

        //builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyDatabaseConnection"), sqlOptions =>
        //{
        //    sqlOptions.EnableRetryOnFailure(
        //        maxRetryCount: 5,
        //        maxRetryDelay: TimeSpan.FromSeconds(10),
        //        errorNumbersToAdd: null
        //    );
        //}));

        //app.UseOcelot().Wait(); // API GATEWAY ONLY

        //app.UseCors();
    }
}
