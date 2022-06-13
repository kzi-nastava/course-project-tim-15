using Klinika.Interfaces;
using Klinika.Models;
using System.Data;

namespace Klinika.Services
{
    public class AnamnesisService
    {
        private readonly IAnamnesisRepo anamnesisRepo;
        public AnamnesisService(IAnamnesisRepo anamnesisRepo) => this.anamnesisRepo = anamnesisRepo;
        public List<Anamnesis> Get(int patientID) => anamnesisRepo.GetAll(patientID);
        public void Create(Anamnesis anamnesis) => anamnesisRepo.Create(anamnesis);
        public List<Anamnesis> GetFiltered(int patientID, string searchParam)
        {
            return anamnesisRepo.GetAll(patientID).Where(
                x => x.description.ToUpper().Contains(searchParam.ToUpper())
                || x.symptoms.ToUpper().Contains(searchParam.ToUpper())
                || x.conclusion.ToUpper().Contains(searchParam.ToUpper())).ToList();
        }
    }
}