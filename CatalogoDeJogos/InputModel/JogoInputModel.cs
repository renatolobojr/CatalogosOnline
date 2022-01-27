using System.ComponentModel.DataAnnotations;

namespace CatalogoDeJogos.InputModel
{
    public class JogoInputModel
    {
        //exemplos de fail fast valitador
        [Required]
        [StringLength(100, MinimumLength =3, ErrorMessage = "O nome do Jogo deve ter de 3 até 100 caracteres")]
        public string Name { get; set; }

        [Required]

        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome da Produtora deve ter de 3 até 100 caracteres")]
        public string Produtora { get; set; }

        [Required]
        [Range(1,1000, ErrorMessage = "Preço minimo de R$1 e Máximo de R$1000")]
        public double Preco { get; set; }
    }
}
