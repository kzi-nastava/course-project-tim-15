namespace Klinika.Forms.Base
{
    public abstract class ViewOnlyTableBase<T> : TableBase<T>
    {
        
        public ViewOnlyTableBase() : base()
        {
            SetUp();
        }
        private void SetUp()
        {
            SelectionChanged += delegate { ClearSelection(); };
        }
    }
}
