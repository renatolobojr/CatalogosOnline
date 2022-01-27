using CatalogoDeJogos.Entities;

namespace CatalogoDeJogos.Repositories
{
    public class JogoRepository : IRepository
    {
        private bool disposedValue;

        public Task Atualizar(Jogo jogo)
        {
            throw new NotImplementedException();
        }

        public Task Excluir(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Excluir(Jogo jogo)
        {
            throw new NotImplementedException();
        }

        public Task Inserir(Jogo jogo)
        {
            throw new NotImplementedException();
        }

        public Task<Jogo> Obter(string st, string st2)
        {
            throw new NotImplementedException();
        }

        public Task<Jogo> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Jogo>> ObterTodos(int pagina, int quantidadePorPagina)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~JogoRepository()
        // {
        //     // Não altere este código. Coloque o código de limpeza no método 'Dispose(bool disposing)'
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Não altere este código. Coloque o código de limpeza no método 'Dispose(bool disposing)'
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
