namespace Business.Models;

public partial class Fornecedor : BaseModel
{

    public string? Nome { get; private set; }
    public string? Documento { get; private set; }
    public ETipoFornecedor TipoFornecedor { get; private set; }
    public Endereco? Endereco { get; private set; }

    public List<Produto> Produtos { get; private set; } = [];
}
