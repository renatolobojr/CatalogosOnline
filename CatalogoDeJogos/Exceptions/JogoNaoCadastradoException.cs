namespace CatalogoDeJogos.Exceptions
{
    public class JogoNaoCadastradoException : Exception
    {
        public JogoNaoCadastradoException() : base("Esse Jogo Não está Cadatrado")
        {
            ;
        }
    }
}
