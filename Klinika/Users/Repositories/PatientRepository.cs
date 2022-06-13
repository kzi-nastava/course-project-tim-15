using System.Data;
using Klinika.Core;
using Klinika.MedicalRecords.Interfaces;
using Klinika.MedicalRecords.Repositories;
using Klinika.Users.Interfaces;
using Klinika.Users.Models;

namespace Klinika.Users.Repositories
{
    internal class PatientRepository : Repository, IPatientRepo
    {
        public Dictionary<string, int>? emailIDPairs { get; private set; }
        public Dictionary<int, Patient>? idPatientPairs { get; private set; }

        private readonly IMedicalRecordRepo medicalRecordRepo;

        public PatientRepository() : base()
        {
            medicalRecordRepo = new MedicalRecordRepository();
        }

        public List<Patient> GetAll()
        {
            emailIDPairs = new Dictionary<string, int>();
            idPatientPairs = new Dictionary<int, Patient>();
            List<Patient> patients = new List<Patient>();
            string getAllQuery = "SELECT [User].ID, [User].JMBG, [User].Name, [User].Surname, [User].Birthdate, [User].Gender, [User].Email, " +
                                 "[User].Password, [User].IsBlocked as Blocked, [User].WhoBlocked as BlockedBy, [Patient].NotificationOffset " +
                                      "FROM [User] JOIN [Patient] " +
                                      "ON [User].ID = [Patient].UserID " +
                                      "WHERE UserType = 1 AND IsDeleted = 0";

            DataTable retrievedPatients = database.CreateTableOfData(getAllQuery);
            foreach (DataRow patient in retrievedPatients.Rows)
            {
                int id = Convert.ToInt32(patient["ID"]);
                string email = patient["Email"].ToString();

                Patient newPatient = new Patient(id,
                                                patient["JMBG"].ToString(),
                                                patient["Name"].ToString(),
                                                patient["Surname"].ToString(),
                                                DateTime.Parse(patient["Birthdate"].ToString()),
                                                patient["Gender"].ToString()[0],
                                                email,
                                                patient["Password"].ToString(),
                                                Convert.ToInt32(patient["NotificationOffset"]));

                patients.Add(newPatient);
                emailIDPairs.Add(email, id);
                idPatientPairs.Add(id, newPatient);

            }
            retrievedPatients.Columns.Remove("Password");
            retrievedPatients.Columns.Remove("NotificationOffset");

            return patients;

        }
        public Patient GetSingle(int id)
        {
            string getSingleQuerry = "SELECT [User].ID, [User].JMBG, [User].Name, [User].Surname, [User].Birthdate, [User].Gender, " +
                "[User].Email, [User].Password, [Patient].NotificationOffset " +
                "FROM [User] JOIN [Patient] " +
                "ON [User].ID = [Patient].UserID " +
                $"WHERE [User].ID = {id}";
            var result = database.ExecuteSelectCommand(getSingleQuerry);
            Patient patient = new Patient(
                Convert.ToInt32(((object[])result[0])[0]),
                ((object[])result[0])[1].ToString(),
                ((object[])result[0])[2].ToString(),
                ((object[])result[0])[3].ToString(),
                Convert.ToDateTime(((object[])result[0])[4]),
                Convert.ToChar(((object[])result[0])[5]),
                ((object[])result[0])[6].ToString(),
                ((object[])result[0])[7].ToString(),
                Convert.ToInt32(((object[])result[0])[8]));
            return patient;
        }

        public void Modify(Patient patient)
        {
            string modifyQuery = "UPDATE [User] " +
                                 "SET JMBG = @JMBG, " +
                                 "Name = @Name, " +
                                 "Surname = @Surname, " +
                                 "Birthdate = @Birthdate, " +
                                 "Gender = @Gender, " +
                                 "Password = @Password " +
                                 "WHERE ID = @ID";

            database.ExecuteNonQueryCommand(modifyQuery,
            ("@ID", patient.id),
            ("@JMBG", patient.jmbg),
            ("@Name", patient.name),
            ("@Surname", patient.surname),
            ("@Birthdate", patient.birthdate.Date),
            ("@Gender", patient.gender),
            ("@Password", patient.password)
            );

            string modifyQuerry = "UPDATE [Patient] SET NotificationOffset = @notificationOffset WHERE UserID = @Id";
            database.ExecuteNonQueryCommand(modifyQuerry, ("@notificationOffset", patient.notificationOffset), ("@Id", patient.id));
        }

        //Logical deletion
        public void Delete(int id)
        {
            string deleteQuery = "UPDATE [User] SET IsDeleted = 1 WHERE ID = @ID";
            database.ExecuteNonQueryCommand(deleteQuery, ("@ID", id));
            if (emailIDPairs != null)
            {
                emailIDPairs.Remove(idPatientPairs[id].email);
            }
        }

        public void Create(Patient newPatient)
        {
            string createQuery = "INSERT INTO [User] " +
                "(JMBG,Name,Surname,Birthdate,Gender,Email,Password,UserType) " +
                "OUTPUT INSERTED.ID " +
                "VALUES (@JMBG,@Name,@Surname,@Birthdate,@Gender,@Email,@Password,@UserType)";

            int createdID = (int)database.ExecuteNonQueryScalarCommand(
                createQuery,
                ("@JMBG", newPatient.jmbg),
                ("@Name", newPatient.name),
                ("@Surname", newPatient.surname),
                ("@Birthdate", newPatient.birthdate.Date),
                ("@Gender", newPatient.gender),
                ("@Email", newPatient.email),
                ("@Password", newPatient.password),
                ("@UserType", 1)
                );

            medicalRecordRepo.Create(createdID);

            if (emailIDPairs != null)
            {
                emailIDPairs.Add(newPatient.email, createdID);
            }
        }

        public int? GetIdByEmail(string email)
        {
            return emailIDPairs[email];
        }

    }

}
