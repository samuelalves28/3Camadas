namespace Business.Models;

public class Produto: BaseModel
{
    public string? Nome { get; private set; }
    public string? Descricao { get; private set; }
    public decimal Valor { get; private set; }
    public DateTime DataCadastro { get; private set; }
}
