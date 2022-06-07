namespace Klinika.GUI.Manager
{
    public partial class Split : Form
    {
        Models.Renovation renovation;
        public Split(Models.Renovation r)
        {
            InitializeComponent();
            renovation = r;
        }

        private void splitButton_Click(object sender, EventArgs e)
        {
            renovation.secondNumber = int.Parse(numberTextBox.Text);
            renovation.secondType = Repositories.RoomRepository.GetTypeId(typeComboBox.Text);
            if (Repositories.RoomRepository.Renovate(renovation))
            {
                MessageBox.Show("Room successfully set for renovation!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid input.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Split_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < Repositories.RoomRepository.types.Count + 1; i++)
            {
                typeComboBox.Items.Add(Repositories.RoomRepository.types[i]);
            }
            typeComboBox.SelectedIndex = 0;
        }
    }
}
