﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Forms.Base
{
    public abstract class TableBase<T> : DataGridView
    {
        protected List<T> items;
        public TableBase() : base()
        {
            items = new List<T>();

            BackgroundColor = Color.White;
            AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            ReadOnly = true;
            MultiSelect = false;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        public abstract void Fill(List<T> items);
        protected object GetCellValue(string columnName)
        {
            return SelectedRows[0].Cells[columnName].Value;
        }
    }
}
