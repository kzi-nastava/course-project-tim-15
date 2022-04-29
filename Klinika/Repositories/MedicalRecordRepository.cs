﻿using Klinika.Data;
using Klinika.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Repositories
{
    internal class MedicalRecordRepository
    {
        public static T CheckNull<T>(object obj)
        {
            return obj == DBNull.Value ? default(T) : (T)obj;
        }
        public static MedicalRecord Get(int patientID)
        {
            MedicalRecord record = new MedicalRecord();
            string getRecordQuerry = "SELECT * " +
                "FROM [Patient] " +
                $"WHERE UserID = {patientID}";
            try
            {
                SqlCommand getRecord = new SqlCommand(getRecordQuerry, DatabaseConnection.GetInstance().database);
                DatabaseConnection.GetInstance().database.Open();
                using (SqlDataReader retrieved = getRecord.ExecuteReader())
                {
                    while (retrieved.Read())
                    {
                        record.ID = patientID;
                        record.Height = CheckNull<decimal>(retrieved["Height"]);
                        record.Weight = CheckNull<decimal>(retrieved["Weight"]);
                        record.BloodType = CheckNull<string>(retrieved["BloodType"]);
                    }
                }
                DatabaseConnection.GetInstance().database.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            record.Anamneses = GetAnamneses(patientID);
            record.Diseases = GetDiseases(patientID);
            record.Allergens = GetAllergens(patientID);
            return record;
        }
         
        private static List<Anamnesis> GetAnamneses(int patientID)
        {
            List<Anamnesis> anamneses = new List<Anamnesis>();

            string getAnamnesesQuerry = 
                "SELECT [Anamnesis].ID, [Anamnesis].MedicalActionID, [Anamnesis].Description, [Anamnesis].Symptoms, [Anamnesis].Conclusion " +
                "FROM [Anamnesis] JOIN [MedicalAction] ON [Anamnesis].MedicalActionID = [MedicalAction].ID " +
                $"WHERE [MedicalAction].PatientID = {patientID}";
            try
            {
                SqlCommand getAnamneses = new SqlCommand(getAnamnesesQuerry, DatabaseConnection.GetInstance().database);
                DatabaseConnection.GetInstance().database.Open();
                using (SqlDataReader retrieved = getAnamneses.ExecuteReader())
                {
                    while (retrieved.Read())
                    {
                        var anamnesis = new Anamnesis
                        {
                            ID = Convert.ToInt32(retrieved["ID"]),
                            MedicalActionID = Convert.ToInt32(retrieved["MedicalActionID"]),
                            Description = CheckNull<string>(retrieved["Description"]),
                            Symptoms = CheckNull<string>(retrieved["Symptoms"]),
                            Conclusion = CheckNull<string>(retrieved["Conclusion"])
                        };
                        anamneses.Add(anamnesis);
                    }
                }
                DatabaseConnection.GetInstance().database.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return anamneses;
        }
        private static List<Disease> GetDiseases(int patientID)
        {
            List<Disease> diseases = new List<Disease>();

            string getDiseasesQuerry =
                "SELECT [Disease].ID, [Disease].Name, [Disease].Description, [PatientDisease].PatientID, [PatientDisease].DateDiagnosed " +
                "FROM [Disease] JOIN [PatientDisease] ON [Disease].ID = [PatientDisease].Diseaseid " +
                $"WHERE [PatientDisease].PatientID = {patientID}";
            try
            {
                SqlCommand getDiseases = new SqlCommand(getDiseasesQuerry, DatabaseConnection.GetInstance().database);
                DatabaseConnection.GetInstance().database.Open();
                using (SqlDataReader retrieved = getDiseases.ExecuteReader())
                {
                    while (retrieved.Read())
                    {
                        var disease = new Disease
                        {
                            ID = Convert.ToInt32(retrieved["ID"]),
                            PatientID = Convert.ToInt32(retrieved["PatientID"]),
                            Description = CheckNull<string>(retrieved["Description"]),
                            Name = CheckNull<string>(retrieved["Name"]),
                            DateDiagnosed = CheckNull<DateTime>(retrieved["DateDiagnosed"])
                        };
                        diseases.Add(disease);
                    }
                }
                DatabaseConnection.GetInstance().database.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return diseases;
        }
        private static List<Allergen> GetAllergens(int patientID)
        {
            List<Allergen> allergens = new List<Allergen>();

            string getAllergensQuerry =
                "SELECT [Ingredient].ID, [Ingredient].Name, [Ingredient].Type, [PatientAllergen].PatientID " +
                "FROM [Ingredient] JOIN [PatientAllergen] ON [Ingredient].ID = [PatientAllergen].IngredientID " +
                $"WHERE [PatientAllergen].PatientID = {patientID}";
            try
            {
                SqlCommand getAllergens = new SqlCommand(getAllergensQuerry, DatabaseConnection.GetInstance().database);
                DatabaseConnection.GetInstance().database.Open();
                using (SqlDataReader retrieved = getAllergens.ExecuteReader())
                {
                    while (retrieved.Read())
                    {
                        var allergen = new Allergen
                        {
                            ID = Convert.ToInt32(retrieved["ID"]),
                            PatientID = Convert.ToInt32(retrieved["PatientID"]),
                            Name = CheckNull<string>(retrieved["Name"]),
                            Type = CheckNull<string>(retrieved["Type"])
                        };
                        allergens.Add(allergen);
                    }
                }
                DatabaseConnection.GetInstance().database.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return allergens;
        }
    }
}
