using Klinika.Models;
using Klinika.Repositories;
using System.Data;

namespace Klinika.Services
{
    public class AnamnesisService
    {
        public AnamnesisService() { }
        public static List<Anamnesis> Get(int patientID)
        {
            return AnamnesisRepository.Get(patientID);
        }
        public static void Create(Anamnesis anamnesis)
        {
            AnamnesisRepository.Create(anamnesis);
        }
        public static List<Anamnesis> GetFiltered(int patientID, string searchParam)
        {
            return AnamnesisRepository.Get(patientID).Where(
                x => x.Description.ToUpper().Contains(searchParam.ToUpper())
                || x.Symptoms.ToUpper().Contains(searchParam.ToUpper())
                || x.Conclusion.ToUpper().Contains(searchParam.ToUpper())).ToList();
        }
    }
}
