﻿using System;
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
        public Main()
        {
            InitializeComponent();
        }

        public void Main_Load(object sender, EventArgs e)
        {
            roomsTable.DataSource = Repositories.RoomRepository.GetAll();
            roomsTable.ClearSelection();
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
        }
    }
}
