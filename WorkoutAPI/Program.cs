using Microsoft.EntityFrameworkCore;   // needed for UseSqlite

namespace WorkoutAPIDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // builder collects all the app's settings and services before it starts.
            var builder = WebApplication.CreateBuilder(args);

            // read the database connection string from appsettings.json
            var connectionString = builder.Configuration.GetConnectionString("WorkoutContext")
                ?? throw new InvalidOperationException("Connection string 'WorkoutContext' not found.");

            // register the parts the API needs:
            builder.Services.AddControllers();           // enables the WorkoutsController
            builder.Services.AddEndpointsApiExplorer();  // helps Swagger discover endpoints
            builder.Services.AddSwaggerGen();            // generates the Swagger test page

            // tell EF Core to use a SQLite file named workouts.db
            builder.Services.AddDbContext<WorkoutContext>(options =>
                options.UseSqlite("Data Source=workouts.db"));

            var app = builder.Build();   // build the finished app

            // only show Swagger while developing (not in production)
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // create (and optionally reset) the database on startup
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<WorkoutContext>();

                //db.Database.EnsureDeleted();   // <-- now active: wipes old DB
                db.Database.EnsureCreated();   // rebuilds with all 5 seed rows
            }

            app.UseAuthorization();   // (no auth used here, but harmless)
            app.MapControllers();     // wires up the /api/Workouts routes
            app.Run();                // start listening for requests
        }
    }
}