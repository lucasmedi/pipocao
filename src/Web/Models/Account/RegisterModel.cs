using System.ComponentModel.DataAnnotations;

namespace Web.Models.Account
{
	public class RegisterModel
	{
		[Required]
		[Display(Name = "Nome")]
		public string Name { get; set; }

		[Required]
		[Display(Name = "E-mail")]
		[EmailAddressAttribute]
		public string Email { get; set; }

		[Required]
		[StringLength(30, ErrorMessage = "A {0} deve ter no mínimo {2} caracteres.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Senha")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirme sua senha")]
		[Compare("Password", ErrorMessage = "As senhas informadas não são iguais.")]
		public string ConfirmPassword { get; set; }
	}
}