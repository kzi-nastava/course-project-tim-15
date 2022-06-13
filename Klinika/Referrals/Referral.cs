namespace Klinika.Referrals
{
    public class Referral
    {
        public int id { get; }
        public int patientId { get; }
        public string doctorIdAndFullName { get; }
        public string specializationIdAndName { get; }
        public bool used { get; }
        public DateTime date { get; }

        public Referral(int id, int patientId, string doctorIdAndFullName, string specializationIdAndName, bool used, DateTime date)
        {
            this.id = id;
            this.patientId = patientId;
            this.doctorIdAndFullName = doctorIdAndFullName;
            this.specializationIdAndName = specializationIdAndName;
            this.used = used;
            this.date = date;
        }

        public Referral(string doctorIdAndFullName, string specializationIdAndName)
        {
            this.doctorIdAndFullName = doctorIdAndFullName;
            this.specializationIdAndName = specializationIdAndName;
        }
    }
}
