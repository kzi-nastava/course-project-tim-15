using System.Data;

namespace Klinika.Forms.Base
{
    public abstract class ReadonlyTableBase<T> : DataGridView
    {
        List<T> items;
        public ReadonlyTableBase() : base()
        {
            items = new List<T>();
            SetUp();
        }
        private void SetUp()
        {
            SelectionChanged += delegate { ClearSelection(); };
        }
        abstract public void Fill(List<T> items);

        public object GetCellValue(string columnName)
        {
            return SelectedRows[0].Cells[columnName].Value;
        }
    }
}
