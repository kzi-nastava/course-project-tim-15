using Klinika.Roles;

namespace Klinika.Models;

public class PatientRequest
{
    public enum Types { DELETE = 'D', MODIFY = 'M' }

    public int id { get; set; }
    public int patientID { get; set; }
    public int medicalActionID  { get; set; }
    public char type { get; set; }
    public string? description { get; set; }
    public bool? approved { get; set; }

    public PatientRequest()
    {
        id = -1;
    }
    public PatientRequest(int patientID, int medicalActionID, Types type,
        string? description, bool approved)
    {
        id = -1;
        this.patientID = patientID;
        this.medicalActionID = medicalActionID;
        this.type = (char)type;
        this.description = description;
        this.approved = approved;
    }

    public PatientRequest(int id, int patientID, int medicalActionID, char type, string? description, bool? approved)
    {
        this.id = id;
        this.patientID = patientID;
        this.medicalActionID = medicalActionID;
        this.type = type;
        this.description = description;
        this.approved = approved;
    }
}
