namespace Business.Models;

public class Endereco : BaseModel
{
    public string? Lougradouro { get; private set; }
    public string? Numero { get; private set; }
    public string? Complemento { get; private set; }
    public string? Cep { get; private set; }
    public string? Bairro { get; private set; }
    public string? Cidade { get; private set; }
    public string? Estado { get; private set; }
}
