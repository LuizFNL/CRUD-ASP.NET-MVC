using System.ComponentModel.DataAnnotations;

namespace FormMVC.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo \"Nome\" é necessário")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo \"Sobrenome\" é necessário")]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "O campo \"Telefone\" é necessário")]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }
    }
}