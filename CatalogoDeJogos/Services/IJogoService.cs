using CatalogoDeJogos.InputModel;
using CatalogoDeJogos.ViewModel;

namespace CatalogoDeJogos.Services
{
    public interface IJogoService : IDisposable
    {
        Task<List<JogoViewModel>> ObterTodos(int pagina,int quantidadePorPagina);
        Task<JogoViewModel> ObterPorId(Guid id);
        Task<JogoViewModel> Inserir(JogoInputModel jogo);
        Task Atualizar(Guid id, JogoInputModel jogo);
        Task Atualizar(Guid id, double preco);
        Task Excluir(Guid id);
    }
}
