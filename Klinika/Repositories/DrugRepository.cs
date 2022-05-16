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
            var resoult = DatabaseConnection.GetInstance().ExecuteSelectCommand(getIngredientsQuery);
            foreach(object row in resoult)
            {
                var ingredient = new Ingredient
                {
                    ID = Convert.ToInt32(((object[])row)[0].ToString()),
                    Name = ((object[])row)[1].ToString(),
                    Type = ((object[])row)[2].ToString()
                };
                Ingredients.Add(ingredient);
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
            var resoult = DatabaseConnection.GetInstance().ExecuteSelectCommand(getDrugsQuery);
            foreach (object row in resoult)
            {
                var drug = new Drug
                {
                    ID = Convert.ToInt32(((object[])row)[0].ToString()),
                    Name = ((object[])row)[1].ToString(),
                    Approved = ((object[])row)[2].ToString()
                };
                Drugs.Add(drug);
            }
        }
        private void GetDrugsIngredients()
        {
            foreach (Drug drug in Drugs)
            {
                string getDrugsIngredientsQuery = $"SELECT IngredientID FROM [DrugIngredient] WHERE DrugID = {drug.ID}";
                var resoult = DatabaseConnection.GetInstance().ExecuteSelectCommand(getDrugsIngredientsQuery);
                foreach (object row in resoult)
                {
                    var IngredientID = Convert.ToInt32(((object[])row)[0].ToString());
                    var ingredient = Ingredients.Where(x => x.ID == IngredientID).FirstOrDefault();
                    if (ingredient != null)
                    {
                        drug.Ingredients.Add(ingredient);
                    }
                }
            }
        }
        public void ModifyType(int id, char type)
        {
            string modifyQuery = "UPDATE [Drug] SET Approved = @Type WHERE ID = @ID";

            DatabaseConnection.GetInstance().ExecuteNonQueryCommand(
                modifyQuery,
                ("@Type", type),
                ("@ID", id));

            Drugs.Where(x => x.ID == id).First().Approved = type.ToString();
        }
        public static void CreateUnapproved(int id, string description)
        {
            string createQuery = "INSERT INTO [UnapprovedDrug] " +
                "(DrugID,Description) " +
                "VALUES (@DrugID,@Description)";

            DatabaseConnection.GetInstance().ExecuteNonQueryCommand(
                createQuery,
                ("@DrugID", id),
                ("@Description", description));
        }
        #endregion

        #region Prescriptions
        public static void CreatePrescription(Prescription prescription)
        {
            string createQuery = "INSERT INTO [Prescription] " +
                "(PatientID,DrugID,DateStarted,DateEnded,Interval,Comment) " +
                "VALUES (@PatientID,@DrugID,@DateStarted,@DateEnded,@Interval,@Comment)";

           DatabaseConnection.GetInstance().ExecuteNonQueryCommand(
               createQuery,
               ("@PatientID", prescription.PatientID),
               ("@DrugID", prescription.DrugID),
               ("@DateStarted", prescription.DateStarted),
               ("@DateEnded", prescription.DateEnded),
               ("@Interval", prescription.Interval),
               ("@Comment", prescription.Comment));
        }
        #endregion
    }
}
