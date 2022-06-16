using System.Data;
using Klinika.Rooms.Models;

namespace Klinika.Forms
{
    public class RoomTable : Base.TableBase<Room>
    {
        private List<Room> rooms;
        public RoomTable() : base()
        {
            rooms = new List<Room>();
        }
        public override void Fill(List<Room> rooms)
        {
            this.rooms = rooms;

            DataTable roomsData = new DataTable();
            roomsData.Columns.Add("ID");
            roomsData.Columns.Add("Name");
            roomsData.Columns.Add("Number");

            foreach (Room ingredient in rooms)
            {
                DataRow newRow = roomsData.NewRow();
                newRow["ID"] = ingredient.id;
                newRow["Name"] = ingredient.type;
                newRow["Number"] = ingredient.number;
                roomsData.Rows.Add(newRow);
            }

            DataSource = roomsData;
            Columns[0].Width = 30;
            Columns[1].Width = 90;
            ClearSelection();
        }
        public int GetSelectedId()
        {
            return Convert.ToInt32(GetCellValue("ID"));
        }
        public Room GetSelectedRoom()
        {
            return rooms.Where(x => x.id == GetSelectedId()).FirstOrDefault();
        }
    }
}
