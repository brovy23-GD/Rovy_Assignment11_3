using System.Net.Http;          // HttpClient — talks to the API over the web
using System.Net.Http.Json;     // GetFromJsonAsync helper
using System.Text;              // Encoding.UTF8
using System.Text.Json;         // turns objects <-> JSON text

namespace WorkoutClientApp
{
    public partial class Form1 : Form
    {
        // ONE HttpClient shared for the whole app. BaseAddress is the API's address.
        // *** Must match the API's http port (yours is 5020). ***
        private static readonly HttpClient _http = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5020/")
        };

        // case-insensitive so JSON "exercise" maps to C# "Exercise"
        private static readonly JsonSerializerOptions _json =
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public Form1()
        {
            InitializeComponent();   // builds all the buttons/boxes from the Designer file
        }

        // ---- LOAD: GET every workout and show it in the grid -----------------
        private async void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                // ask the API for the list; await means "wait without freezing the window"
                List<Workout>? workouts = await _http.GetFromJsonAsync<List<Workout>>("api/Workouts");
                dgWorkouts.DataSource = workouts;   // bind the list to the grid
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load failed: " + ex.Message);
            }
        }

        // ---- ADD: POST a new workout -----------------------------------------
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Workout w = ReadInputs();                       // build object from textboxes
                string json = JsonSerializer.Serialize(w);      // object -> JSON text
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage resp = await _http.PostAsync("api/Workouts", content);
                resp.EnsureSuccessStatusCode();                 // throw if the API said "error"

                btnLoad_Click(sender, e);                       // refresh grid
                btnClear_Click(sender, e);                      // empty the boxes
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add failed: " + ex.Message);
            }
        }

        // ---- UPDATE: PUT changes to an existing workout ----------------------
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // need a valid id (filled when you click a grid row)
                if (!int.TryParse(txtWorkoutId.Text, out int id))
                {
                    MessageBox.Show("Select a row first.");
                    return;
                }

                Workout w = ReadInputs();
                w.WorkoutId = id;   // the id in the body must match the id in the URL

                string json = JsonSerializer.Serialize(w);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage resp = await _http.PutAsync($"api/Workouts/{id}", content);
                resp.EnsureSuccessStatusCode();

                btnLoad_Click(sender, e);
                btnClear_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed: " + ex.Message);
            }
        }

        // ---- DELETE: remove a workout by id ----------------------------------
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtWorkoutId.Text, out int id))
                {
                    MessageBox.Show("Select a row first.");
                    return;
                }

                HttpResponseMessage resp = await _http.DeleteAsync($"api/Workouts/{id}");
                resp.EnsureSuccessStatusCode();

                btnLoad_Click(sender, e);
                btnClear_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete failed: " + ex.Message);
            }
        }

        // ---- CLEAR: empty all the input boxes --------------------------------
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtWorkoutId.Clear();
            txtExercise.Clear();
            txtSets.Clear();
            txtReps.Clear();
            txtWeight.Clear();
            txtDate.Clear();
        }

        // ---- When you click a grid row, copy its values into the textboxes ---
        private void dgWorkouts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgWorkouts.CurrentRow?.DataBoundItem is Workout w)
            {
                txtWorkoutId.Text = w.WorkoutId.ToString();
                txtExercise.Text = w.Exercise;
                txtSets.Text = w.Sets.ToString();
                txtReps.Text = w.Reps.ToString();
                txtWeight.Text = w.Weight.ToString();
                // show the date as dd-MM-yyyy (e.g. 23-06-2026)
                txtDate.Text = w.Date.ToString("dd-MM-yyyy");
            }
        }

        // helper: build a Workout object from whatever is typed in the boxes
        private Workout ReadInputs()
        {
            // TryParse safely turns text into numbers (0 if the box is blank/bad)
            int.TryParse(txtSets.Text, out int sets);
            int.TryParse(txtReps.Text, out int reps);
            int.TryParse(txtWeight.Text, out int weight);

            // read the date strictly as dd-MM-yyyy. If blank/invalid, use today.
            if (!DateOnly.TryParseExact(txtDate.Text, "dd-MM-yyyy",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out DateOnly date))
                date = DateOnly.FromDateTime(DateTime.Today);

            return new Workout
            {
                Exercise = txtExercise.Text,
                Sets = sets,
                Reps = reps,
                Weight = weight,
                Date = date
            };
        }

       
    }
}