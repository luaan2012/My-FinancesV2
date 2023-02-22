using Finances.Enums;
using Finances.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Finances.ModelView
{
    public class UserView : Entity
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        [DisplayName("Ultimo Nome")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        [EmailAddress(ErrorMessage = "O endereço de {0} é inválido")]
        [DisplayName("Email")]

        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string UserName { get; set; }

        [DisplayName("Data Aniversario")]
        public string Birthday { get; set; }

        [DisplayName("Sexo")]
        public string Gender { get; set; }

        [DisplayName("Tipo Usuario")]
        public TypeUser TypeUser { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(15, ErrorMessage = "O campo {0} precisa ter {2} numeros", MinimumLength = 5)]
        [DisplayName("Numero telefone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(10, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        [DisplayName("Senha")]
        public string Password { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(10, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        [Compare("Password", ErrorMessage = "As senhas não conferem.")]
        [DisplayName("Senha")]
        public string ConfirmPassword { get; set; }

        public string Imagem { get; set; }
        public IFormFile ImageUpload { get; set; }
        public DateTime RegisterHour { get; set; }

        public bool FirstLogin { get; set; }

    }
}