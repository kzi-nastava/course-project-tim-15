using Klinika.Data;
using Klinika.Interfaces;
using Klinika.Models;

namespace Klinika.Repositories
{
    public class DrugRepository : Repository, IDrugRepo
    {
        public List<Drug> drugs { get; }

        // TODO remove singleton
        private static DrugRepository? instance;
        public static DrugRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DrugRepository();
                }
                return instance;
            }
        }
        public DrugRepository() : base()
        {
            drugs = new List<Drug>();
            GetBasicInfo();
            GetIngredients();
        }
        public List<Drug> GetAll()
        {
            return drugs;
        }
        private void GetBasicInfo()
        {
            string getDrugsQuery = "SELECT * FROM [Drug]";
            var result = database.ExecuteSelectCommand(getDrugsQuery);
            foreach (object row in result)
            {
                var drug = new Drug
                {
                    id = Convert.ToInt32(((object[])row)[0].ToString()),
                    name = ((object[])row)[1].ToString(),
                    approved = ((object[])row)[2].ToString()
                };
                drugs.Add(drug);
            }
        }
        private void GetIngredients()
        {
            foreach (Drug drug in drugs)
            {
                string getDrugsIngredientsQuery = $"SELECT IngredientID FROM [DrugIngredient] WHERE DrugID = {drug.id}";
                var result = database.ExecuteSelectCommand(getDrugsIngredientsQuery);
                foreach (object row in result)
                {
                    var IngredientID = Convert.ToInt32(((object[])row)[0].ToString());
                    var ingredient =  IngredientRepository.Instance.ingredients.Where(x => x.id == IngredientID).FirstOrDefault();
                    if (ingredient != null) drug.ingredients.Add(ingredient);
                }
            }
        }

        internal static void Fix(int id)
        {
            string modifyQuery = "UPDATE [Drug] SET Approved = 'C' WHERE ID = @ID";

            DatabaseConnection.GetInstance().ExecuteNonQueryCommand(
                modifyQuery,
                ("@ID", id));

            modifyQuery = "UPDATE [UnapprovedDrug] SET IsFixed = 1 WHERE DrugID = @ID";

            DatabaseConnection.GetInstance().ExecuteNonQueryCommand(
                modifyQuery,
                ("@ID", id));
        }

        internal void CreateUnapprovedDrug(Drug drug)
        {
            string createQuery = "INSERT INTO [Drug] " +
                "(Name, Approved) " +
                "VALUES (@Name, 'C')";

            database.ExecuteNonQueryCommand(
                createQuery,
                ("@Name", drug.name));
        }

        internal static void AddIngredients(int id, List<int> ingredientIds)
        {
            string insertQuery = "INSERT INTO [DrugIngredient] (DrugID, IngredientID) VALUES (@Drug, @Ing)";
            foreach (int ingredientId in ingredientIds)
            {
                DatabaseConnection.GetInstance().ExecuteNonQueryCommand(insertQuery, ("@Drug", id), ("@Ing", ingredientId));
            }
        }

        internal static void RemoveIngredients(int id)
        {
            string deleteQuery = "DELETE FROM [DrugIngredient] WHERE DrugID = @DrugID";
            DatabaseConnection.GetInstance().ExecuteNonQueryCommand(deleteQuery, ("@DrugID", id));
        }

        public List<Ingredient> GetIngredientsOfOne(int id)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            string getDrugsIngredientsQuery = $"SELECT IngredientID FROM [DrugIngredient] WHERE DrugID = {id}";
            var result = database.ExecuteSelectCommand(getDrugsIngredientsQuery);
            foreach (object row in result)
            {
                var IngredientID = Convert.ToInt32(((object[])row)[0].ToString());
                var ingredient = IngredientRepository.Instance.ingredients.Where(x => x.id == IngredientID).FirstOrDefault();
                if (ingredient != null) ingredients.Add(ingredient);
            }
            return ingredients;
        }

        public List<Drug> GetApproved()
        {
            return drugs.Where(x => x.approved == "A").ToList();
        }
        public List<Drug> GetUnapproved()
        {
            return drugs.Where(x => x.approved == "C").ToList();
        }
        public List<Drug> GetDenied()
        {
            return drugs.Where(x => x.approved == "D").ToList();
        }

        public void CreateUnapproved(int id, string description)
        {
            string createQuery = "INSERT INTO [UnapprovedDrug] " +
                "(DrugID,Description) " +
                "VALUES (@DrugID,@Description)";

            database.ExecuteNonQueryCommand(
                createQuery,
                ("@DrugID", id),
                ("@Description", description));
        }
        public void ModifyType(int id, char type)
        {
            string modifyQuery = "UPDATE [Drug] SET Approved = @Type WHERE ID = @ID";

            database.ExecuteNonQueryCommand(
                modifyQuery,
                ("@Type", type),
                ("@ID", id));

            drugs.Where(x => x.id == id).First().approved = type.ToString();
        }

        public static string GetNote(int id)
        {
            string getUnapprovedDrugQuery = $"SELECT * FROM [UnapprovedDrug] WHERE DrugID = {id} AND IsFixed = 0";
            return ((object[])DatabaseConnection.GetInstance().ExecuteSelectCommand(getUnapprovedDrugQuery)[0])[1].ToString();
        }
    }
}
