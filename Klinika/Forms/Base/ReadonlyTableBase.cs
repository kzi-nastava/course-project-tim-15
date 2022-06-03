using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
