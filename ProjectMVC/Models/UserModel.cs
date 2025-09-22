using System.ComponentModel.DataAnnotations;
using ProjectMVC.Enums;

namespace ProjectMVC.Models
{
    public class UserModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuário!")]
        public required string name { get; set; }
        [Required(ErrorMessage = "Digite o login do usuário!")]
        public required string login { get; set; }

        [Required(ErrorMessage = "Digite o email do usuário!")]
        [EmailAddress(ErrorMessage = "O formato do e-mail não é valido!")]
        public required string email { get; set; }
        public PerfilEnum perfil { get; set; }

        [Required(ErrorMessage = "Digite a senha do usuário!")]
        public required string senha { get; set; }
        public DateTime dataCadastro { get; set; }
        public DateTime? dataAtualizacao { get; set; }

        public bool SenhaValida (string Senha)
        {
            return Senha == this.senha;
        }

    }
}
