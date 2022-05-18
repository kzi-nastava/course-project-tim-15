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
        public static void ApproveDrug(int id)
        {
            var msgBox = MessageBox.Show("Are you sure you want to approve this drug?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msgBox == DialogResult.No) return;
            DrugRepository.Instance.ModifyType(id, 'A');
        }
        public static void DenyDrug(int id, string description)
        {
            var msgBox = MessageBox.Show("Are you sure you want to deny this drug?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msgBox == DialogResult.No) return;
            DrugRepository.Instance.ModifyType(id, 'D');
            DrugRepository.CreateUnapproved(id, description);
        }
    }
}
