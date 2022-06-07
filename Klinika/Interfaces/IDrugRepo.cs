using Klinika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Interfaces
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
