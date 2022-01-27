namespace CatalogoDeJogos.Exceptions
{
    public class JogoJaCadastradoException : Exception
    {
        public JogoJaCadastradoException() : base("Esse Jogo Ja está Cadatrado")
        {
            ;
        }
    }
}
