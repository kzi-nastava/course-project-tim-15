using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Models;
using System.Data.SqlClient;
using Klinika.Data;

namespace Klinika.Repositories
{
    public class DrugRepository
    {
        #region Singleton
        private static DrugRepository? instance;
        public static DrugRepository Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new DrugRepository();
                }
                return instance;
            }
        }
        #endregion

        #region Constructor
        public List<Ingredient> Ingredients { get; }
        public List<Drug> Drugs { get; }
        public DrugRepository()
        {
            Ingredients = new List<Ingredient>();
            GetIngredients();
            Drugs = new List<Drug>();
            GetDrugs();
        }
        #endregion

        #region Drugs
        private void GetIngredients()
        {
            string getIngredientsQuery = "SELECT * FROM [Ingredient]";
            try
            {
                SqlCommand getIngredients = new SqlCommand(getIngredientsQuery, DatabaseConnection.GetInstance().database);
                DatabaseConnection.GetInstance().database.Open();

                using (SqlDataReader retrieved = getIngredients.ExecuteReader())
                {
                    while (retrieved.Read())
                    {
                        var ingredient = new Ingredient
                        {
                            ID = Convert.ToInt32(retrieved["ID"]),
                            Name = retrieved["Name"].ToString(),
                            Type = retrieved["Type"].ToString()
                        };
                        Ingredients.Add(ingredient);
                    }
                }
                DatabaseConnection.GetInstance().database.Close();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }
        private void GetDrugs()
        {
            GetDrugsBasicInfo();
            GetDrugsIngredients();
        }
        private void GetDrugsBasicInfo()
        {
            string getDrugsQuery = "SELECT * FROM [Drug]";
            try
            {
                SqlCommand getDrugs = new SqlCommand(getDrugsQuery, DatabaseConnection.GetInstance().database);
                try { DatabaseConnection.GetInstance().database.Open(); } catch { }

                using (SqlDataReader retrieved = getDrugs.ExecuteReader())
                {
                    while (retrieved.Read())
                    {
                        var drug = new Drug
                        {
                            ID = Convert.ToInt32(retrieved["ID"]),
                            Name = retrieved["Name"].ToString(),
                            Approved = retrieved["Approved"].ToString()
                        };
                        Drugs.Add(drug);
                    }
                }
                DatabaseConnection.GetInstance().database.Close();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }
        private void GetDrugsIngredients()
        {
            foreach (Drug drug in Drugs)
            {
                string getDrugsIngredientsQuery = $"SELECT IngredientID FROM [DrugIngredient] WHERE DrugID = {drug.ID}";
                try
                {
                    SqlCommand getDrugsIngredients = new SqlCommand(getDrugsIngredientsQuery, DatabaseConnection.GetInstance().database);
                    try { DatabaseConnection.GetInstance().database.Open(); } catch { }

                    using (SqlDataReader retrieved = getDrugsIngredients.ExecuteReader())
                    {
                        while (retrieved.Read())
                        {
                            var IngredientID = Convert.ToInt32(retrieved["IngredientID"]);
                            var ingredient = Ingredients.Where(x => x.ID == IngredientID).FirstOrDefault();
                            if (ingredient != null)
                            {
                                drug.Ingredients.Add(ingredient);
                            }
                        }
                    }
                    DatabaseConnection.GetInstance().database.Close();
                }
                catch (SqlException error)
                {
                    MessageBox.Show(error.Message);
                }
            }
        }
        #endregion

        #region Prescriptions
        public static void CreatePrescription(Prescription prescription)
        {
            string createQuery = "INSERT INTO [Prescription] " +
                "(PatientID,DrugID,DateStarted,DateEnded,Interval,Comment) " +
                "VALUES (@PatientID,@DrugID,@DateStarted,@DateEnded,@Interval,@Comment)";

            SqlCommand create = new SqlCommand(createQuery, DatabaseConnection.GetInstance().database);
            create.Parameters.AddWithValue("@PatientID", prescription.PatientID);
            create.Parameters.AddWithValue("@DrugID", prescription.DrugID);
            create.Parameters.AddWithValue("@DateStarted", prescription.DateStarted);
            create.Parameters.AddWithValue("@DateEnded", prescription.DateEnded);
            create.Parameters.AddWithValue("@Interval", prescription.Interval);
            create.Parameters.AddWithValue("@Comment", prescription.Comment);

            try
            {
                DatabaseConnection.GetInstance().database.Open();
                create.ExecuteNonQuery();
                DatabaseConnection.GetInstance().database.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
