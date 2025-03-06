namespace Business.Models;

public abstract class BaseModel
{
    protected BaseModel()
    {
        Id = Guid.NewGuid();
        Ativo = true;
    }

    public Guid Id { get; private set; }
    public bool Ativo { get; private set; }

}
