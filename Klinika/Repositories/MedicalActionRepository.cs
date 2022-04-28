using Klinika.Data;
using System.Data.SqlClient;

namespace Klinika.Repositories
{
    internal class MedicalActionRepository
    {
        public static void Delete(int id)
        {
            string deleteQuery = "UPDATE [MedicalAction] SET IsDeleted = 1 WHERE ID = @ID";
            try
            {
                SqlCommand delete = new SqlCommand(deleteQuery, DatabaseConnection.GetInstance().database);
                delete.Parameters.AddWithValue("@ID", id);
                DatabaseConnection.GetInstance().database.Open();
                delete.ExecuteNonQuery();
                DatabaseConnection.GetInstance().database.Close();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }


        public static void Modify(int id,int newDoctorID,DateTime newAppointment)
        {
            string modifyQuery = "UPDATE [MedicalAction] SET DoctorID = @DoctorID, DateTime = @DateTime WHERE ID = @ID";
            try
            {
                SqlCommand modify = new SqlCommand(modifyQuery, DatabaseConnection.GetInstance().database);
                modify.Parameters.AddWithValue("@ID", id);
                modify.Parameters.AddWithValue("@DoctorID", newDoctorID);
                modify.Parameters.AddWithValue("@DateTime", newAppointment);
                DatabaseConnection.GetInstance().database.Open();
                modify.ExecuteNonQuery();
                DatabaseConnection.GetInstance().database.Close();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }

    }
}
