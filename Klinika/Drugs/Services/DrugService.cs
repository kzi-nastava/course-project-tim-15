using Klinika.Drugs.Interfaces;
using Klinika.Drugs.Models;
using System.Data;

namespace Klinika.Drugs.Services
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
    }
}
