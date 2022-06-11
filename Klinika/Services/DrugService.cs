using Klinika.Interfaces;
using Klinika.Models;
using System.Data;

namespace Klinika.Services
{
    public class DrugService
    {
        private readonly IDrugRepo drugRepo;
        public DrugService(IDrugRepo drugRepo) => this.drugRepo = drugRepo;
        public List<Drug> GetAll() => drugRepo.GetAll();
        public List<Drug> GetApproved() => drugRepo.GetApproved();
        public List<Drug> GetDenied() => drugRepo.GetDenied();
        public List<Drug> GetUnapproved() => drugRepo.GetUnapproved();
        public void ApproveDrug(int id) => drugRepo.ModifyType(id, 'A');
        public void DenyDrug(int id, string description)
        {
            drugRepo.ModifyType(id, 'D');
            drugRepo.CreateUnapproved(id, description);
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
                // TODO
                // Repositories.DrugRepository.CreateUnapprovedDrug(drug);
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
