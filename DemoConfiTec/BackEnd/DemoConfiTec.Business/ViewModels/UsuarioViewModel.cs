using System;
using System.ComponentModel.DataAnnotations;

namespace DemoConfiTec.Business.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string SobreNome { get; set; }

        [Required(ErrorMessage = "O email deve ser informado", AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage ="Formato do email inválido")]
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }

        [EnumDataType(typeof(TipoEscolaridade))]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public TipoEscolaridade Escolaridade { get; set; }
    }

    public enum TipoEscolaridade
    {
        Infantil = 1,
        Fudamental = 2,
        Medio = 3,
        Superior = 4
    }
}