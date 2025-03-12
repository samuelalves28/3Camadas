using Business.Interfaces.Repositories;
using Business.Interfaces.Services;
using Business.Models;

namespace Business.Services;

public class ProdutoService(IProdutoRepository produtoRepository) : BaseService, IProdutoService
{
    public async Task Adicionar(Produto produto)
    {
       await produtoRepository.Adicionar(produto);
    }

    public async Task Atualizar(Produto produto)
    {
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
