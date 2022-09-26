namespace Healthcare.Models;

internal class MedicalCard
{
    public MedicalCard(Patient patient, string text)
    {
        Id = Guid.NewGuid();
        GetPatient = patient;
        Text = text;
    }

    public Guid Id { get; }
    public Patient GetPatient { get; }
    public string Text { get; private set; }

    public void AddRecordInMedicalCard(string text)
    {
        Text += "\n" + text;
    }
}