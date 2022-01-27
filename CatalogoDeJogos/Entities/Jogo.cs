namespace CatalogoDeJogos.Entities
{
    public class Jogo : IEntidade
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Produtora { get; set; } = string.Empty;
        public double Preco { get; set; }

        /*public void Atualizar(double preco)
        {
            Preco = preco;
        }*/


        /*public void Atualizar<C>(C? campo)
        {
            throw new NotImplementedException();
        }*/
    }
}
