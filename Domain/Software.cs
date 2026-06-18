namespace SoftwareManagement.Domain;

public class Software
{
    public int IdSoftware { get; private set; }
    public string Nome { get; private set; }
    public string Fornecedor { get; private set; }
    public DateTime DataCriacao { get; private set; }

    public Software(string nome, string fornecedor)
    {
        Nome = nome;
        Fornecedor = fornecedor;
        DataCriacao = DateTime.UtcNow;
    }

    public void AtualizarDados(string nome, string fornecedor)
    {
        Nome = nome;
        Fornecedor = fornecedor;
    }
}