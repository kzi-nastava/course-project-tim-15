namespace Klinika.Models
{
    public class Equipment
    {
        public int id { get; set; }
        public string name { get; set; }
        public int roomID { get; set; }
        public int quantity { get; set; }
        public int spent { get; set; }

        public Equipment(int id, string name, int roomID, int quantity)
        {
            this.id = id;
            this.name = name;
            this.roomID = roomID;
            this.quantity = quantity;
            spent = 0;
        }

        public int GetNewQuantity()
        {
            return quantity - spent;
        }
    }
}
