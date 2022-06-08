namespace Klinika.Models
{
    public class Equipment
    {
        
        public enum EquipmentType {CHECKUP = 1, OPERATION, FURNITURE, HALLWAY, DYNAMIC };
        public int id { get; set; }
        public string name { get; set; }
        public int roomID { get; set; }
        public int roomNumber { get; set; }
        public int quantity { get; set; }
        public int spent { get; set; }
        public  EquipmentType type { get; }

        public Equipment(int id, string name, int roomID, int quantity)
        {
            this.id = id;
            this.name = name;
            this.roomID = roomID;
            this.quantity = quantity;
            spent = 0;
        }

        public Equipment(int id, string name, int roomID, int roomNumber, int quantity) : this(id, name, roomID, quantity)
        {
            this.roomNumber = roomNumber;
        }

        public Equipment(int id, string name, int roomID, int quantity, EquipmentType type) : this(id, name, roomID, quantity)
        {
            this.type = type;
        }

        public int GetNewQuantity()
        {
            return quantity - spent;
        }
    }
}
