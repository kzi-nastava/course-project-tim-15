using Klinika.Core;
using Klinika.Rooms.Services;

namespace Klinika.GUI.Manager
{
    public partial class Merge : Form
    {
        Rooms.Models.Renovation renovation;
        public Merge(Rooms.Models.Renovation r)
        {
            InitializeComponent();
            renovation = r;
        }

        private void Merge_Load(object sender, EventArgs e)
        {
            List<EnhancedComboBoxItem> rooms = RoomServices.GetRooms();
            foreach (EnhancedComboBoxItem room in rooms)
            {
                if (int.Parse(room.value.ToString()) != renovation.id)
                    roomComboBox.Items.Add(room);
            }
            roomComboBox.SelectedIndex = 0;
        }

        private void pickButton_Click(object sender, EventArgs e)
        {
            renovation.secondId = int.Parse(((EnhancedComboBoxItem)roomComboBox.Items[roomComboBox.SelectedIndex]).value.ToString());
            if (!RoomServices.IsRoomRenovating(renovation.secondId, renovation.from, renovation.to))
            {
                //if (Repositories.RoomRepository.Renovate(renovation))
                //{
                //    MessageBox.Show("Room successfully set for renovation!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    this.Close();
                //}
                //else
                //{
                //    MessageBox.Show("Invalid input.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
            }
            else
            {
                MessageBox.Show("Can not renovate this room at this time!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
