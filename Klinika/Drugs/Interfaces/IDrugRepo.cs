using Klinika.Drugs.Models;

namespace Klinika.Drugs.Interfaces
{
    public interface IDrugRepo
    {
        List<Drug> GetAll();
        List<Drug> GetApproved();
        List<Drug> GetDenied();
        List<Drug> GetUnapproved();
        void ModifyType(int id, char type);
        void CreateUnapproved(int id, string description);
    }
}
