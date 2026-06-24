namespace WorkoutClientApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(Form1));

            Font labelFont = new Font("Segoe UI", 12F, FontStyle.Bold);

            dgWorkouts = new DataGridView();
            lblWorkoutId = new Label();
            lblExercise = new Label();
            lblSets = new Label();
            lblReps = new Label();
            lblWeight = new Label();
            lblDate = new Label();
            txtWorkoutId = new TextBox();
            txtExercise = new TextBox();
            txtSets = new TextBox();
            txtReps = new TextBox();
            txtWeight = new TextBox();
            txtDate = new MaskedTextBox();
            btnLoad = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dgWorkouts).BeginInit();
            SuspendLayout();
            //
            // dgWorkouts (grid)
            //
            dgWorkouts.AllowUserToAddRows = false;
            dgWorkouts.BackgroundColor = Color.FromArgb(20, 20, 20);
            dgWorkouts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgWorkouts.Location = new Point(12, 12);
            dgWorkouts.Name = "dgWorkouts";
            dgWorkouts.ReadOnly = true;
            dgWorkouts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgWorkouts.MultiSelect = false;
            dgWorkouts.Size = new Size(838, 165);
            dgWorkouts.TabIndex = 0;
            dgWorkouts.SelectionChanged += dgWorkouts_SelectionChanged;
            //
            // labels (bold white, transparent)
            //
            lblWorkoutId.AutoSize = true; lblWorkoutId.Font = labelFont; lblWorkoutId.ForeColor = Color.White; lblWorkoutId.BackColor = Color.Transparent; lblWorkoutId.Location = new Point(430, 302); lblWorkoutId.Text = "WorkoutId";
            lblExercise.AutoSize = true; lblExercise.Font = labelFont; lblExercise.ForeColor = Color.White; lblExercise.BackColor = Color.Transparent; lblExercise.Location = new Point(430, 342); lblExercise.Text = "Exercise";
            lblSets.AutoSize = true; lblSets.Font = labelFont; lblSets.ForeColor = Color.White; lblSets.BackColor = Color.Transparent; lblSets.Location = new Point(430, 382); lblSets.Text = "Sets";
            lblReps.AutoSize = true; lblReps.Font = labelFont; lblReps.ForeColor = Color.White; lblReps.BackColor = Color.Transparent; lblReps.Location = new Point(430, 422); lblReps.Text = "Reps";
            lblWeight.AutoSize = true; lblWeight.Font = labelFont; lblWeight.ForeColor = Color.White; lblWeight.BackColor = Color.Transparent; lblWeight.Location = new Point(430, 462); lblWeight.Text = "Weight (lbs)";
            lblDate.AutoSize = true; lblDate.Font = labelFont; lblDate.ForeColor = Color.White; lblDate.BackColor = Color.Transparent; lblDate.Location = new Point(430, 502); lblDate.Text = "Date (dd-MM-yyyy)";
            //
            // textboxes (all share x=620; rows at y=300,340,380,420,460,500)
            //
            txtWorkoutId.Location = new Point(620, 300); txtWorkoutId.Name = "txtWorkoutId"; txtWorkoutId.ReadOnly = true; txtWorkoutId.Size = new Size(170, 25);
            txtExercise.Location = new Point(620, 340); txtExercise.Name = "txtExercise"; txtExercise.Size = new Size(170, 25);
            txtSets.Location = new Point(620, 380); txtSets.Name = "txtSets"; txtSets.Size = new Size(170, 25);
            txtReps.Location = new Point(620, 420); txtReps.Name = "txtReps"; txtReps.Size = new Size(170, 25);
            txtWeight.Location = new Point(620, 460); txtWeight.Name = "txtWeight"; txtWeight.Size = new Size(170, 25);
            txtDate.Location = new Point(620, 500);
            txtDate.Name = "txtDate";
            txtDate.Size = new Size(170, 25);
            txtDate.Mask = "00-00-0000";
            txtDate.PromptChar = ' ';
            //
            // buttons — SPREAD across the box height.
            // Boxes span y=300 (top of first) to y=525 (bottom of last, 500+25).
            // 5 buttons, height 38, evenly placed so top aligns with first box
            // and last aligns with the bottom box. Slightly bigger + bold.
            //
            Font btnFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLoad.Location = new Point(810, 300); btnLoad.Size = new Size(125, 38); btnLoad.Font = btnFont; btnLoad.Text = "Load Workouts"; btnLoad.Click += btnLoad_Click;
            btnAdd.Location = new Point(810, 347); btnAdd.Size = new Size(125, 38); btnAdd.Font = btnFont; btnAdd.Text = "Add Workout"; btnAdd.Click += btnAdd_Click;
            btnUpdate.Location = new Point(810, 394); btnUpdate.Size = new Size(125, 38); btnUpdate.Font = btnFont; btnUpdate.Text = "Update"; btnUpdate.Click += btnUpdate_Click;
            btnDelete.Location = new Point(810, 441); btnDelete.Size = new Size(125, 38); btnDelete.Font = btnFont; btnDelete.Text = "Delete"; btnDelete.Click += btnDelete_Click;
            btnClear.Location = new Point(810, 487); btnClear.Size = new Size(125, 38); btnClear.Font = btnFont; btnClear.Text = "Clear"; btnClear.Click += btnClear_Click;
            //
            // Form1
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(950, 555);

            BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            BackgroundImageLayout = ImageLayout.Stretch;

            Controls.Add(dgWorkouts);
            Controls.Add(lblWorkoutId); Controls.Add(lblExercise); Controls.Add(lblSets);
            Controls.Add(lblReps); Controls.Add(lblWeight); Controls.Add(lblDate);
            Controls.Add(txtWorkoutId); Controls.Add(txtExercise); Controls.Add(txtSets);
            Controls.Add(txtReps); Controls.Add(txtWeight); Controls.Add(txtDate);
            Controls.Add(btnLoad); Controls.Add(btnAdd); Controls.Add(btnUpdate);
            Controls.Add(btnDelete); Controls.Add(btnClear);
            Name = "Form1";
            Text = "Workout Tracker - Assignment 11.3";
            ((System.ComponentModel.ISupportInitialize)dgWorkouts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridView dgWorkouts;
        private Label lblWorkoutId, lblExercise, lblSets, lblReps, lblWeight, lblDate;
        private TextBox txtWorkoutId, txtExercise, txtSets, txtReps, txtWeight;
        private MaskedTextBox txtDate;
        private Button btnLoad, btnAdd, btnUpdate, btnDelete, btnClear;
    }
}