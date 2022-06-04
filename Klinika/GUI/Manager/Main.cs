using System.Data;

namespace Klinika.GUI.Manager
{
    public partial class Main : Form
    {
        public Models.EquipmentTransfer transfer;
        public DataTable unfiltered;
        public bool[] transferCheck;
        public Main()
        {
            transferCheck = new bool[2];
            transferCheck[0] = false;
            transferCheck[1] = false;
            transfer = new Models.EquipmentTransfer();
            unfiltered = new DataTable();
            InitializeComponent();
        }

        public void Main_Load(object sender, EventArgs e)
        {
            equipmentComboBox.Items.Clear();
            roomComboBox.Items.Clear();
            quantityComboBox.Items.Clear();

            FillTables();
            FillComboBox();
        }

        private void FillComboBox()
        {
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
            roomComboBox.SelectedIndex = 0;
            equipmentComboBox.SelectedIndex = 0;
            quantityComboBox.SelectedIndex = 0;
        }

        private void FillDrugs()
        {
            DataTable table = new DataTable();
            table.Columns.Add("id", typeof(string));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Approved", typeof(string));

            List<Models.Drug> drugs = Services.DrugService.GetUnapproved();
            foreach (Models.Drug drug in drugs)
            {
                DataRow dr = table.NewRow();

                dr[0] = drug.id;
                dr[1] = drug.name;
                dr[2] = drug.approved;

                table.Rows.Add(dr);
            }

            drugsTable.DataSource = table;
            drugsTable.Columns[0].Visible = false;
        }

        private void FillIngedients()
        {
            DataTable table = new DataTable();
            table.Columns.Add("id", typeof(string));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Type", typeof(string));

            List<Models.Ingredient> ingredients = Services.IngredientService.GetAll();
            foreach (Models.Ingredient ingredient in ingredients)
            {
                DataRow dr = table.NewRow();

                dr[0] = ingredient.id;
                dr[1] = ingredient.name;
                dr[2] = ingredient.type;

                table.Rows.Add(dr);
            }

            ingredientsTable.DataSource = table;
            ingredientsTable.Columns[0].Visible = false;
        }

        private void FillTables()
        {
            DataTable rooms = Repositories.RoomRepository.GetAll();
            DataRow storage = rooms.NewRow();
            storage["ID"] = 0;
            storage["Type"] = "Storage";
            storage["Number"] = 0;
            rooms.Rows.Add(storage);
            roomsTable.DataSource = rooms;
            roomsTable.Columns["ID"].Visible = false;

            unfiltered = Repositories.EquipmentRepository.GetAll();
            equipmentTable.DataSource = unfiltered;
            equipmentTable.Columns["EquipmentID"].Visible = false;
            equipmentTable.Columns["RoomID"].Visible = false;
            equipmentTable.ClearSelection();

            FillDrugs();
            FillIngedients();
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
            if((int)roomsTable.SelectedRows[0].Cells["ID"].Value != 0)
            {
                deleteButton.Enabled = true;
                modifyButton.Enabled = true;
                renovateButton.Enabled = true;
            }
            else
            {
                deleteButton.Enabled = false;
                modifyButton.Enabled = false;
                renovateButton.Enabled = false;
            }
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

                if (roomComboBox.SelectedIndex != -1)
                {
                    if (roomComboBox.Items[roomComboBox.SelectedIndex].ToString() != "")
                    {
                        filtered = filtered.AsEnumerable()
                            .Where(row => row.Field<string>("Room Type").ToString() == roomComboBox.Items[roomComboBox.SelectedIndex].ToString()).CopyToDataTable();
                    }
                }

                if (equipmentComboBox.SelectedIndex != -1)
                {
                    if (equipmentComboBox.Items[equipmentComboBox.SelectedIndex].ToString() != "")
                    {
                        filtered = filtered.AsEnumerable()
                            .Where(row => row.Field<string>("Equipment Type").ToString() == equipmentComboBox.Items[equipmentComboBox.SelectedIndex].ToString()).CopyToDataTable();
                    }
                }

                if (quantityComboBox.SelectedIndex != -1)
                {
                    if (quantityComboBox.Items[quantityComboBox.SelectedIndex].ToString() != "")
                    {
                        if (quantityComboBox.Items[quantityComboBox.SelectedIndex].ToString() == "no available")
                        {
                            filtered = filtered.AsEnumerable()
                                .Where(row => row.Field<int>("Quantity") == 0).CopyToDataTable();
                        }
                        else if (quantityComboBox.Items[quantityComboBox.SelectedIndex].ToString() == "0-10")
                        {
                            filtered = filtered.AsEnumerable()
                                .Where(row => row.Field<int>("Quantity") > 0 && row.Field<int>("Quantity") < 10).CopyToDataTable();
                        }
                        else if (quantityComboBox.Items[quantityComboBox.SelectedIndex].ToString() == "10+")
                        {
                            filtered = filtered.AsEnumerable()
                                .Where(row => row.Field<int>("Quantity") >= 10).CopyToDataTable();
                        }
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

        private void setFrom()
        {
            try
            {
                transfer.fromId = (int)equipmentTable.SelectedRows[0].Cells["RoomID"].Value;
                transfer.equipment = (int)equipmentTable.SelectedRows[0].Cells["EquipmentID"].Value;
                transfer.maxQuantity = (int)equipmentTable.SelectedRows[0].Cells["Quantity"].Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Select a room first");
            }
        }

        private bool checkFrom()
        {
            bool ok = true;
            if (transfer.maxQuantity == 0)
            {
                MessageBox.Show("You must pick a row with not 0 quantity.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ok = false;
            }
            return ok;
        }
        private void dateButton_Click(object sender, EventArgs e)
        {
            setFrom();
            if (checkFrom())
            {
                new PickDate(this).Show();
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void renovateButton_Click(object sender, EventArgs e)
        {
            new Renovation((int)roomsTable.SelectedRows[0].Cells["ID"].Value, this).Show();
        }

        private void addIngredientsButton_Click(object sender, EventArgs e)
        {
            new ChangeIngredient(-1, this).Show();
        }

        private void modifyIngredientsButton_Click(object sender, EventArgs e)
        {
            new ChangeIngredient(int.Parse(ingredientsTable.SelectedRows[0].Cells["id"].Value.ToString()), this).Show();
        }

        private void deleteIngredientsButton_Click(object sender, EventArgs e)
        {
            DialogResult deletionConfirmation = MessageBox.Show("Are you sure you want to delete the selected ingredient? This action cannot be undone.", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (deletionConfirmation == DialogResult.Yes)
            {
                Services.IngredientService.Delete(int.Parse(ingredientsTable.SelectedRows[0].Cells["id"].Value.ToString()));
                MessageBox.Show("Room successfully deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Services.IngredientService.GetAll();
                this.Main_Load(null, EventArgs.Empty);
            }
        }
    }
}
