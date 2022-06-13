namespace Klinika.GUI.Manager
{
    public partial class ModifyRoom : Form
    {
        Main main;
        int[] selectedRoom;
        public ModifyRoom(Main m, int[] sr)
        {
            main = m;
            selectedRoom = sr;
            InitializeComponent();
        }

        private void ModifyRoom_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < Repositories.RoomRepository.types.Count + 1; i++)
            {
                typeComboBox.Items.Add(Repositories.RoomRepository.types[i]);
            }
            //Room type is the same as index - 1
            typeComboBox.SelectedIndex = selectedRoom[1] - 1;
            idTextBox.Text = selectedRoom[0].ToString();
            numberTextBox.Text = selectedRoom[2].ToString();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //Repositories.RoomRepository.Modify(int.Parse(idTextBox.Text), typeComboBox.Text, int.Parse(numberTextBox.Text));
            MessageBox.Show("Room successfully modified!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            main.Main_Load(null, EventArgs.Empty);
            this.Close();
        }
    }
}
