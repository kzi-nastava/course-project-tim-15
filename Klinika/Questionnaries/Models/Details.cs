namespace Klinika.Questionnaries.Models
{
    public class Details
    {
        public int g1 { get; set; }
        public int g2 { get; set; }
        public int g3 { get; set; }
        public int g4 { get; set; }
        public int g5 { get; set; }
        public int g { get; set; }
        public int qID { get; set; }
        public string text { get; set; }

        public double CalculateAvg()
        {
            return (double)((1 * g1 + 2 *g2 + 3 * g3 + 4 * g4 + 5 * g5)/(g1 + g2 + g3 + g4 + g5));
        }
    }
}
