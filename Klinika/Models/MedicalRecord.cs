﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Models
{
    public class MedicalRecord
    {
        public int ID { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public string? BloodType { get; set; }
        public List<Anamnesis> Anamneses { get; set; }
        public List<Disease> Diseases { get; set; }
        public List<Ingredient> Allergens { get; set; }

        public MedicalRecord()
        {
            Anamneses = new List<Anamnesis>();
            Diseases = new List<Disease>();
            Allergens = new List<Ingredient>();
        }

        public bool IsAllergic(Drug drug)
        {
            foreach (Ingredient ingredient in drug.ingredients)
            {
                if (Allergens.Contains(ingredient)) return true;
            }
            return false;
        }
    }
}
