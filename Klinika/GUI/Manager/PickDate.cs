using Klinika.Services;
using Klinika.Utilities;

namespace Klinika.GUI.Manager
{
    public partial class PickDate : Form
    {
        GUI.Manager.Main main;
        Models.EquipmentTransfer transfer;
        bool isTransferFrom = false;
        Form parent;
        public PickDate(GUI.Manager.Main m)
        {
            main = m;
            InitializeComponent();
        }


        public PickDate(Models.EquipmentTransfer transfer,bool isTransferFrom,Form parent)
        {
            
            this.transfer = transfer;
            this.isTransferFrom = isTransferFrom;
            this.parent = parent;
            InitializeComponent();
            SetFormCommandStates();

        }

        private void SetFormCommandStates()
        {
            if(isTransferFrom)
            {
                roomSource.Text = "Source room";
                dateTimePicker.Value = DateTime.Now.Date;
                dateTimePicker.Enabled = false;
            }
            else
            {
                //Add logic for Manager
            }
        }

        private void PickDate_Load(object sender, EventArgs e)
        {
            dateTimePicker.MinDate = DateTime.Now;
            List<Models.EnhancedComboBoxItem> rooms = Services.RoomServices.GetRooms();
            foreach (Models.EnhancedComboBoxItem room in rooms)
            {
                if((isTransferFrom && (int.Parse(room.value.ToString())) != transfer.toId) || (!isTransferFrom && int.Parse(room.value.ToString()) != transfer.fromId))
                    roomComboBox.Items.Add(room);
            }
            roomComboBox.SelectedIndex = 0;
        }

        private bool TransferReady()
        {
            bool ok = true;
            if (!int.TryParse(quantityTextBox.Text.Trim(), out _))
            {
                MessageBox.Show("You must choose a number for quantity.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ok = false;
            }
            else if (transfer.quantity == 0)
            {
                MessageBox.Show("You must choose a not 0 value for quantity.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ok = false;
            }
            else if (int.Parse(quantityTextBox.Text.Trim()) > transfer.maxQuantity)
            {
                MessageBox.Show("Can not transfer that much.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ok = false;
            }
            else if (int.Parse(quantityTextBox.Text.Trim()) <= 0)
            {
                MessageBox.Show("Can not transfer that much.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ok = false;
            }
            return ok;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            transfer.quantity = int.Parse(quantityTextBox.Text);
            if (TransferReady())
            {
                //transfer.quantity = int.Parse(quantityTextBox.Text);
                transfer.transfer = dateTimePicker.Value.Date;
                if (transfer.transfer.Date == DateTime.Now.Date)
                {
                    Repositories.EquipmentRepository.Transfer(transfer);
                    if(parent.GetType() == typeof(Secretary.mainWindow))
                    {
                        ((Secretary.mainWindow)parent).UpdateLowStockDynamicEquipmentTable(transfer);
                        MessageBoxUtilities.ShowSuccessMessage("Equipment successfully transferred!");
                    }
                }
                else
                {
                    Repositories.EquipmentRepository.TransferRequest(main.transfer);
                }

                //U dont need it
                //main.Main_Load(null, EventArgs.Empty);
                this.Close();
            }
        }

        private void roomComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedRoomId = int.Parse(((Models.EnhancedComboBoxItem)roomComboBox.Items[roomComboBox.SelectedIndex]).value.ToString());
            if (isTransferFrom)
            {
                transfer.fromId = selectedRoomId;
                transfer.maxQuantity = EquipmentService.GetQuantity(selectedRoomId, transfer.equipment);
                maxQuantityLabel.Text = "Maximum quantity: " + transfer.maxQuantity.ToString();
                return;
            }
            
            main.transfer.toId = selectedRoomId;
        }
    }
}
