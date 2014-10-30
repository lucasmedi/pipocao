using System.ComponentModel.DataAnnotations;

namespace Web.Models.Account
{
	public class LocalPasswordModel
	{
		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Senha atual")]
		public string OldPassword { get; set; }

		[Required]
		[StringLength(100, ErrorMessage = "A {0} deve ter no mínimo {2} caracteres.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Nova senha")]
		public string NewPassword { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirme sua nova senha")]
		[Compare("NewPassword", ErrorMessage = "As senhas informadas não são iguais.")]
		public string ConfirmPassword { get; set; }
	}
}