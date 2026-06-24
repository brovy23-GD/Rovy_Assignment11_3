using Microsoft.EntityFrameworkCore;   // gives us DbContext, DbSet, ModelBuilder

namespace WorkoutAPIDemo
{
    // A DbContext is the bridge between your C# code and the database.
    // It turns C# objects into database rows and back again, so you never
    // write raw SQL yourself.
    public class WorkoutContext : DbContext
    {
        // The constructor receives settings (like the connection string)
        // from Program.cs and hands them to the base DbContext.
        public WorkoutContext(DbContextOptions<WorkoutContext> options) : base(options)
        {
        }

        // This DbSet represents the "Workouts" table.
        // Querying _context.Workouts is like saying "SELECT * FROM Workouts".
        public DbSet<Workout> Workouts { get; set; }

        // OnModelCreating runs when EF builds the database model.
        // We use it to insert starter rows (seed data) on first creation.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // SEED DATA: rows inserted when the database file is first created.
            // Each "new Workout { ... }" is one row in the Workouts table.
            // WorkoutId is set by hand and MUST be unique (1,2,3,4,5).
            modelBuilder.Entity<Workout>().HasData(

                // Sets = number of groups, Reps = lifts per group, Weight = lbs
                new Workout { WorkoutId = 1, Exercise = "Bench Press", Sets = 4, Reps = 8, Weight = 185, Date = new DateOnly(2026, 6, 23) },

                // heavier compound lift, fewer reps
                new Workout { WorkoutId = 2, Exercise = "Squat", Sets = 5, Reps = 5, Weight = 225, Date = new DateOnly(2026, 6, 23) },

                // DateOnly(year, month, day) — note this one is a different day
                new Workout { WorkoutId = 3, Exercise = "Deadlift", Sets = 3, Reps = 5, Weight = 275, Date = new DateOnly(2026, 6, 24) },

                // accessory lift: lighter weight, higher reps
                new Workout { WorkoutId = 4, Exercise = "Dumbbell Curls", Sets = 3, Reps = 12, Weight = 30, Date = new DateOnly(2026, 6, 24) },

                // back exercise; the IDs just keep counting up
                new Workout { WorkoutId = 5, Exercise = "Lat Rows", Sets = 4, Reps = 10, Weight = 120, Date = new DateOnly(2026, 6, 24) }
            );
        }
    }
}