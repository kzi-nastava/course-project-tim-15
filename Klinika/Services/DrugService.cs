using Klinika.Models;
using Klinika.Repositories;
using System.Data;

namespace Klinika.Services
{
    public class DrugService
    {
        public static List<Drug> GetAll()
        {
            return DrugRepository.Instance.drugs;
        }
        public static List<Drug> GetApproved()
        {
            return DrugRepository.Instance.GetApproved();
        }
        public static List<Drug> GetDenied()
        {
            return DrugRepository.Instance.GetDenied();
        }
        public static List<Drug> GetUnapproved()
        {
            return DrugRepository.Instance.GetUnapproved();
        }
        public static void ApproveDrug(int id)
        {
            DrugRepository.Instance.ModifyType(id, 'A');
        }
        public static void DenyDrug(int id, string description)
        {
            DrugRepository.Instance.ModifyType(id, 'D');
            DrugRepository.CreateUnapproved(id, description);
        }
        public static List<Ingredient> GetIngredients(int id)
        {
            List<Ingredient> ingredients = Repositories.DrugRepository.Instance.GetIngredientsOfOne(id);
            return ingredients;
        }
        public static string GetNote(int id)
        {
            return Repositories.DrugRepository.GetNote(id);
        }
        public static void AddDrug(Models.Drug drug, DataTable table)
        {
            if (drug.id == -1)
            {
                Repositories.DrugRepository.CreateUnapprovedDrug(drug);
            }
            else
            {
                Repositories.DrugRepository.RemoveIngredients(drug.id);
                Repositories.DrugRepository.Fix(drug.id);
                List<int> ingredientIds = new List<int>();
                foreach (DataRow dataRow in table.Rows)
                {
                    ingredientIds.Add(int.Parse(dataRow["id"].ToString()));
                }
                Repositories.DrugRepository.AddIngredients(drug.id, ingredientIds);
            }
        }
    }
}
