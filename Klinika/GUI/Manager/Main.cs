using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klinika.GUI.Manager
{
    public partial class Main : Form
    {
        public DataTable unfiltered;
        public Main()
        {
            unfiltered = new DataTable();
            InitializeComponent();
        }

        public void Main_Load(object sender, EventArgs e)
        {
            roomsTable.DataSource = Repositories.RoomRepository.GetAll();
            roomsTable.ClearSelection();
            roomsTable.Columns["ID"].Visible = false;
            unfiltered = Repositories.EquipmentRepository.GetAll();
            equipmentTable.DataSource = unfiltered;
            equipmentTable.Columns["ID"].Visible = false;
            equipmentTable.ClearSelection();

            roomComboBox.Items.Add("");
            equipmentComboBox.Items.Add("");
            quantityComboBox.Items.Add("");
            quantityComboBox.Items.Add("no available");
            quantityComboBox.Items.Add("0-10");
            quantityComboBox.Items.Add("10+");
            for (int i = 0; i < equipmentTable.Rows.Count - 1; i++)
            {
                if (!roomComboBox.Items.Contains(equipmentTable.Rows[i].Cells["Room Type"].Value.ToString()))
                    roomComboBox.Items.Add(equipmentTable.Rows[i].Cells["Room Type"].Value.ToString());

                if (!equipmentComboBox.Items.Contains(equipmentTable.Rows[i].Cells["Equipment Type"].Value.ToString()))
                    equipmentComboBox.Items.Add(equipmentTable.Rows[i].Cells["Equipment Type"].Value.ToString());
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult deletionConfirmation = MessageBox.Show("Are you sure you want to delete the selected room? This action cannot be undone.", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (deletionConfirmation == DialogResult.Yes)
            {
                Repositories.RoomRepository.Delete((int)roomsTable.SelectedRows[0].Cells["ID"].Value);
                MessageBox.Show("Room successfully deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Main_Load(null, EventArgs.Empty);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            new AddRoom(this).Show();
        }

        private void modifyButton_Click(object sender, EventArgs e)
        {
            int[] selectedRoom = new int[3];
            selectedRoom[0] = (int)roomsTable.SelectedRows[0].Cells["ID"].Value;
            selectedRoom[1] = Repositories.RoomRepository.GetTypeId(roomsTable.SelectedRows[0].Cells["Type"].Value.ToString());
            selectedRoom[2] = (int)roomsTable.SelectedRows[0].Cells["Number"].Value;
            new ModifyRoom(this, selectedRoom).Show();
        }

        private void roomsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            deleteButton.Enabled = true;
            modifyButton.Enabled = true;
        }

        protected void filter()
        {
            try
            {
                DataTable filtered = unfiltered;
                filtered = filtered.AsEnumerable()
                    .Where(row => row.Field<int>("Number").ToString().Contains(numberTextBox.Text)
                    && row.Field<string>("Room Type").ToString().Contains(roomTypeTextBox.Text)
                    && row.Field<string>("Equipment").ToString().Contains(equipmentTextBox.Text)
                    && row.Field<string>("Equipment Type").ToString().Contains(typeTextBox.Text)
                    && row.Field<int>("Quantity").ToString().Contains(quantityTextBox.Text)
                    ).CopyToDataTable();
                //MessageBox.Show(roomComboBox.SelectedText);
                if (roomComboBox.SelectedText != "")
                {
                    filtered = filtered.AsEnumerable()
                        .Where(row => row.Field<string>("Room Type").ToString() == roomComboBox.SelectedText).CopyToDataTable();
                }
                if (equipmentComboBox.SelectedText != "")
                {
                    filtered = filtered.AsEnumerable()
                        .Where(row => row.Field<string>("Equipment Type").ToString() == equipmentComboBox.SelectedText).CopyToDataTable();
                }
                if (quantityComboBox.SelectedText != "")
                {
                    if (quantityComboBox.SelectedText == "no available")
                    {
                        filtered = filtered.AsEnumerable()
                            .Where(row => row.Field<int>("Quantity") == 0).CopyToDataTable();
                    }
                    else if (quantityComboBox.SelectedText == "0-10")
                    {
                        filtered = filtered.AsEnumerable()
                            .Where(row => row.Field<int>("Quantity") > 0 || row.Field<int>("Quantity") < 10).CopyToDataTable();
                    }
                    else if (quantityComboBox.SelectedText == "10+")
                    {
                        filtered = filtered.AsEnumerable()
                            .Where(row => row.Field<int>("Quantity") >= 10).CopyToDataTable();
                    }
                }
                equipmentTable.DataSource = filtered;
            }
            catch (System.InvalidOperationException ex)
            {
                MessageBox.Show("This filter leaves the table empthy!");
            }
        }

        private void numberTextBox_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void roomTypeTextBox_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void equipmentTextBox_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void typeTextBox_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void quantityTextBox_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void roomComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void equipmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void quantityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            filter();
        }
    }
}
