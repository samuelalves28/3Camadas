using Business.Interfaces.Notificador;
using Business.Interfaces.Repositories;
using Business.Interfaces.Services;
using Business.Models;
using Business.Models.Validations;

namespace Business.Services;

public class ProdutoService(IProdutoRepository produtoRepository, INotificador notificador) : BaseService(notificador), IProdutoService
{
    public async Task Adicionar(Produto produto)
    {
        if (!ExecuteValidacao(new ProdutoValidation(), produto)) return;

        await produtoRepository.Adicionar(produto);
    }

    public async Task Atualizar(Produto produto)
    {
        if (!ExecuteValidacao(new ProdutoValidation(), produto)) return;

        await produtoRepository.Atualizar(produto);
    }

    public async Task Remover(Guid id)
    {
        await produtoRepository.Remover(id);
    }

    public void Dispose()
    {
        produtoRepository.Dispose();
    }
}
