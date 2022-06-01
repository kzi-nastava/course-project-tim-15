using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Forms
{
    internal abstract class CustomTable<T> : DataGridView
    {
        private List<T> items;
        protected string[] header;
        public CustomTable(string[] header) : base()
        {
            this.header = header;
            items = new List<T>();
            CreateTable();
        }
        private void CreateTable()
        {
            DataTable data = new DataTable();
            foreach (string column in header) data.Columns.Add(column);
            DataSource = data;
        }
        public int GetSelectedID()
        {
            return Convert.ToInt32(SelectedRows[0].Cells["ID"].Value);
        }
        public int DeleteSelected()
        {
            var id = GetSelectedID();
            Rows.RemoveAt(CurrentRow.Index);
            return id;
        }
        abstract protected void Insert(T item);
        abstract public void ModifySelected(T item);
        abstract public T GetSelected();
    }
}
