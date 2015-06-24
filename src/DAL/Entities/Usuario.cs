using DAL.Classes;

namespace DAL.Entities
{
    public class Usuario : IUsuario
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Email { get; set; }
    }
}