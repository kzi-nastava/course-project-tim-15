using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Models;
using Klinika.Data;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace Klinika.Repositories
{
    internal class AppointmentRepository
    {
        public static Dictionary<int, Appointment>? Appointments { get; set; }

        /// <summary>
        /// Returns all appointmets of requested day in format "yyyy-MM-dd"
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DataTable? GetAll(string date)
        {
            DateTime start = DateTime.ParseExact($"{date} 00:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            DateTime end = start.AddDays(1);

            Appointments = new Dictionary<int, Appointment>();
            DataTable? retrievedAppointments = null;

            string getAllQuerry = "SELECT * " +
                                  "FROM [MedicalAction] " +
                                  $"WHERE DateTime BETWEEN '{start}' AND '{end}';";
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(getAllQuerry, DatabaseConnection.GetInstance().database);
                retrievedAppointments = new DataTable();
                adapter.Fill(retrievedAppointments);
                foreach (DataRow row in retrievedAppointments.Rows)
                {
                    Appointment appointment = new Appointment(Convert.ToInt32(row["ID"]), Convert.ToInt32(row["DoctorID"]), 
                            Convert.ToInt32(row["PatientID"]), Convert.ToDateTime(row["DateTime"].ToString()),
                            Convert.ToInt32(row["RoomID"]), Convert.ToBoolean(row["Completed"]),Convert.ToChar(row["Type"]), 
                            Convert.ToInt32(row["Duration"]),Convert.ToBoolean(row["Urgent"]), row["Description"].ToString(),
                            Convert.ToBoolean(row["IsDeleted"]));
                    Appointments.TryAdd(appointment.ID, appointment);
                }

            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message);
            }

            return retrievedAppointments;
        }

        public static void Delete(int ID)
        {
            string deleteQuerry = "UPDATE [MedicalAction] SET IsDeleted = 1 WHERE ID = @ID";
            try
            {
                SqlCommand delete = new SqlCommand(deleteQuerry, DatabaseConnection.GetInstance().database);
                delete.Parameters.AddWithValue("@ID", ID);
                DatabaseConnection.GetInstance().database.Open();
                delete.ExecuteNonQuery();
                DatabaseConnection.GetInstance().database.Close();
                if (Appointments != null)
                {
                    Appointments.Remove(ID);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
