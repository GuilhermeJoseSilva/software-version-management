namespace SoftwareManagement.Domain;

public class Versao
{
    public int IdVersao { get; private set; }
    public int SoftwareId { get; private set; }
    public string Descricao { get; private set;}
    public DateTime DataRelease { get; private set; }
    public bool Depreciado { get; private set; }

    public Versao(int softwareId, string descricao, DateTime dataRelease, bool depreciado)
    {
        SoftwareId = softwareId;
        Descricao = descricao;
        DataRelease = DateTime.SpecifyKind(dataRelease, DateTimeKind.Utc);
        Depreciado = depreciado;
    }

    public void AtualizarDados(string descricao, DateTime dataRelease, bool depreciado)
    {
        Descricao = descricao;
        DataRelease = DateTime.SpecifyKind(dataRelease, DateTimeKind.Utc);
        Depreciado = depreciado;
    }
}