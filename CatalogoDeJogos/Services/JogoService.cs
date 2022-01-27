using CatalogoDeJogos.Entities;
using CatalogoDeJogos.InputModel;
using CatalogoDeJogos.Repositories;
using CatalogoDeJogos.ViewModel;
using System.Linq;

namespace CatalogoDeJogos.Services
{
    public class JogoService : IJogoService
    {
        private readonly IRepository JogoRepository;

        public JogoService(IRepository jogoRepository)
        {
            JogoRepository = jogoRepository;
        }

        public async Task<List<JogoViewModel>> ObterTodos(int pagina, int quantidadePorPagina)
        {
            var jogos = await JogoRepository.ObterTodos(pagina, quantidadePorPagina);
            return jogos.Select(jogo => new JogoViewModel
            {
                Id = jogo.Id,
                Name = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco,
            })
                .ToList();
        }

        public async Task<JogoViewModel> ObterPorId(Guid id)
        {
            var jogo = await JogoRepository.ObterPorId(id);

            if (jogo is null) return null;

            return new JogoViewModel
            {
                Id = jogo.Id,
                Name = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco,
            };
        }

        public async Task<JogoViewModel> Inserir(JogoInputModel jogo)
        {
            var jogoEntidade = await JogoRepository.Obter(jogo.Name,jogo.Produtora);

            if (jogoEntidade is not null) throw new Exception();

            var jogoNovo = new Jogo
            {
                Id = Guid.NewGuid(),
                Nome = jogo.Name,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco, 
            };

            await JogoRepository.Inserir(jogoNovo);

            return new JogoViewModel
            {
                Id = jogoNovo.Id,
                Name = jogoNovo.Nome,
                Produtora = jogoNovo.Produtora,
                Preco = jogoNovo.Preco,

            };
        }

        public async Task Atualizar(Guid id, JogoInputModel jogoAtual)
        {
            var jogoEntidade = await JogoRepository.ObterPorId(id);

            if (jogoEntidade is null) throw new Exception("Esse Jogo Não Existe");

            jogoEntidade.Nome = jogoAtual.Name;
            jogoEntidade.Produtora = jogoAtual.Produtora;
            jogoEntidade.Preco = jogoAtual.Preco;

            await JogoRepository.Atualizar(jogoEntidade);
        }

        public async Task Atualizar(Guid id, double preco) 
        {
            var jogoEntidade = await JogoRepository.ObterPorId(id);

            if (jogoEntidade is null) throw new Exception();
                        
            jogoEntidade.Preco = preco;

            await JogoRepository.Atualizar(jogoEntidade);
        }

        public async Task Excluir(Guid id)
        {
            var jogoEntidade = await JogoRepository.ObterPorId(id);

            if (jogoEntidade is null) throw new Exception();

            await JogoRepository.Excluir(jogoEntidade);
        }

        public void Dispose()
        {
            JogoRepository?.Dispose();
        }

        

        

    }
}
