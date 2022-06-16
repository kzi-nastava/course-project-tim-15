using Klinika.Core.Dependencies;
using Klinika.Drugs.Models;
using Klinika.Drugs.Services;
using Klinika.Rooms.Models;
using Klinika.Questionnaries.Services;
using Microsoft.Extensions.DependencyInjection;
using Klinika.Rooms.Services;
using System.Data;

namespace Klinika.GUI.Manager
{
    public partial class Main : Form
    {
        private readonly DrugService? drugService;
        private readonly IngredientService? ingredientService;
        private readonly RoomServices? roomService;
        private readonly EquipmentService? equipmentService;
        private readonly QuestionnaireService? questionnaireService;
        public EquipmentTransfer transfer;
        public DataTable unfiltered;
        public bool[] transferCheck;
        public Main()
        {
            transferCheck = new bool[2];
            transferCheck[0] = false;
            transferCheck[1] = false;
            questionnaireService = StartUp.serviceProvider.GetService<QuestionnaireService>();
            drugService = StartUp.serviceProvider.GetService<DrugService>();
            ingredientService = StartUp.serviceProvider.GetService<IngredientService>();
            roomService = StartUp.serviceProvider.GetService<RoomServices>();
            equipmentService = StartUp.serviceProvider.GetService<EquipmentService>();
            transfer = new EquipmentTransfer();
            unfiltered = new DataTable();
            InitializeComponent();
        }

        public void Main_Load(object sender, EventArgs e)
        {
            equipmentComboBox.Items.Clear();
            roomComboBox.Items.Clear();
            quantityComboBox.Items.Clear();

            questionnaireTable.Fill(questionnaireService.GetAll());
            drugsTable1.Fill(drugService.GetAll());
            ingredientsTable.Fill(ingredientService.GetAll());
            roomTable.Fill(roomService.GetExaminationRooms());
            equipTable.Fill(equipmentService.GetDynamicEquipmentInRooms());
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
        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult deletionConfirmation = MessageBox.Show("Are you sure you want to delete the selected room? This action cannot be undone.", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (deletionConfirmation == DialogResult.Yes)
            {
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
            selectedRoom[0] = (int)roomTable.SelectedRows[0].Cells["ID"].Value;
            selectedRoom[2] = (int)roomTable.SelectedRows[0].Cells["Number"].Value;
            new ModifyRoom(this, selectedRoom).Show();
        }

        private void roomTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if((int)roomTable.SelectedRows[0].Cells["ID"].Value != 0)
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

                equipmentTable.DataSource = filtered;
            }
            catch (System.InvalidOperationException ex)
            {
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
            new Renovation((int)roomTable.SelectedRows[0].Cells["ID"].Value, this).Show();
        }

        private void addIngredientsButton_Click(object sender, EventArgs e)
        {
            new ChangeIngredient(-1, this).Show();
        }

        private void deleteIngredientsButton_Click(object sender, EventArgs e)
        {
            DialogResult deletionConfirmation = MessageBox.Show("Are you sure you want to delete the selected ingredient? This action cannot be undone.", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (deletionConfirmation == DialogResult.Yes)
            {
                MessageBox.Show("Room successfully deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Main_Load(null, EventArgs.Empty);
            }
        }

        private void addDrugButton_Click(object sender, EventArgs e)
        {
            Drug drug = new Drug();
            drug.id = -1;
            new ChangeDrug(drug, this).Show();
        }

        private void modifyDrugButton_Click(object sender, EventArgs e)
        {
            Drug drug = drugsTable1.GetSelectedDrug();
            new ChangeDrug(drug, this).Show();
        }
    }
}
