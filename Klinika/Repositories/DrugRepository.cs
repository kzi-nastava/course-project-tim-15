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
                    ID = Convert.ToInt32(((object[])row)[0].ToString()),
                    Name = ((object[])row)[1].ToString(),
                    Approved = ((object[])row)[2].ToString()
                };
                Drugs.Add(drug);
            }
        }
        private void GetIngredients()
        {
            foreach (Drug drug in Drugs)
            {
                string getDrugsIngredientsQuery = $"SELECT IngredientID FROM [DrugIngredient] WHERE DrugID = {drug.ID}";
                var result = DatabaseConnection.GetInstance().ExecuteSelectCommand(getDrugsIngredientsQuery);
                foreach (object row in result)
                {
                    var IngredientID = Convert.ToInt32(((object[])row)[0].ToString());
                    var ingredient =  IngredientRepository.Instance.Ingredients.Where(x => x.ID == IngredientID).FirstOrDefault();
                    if (ingredient != null) drug.Ingredients.Add(ingredient);
                }
            }
        }

        public List<Drug> GetApproved()
        {
            return Drugs.Where(x => x.Approved == "A").ToList();
        }
        public List<Drug> GetUnapproved()
        {
            return Drugs.Where(x => x.Approved == "C").ToList();
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

            Drugs.Where(x => x.ID == id).First().Approved = type.ToString();
        }
    }
}
