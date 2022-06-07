namespace Klinika.Forms.Base
{
    public abstract class ReadonlyTableBase<T> : TableBase
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
    }
}
