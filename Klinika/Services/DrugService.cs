using Klinika.Models;
using Klinika.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Services
{
    public class DrugService
    {
        public static List<Drug> GetApproved()
        {
            return DrugRepository.Instance.GetApproved();
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
    }
}
