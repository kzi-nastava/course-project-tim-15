namespace Klinika.Forms
{
    public abstract class CustomTable<T> : DataGridView
    {
        protected List<T> items;
        public CustomTable() : base()
        {
            items = new List<T>();
            CreateTable();
        }
        abstract protected void CreateTable();
        abstract public void Fill(List<T> items);
        abstract public void Insert(T item);
        abstract public int GetSelectedID();
        abstract public T GetSelected();
        abstract public void ModifySelected(T item);
        abstract public int DeleteSelected();
    }
}
