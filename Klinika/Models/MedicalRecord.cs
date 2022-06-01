namespace Klinika.Models
{
    public class MedicalRecord
    {
        public int id { get; set; }
        public decimal height { get; set; }
        public decimal weight { get; set; }
        public string? bloodType { get; set; }
        public List<Anamnesis> anamneses { get; set; }
        public List<Disease> diseases { get; set; }
        public List<Ingredient> allergens { get; set; }

        public MedicalRecord()
        {
            anamneses = new List<Anamnesis>();
            diseases = new List<Disease>();
            allergens = new List<Ingredient>();
        }

        public bool IsAllergic(Drug drug)
        {
            foreach (Ingredient ingredient in drug.ingredients)
            {
                if (allergens.Contains(ingredient)) return true;
            }
            return false;
        }
    }
}
