using System.ComponentModel.DataAnnotations;

namespace ProjectMVC.Models
{
    public class ContactModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Digite o nome do contato!")]
        public string name { get; set; }

        [Required(ErrorMessage = "Digite o email do contato!")]
        [EmailAddress(ErrorMessage = "O formato do e-mail não é valido!")]
        public string email { get; set; }

        [Required(ErrorMessage = "Digite o telefone do contato!")]
        [Phone(ErrorMessage = "O formato do telefone não é valido!")]
        public string phone { get; set; }

        [Required(ErrorMessage = "Digite o gênero do contato!")]
        public string gender { get; set; }

        public string uf { get; set; }
        public string city { get; set; }
    }
}
