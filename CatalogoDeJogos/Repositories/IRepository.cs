using CatalogoDeJogos.Entities;

namespace CatalogoDeJogos.Repositories
{
    public interface IRepository : IDisposable
    {
        Task<List<Jogo>> ObterTodos(int pagina, int quantidadePorPagina);
        Task<Jogo> ObterPorId(Guid id);
        Task<Jogo> Obter(string st, string st2);
        Task Inserir(Jogo jogo);
        Task Atualizar(Jogo jogo);
        Task Excluir(Guid id);
        Task Excluir(Jogo jogo);
    }
}
