namespace WorkoutAPIDemo
{
    public class Workout
    {
        public int WorkoutId { get; set; }
        public string Exercise { get; set; } = string.Empty;
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int Weight { get; set; }
        public DateOnly Date { get; set; }
    }
}