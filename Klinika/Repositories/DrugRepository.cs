using Klinika.Models;
using Klinika.Data;

namespace Klinika.Repositories
{
    public class DrugRepository
    {
        public List<Drug> Drugs { get; }

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
            Drugs = new List<Drug>();
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
                Drugs.Add(drug);
            }
        }
        private void GetIngredients()
        {
            foreach (Drug drug in Drugs)
            {
                string getDrugsIngredientsQuery = $"SELECT IngredientID FROM [DrugIngredient] WHERE DrugID = {drug.id}";
                var result = DatabaseConnection.GetInstance().ExecuteSelectCommand(getDrugsIngredientsQuery);
                foreach (object row in result)
                {
                    var IngredientID = Convert.ToInt32(((object[])row)[0].ToString());
                    var ingredient =  IngredientRepository.Instance.Ingredients.Where(x => x.id == IngredientID).FirstOrDefault();
                    if (ingredient != null) drug.ingredients.Add(ingredient);
                }
            }
        }

        public List<Drug> GetApproved()
        {
            return Drugs.Where(x => x.approved == "A").ToList();
        }
        public List<Drug> GetUnapproved()
        {
            return Drugs.Where(x => x.approved == "C").ToList();
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

            Drugs.Where(x => x.id == id).First().approved = type.ToString();
        }
    }
}
