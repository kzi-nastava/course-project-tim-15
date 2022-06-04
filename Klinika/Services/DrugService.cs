﻿using Klinika.Models;
using Klinika.Repositories;

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
    }
}
