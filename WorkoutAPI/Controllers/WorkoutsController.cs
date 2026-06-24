using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WorkoutAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutsController : ControllerBase
    {
        private readonly WorkoutContext _context;

        public WorkoutsController(WorkoutContext context)
        {
            _context = context;
        }

        // GET: api/Workouts  -> all
        [HttpGet]
        public ActionResult<IEnumerable<Workout>> GetWorkouts()
        {
            return _context.Workouts.ToList();
        }

        // GET: api/Workouts/5  -> one by id
        [HttpGet("{id}")]
        public ActionResult<Workout> GetWorkout(int id)
        {
            var workout = _context.Workouts.Find(id);
            if (workout == null)
                return NotFound();
            return workout;
        }

        // POST: api/Workouts  -> create
        [HttpPost]
        public ActionResult<Workout> PostWorkout(Workout workout)
        {
            _context.Workouts.Add(workout);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetWorkout), new { id = workout.WorkoutId }, workout);
        }

        // PUT: api/Workouts/5  -> update
        [HttpPut("{id}")]
        public IActionResult PutWorkout(int id, Workout workout)
        {
            if (id != workout.WorkoutId)
                return BadRequest();

            _context.Entry(workout).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Workouts.Any(w => w.WorkoutId == id))
                    return NotFound();
                throw;
            }
            return NoContent();
        }

        // DELETE: api/Workouts/5  -> delete
        [HttpDelete("{id}")]
        public IActionResult DeleteWorkout(int id)
        {
            var workout = _context.Workouts.Find(id);
            if (workout == null)
                return NotFound();

            _context.Workouts.Remove(workout);
            _context.SaveChanges();
            return NoContent();
        }
    }
}