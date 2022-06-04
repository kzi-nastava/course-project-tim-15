using Klinika.Data;
using Klinika.Models;

namespace Klinika.Repositories
{
    public class DrugRepository
    {
        public List<Drug> drugs { get; }

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
        public DrugRepository()
        {
            drugs = new List<Drug>();
            GetAll();
        }

        private void GetAll()
        {
            GetBasicInfo();
            GetIngredients();
        }
        private void GetBasicInfo()
        {
            string getDrugsQuery = "SELECT * FROM [Drug]";
            var result = DatabaseConnection.GetInstance().ExecuteSelectCommand(getDrugsQuery);
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
                var result = DatabaseConnection.GetInstance().ExecuteSelectCommand(getDrugsIngredientsQuery);
                foreach (object row in result)
                {
                    var IngredientID = Convert.ToInt32(((object[])row)[0].ToString());
                    var ingredient =  IngredientRepository.Instance.ingredients.Where(x => x.id == IngredientID).FirstOrDefault();
                    if (ingredient != null) drug.ingredients.Add(ingredient);
                }
            }
        }
        public List<Ingredient> GetIngredientsOfOne(int id)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            string getDrugsIngredientsQuery = $"SELECT IngredientID FROM [DrugIngredient] WHERE DrugID = {id}";
            var result = DatabaseConnection.GetInstance().ExecuteSelectCommand(getDrugsIngredientsQuery);
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
        public void ModifyType(int id, char type)
        {
            string modifyQuery = "UPDATE [Drug] SET Approved = @Type WHERE ID = @ID";

            DatabaseConnection.GetInstance().ExecuteNonQueryCommand(
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
