namespace Klinika.Models
{
    internal class EnhancedComboBoxItem
    {
        public string text { get; set; }
        public object value { get; set; }
        public EnhancedComboBoxItem(string t, object v)
        {
            text = t;
            value = v;
        }
        public override string ToString()
        {
            return text;
        }
    }
}
