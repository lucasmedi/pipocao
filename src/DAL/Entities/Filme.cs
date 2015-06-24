using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Classes;
using DAL.Helpers;

namespace DAL.Entities
{
    public class Filme : IFilme
    {
        public virtual int Id { get; set; }
        public virtual int? TmdbId { get; set; }
        public virtual string Titulo { get; set; }
        public virtual string Descricao { get; set; }
        public virtual string UrlImagem { get; set; }
        public virtual string UrlTrailer { get; set; }
        public virtual TipoMidia TipoMidia { get; set; }

        public virtual int UsuarioId { get; set; }
        public virtual IUsuario Usuario { get; set; }

        private IList<IComentario> _comentarios;
        public virtual IList<IComentario> Comentarios { get { return _comentarios.ToList().AsReadOnly(); } set { _comentarios = value; } }

        public Filme()
        {
            _comentarios = new List<IComentario>();
        }

        public virtual void AddComentario(IComentario comentario, IUsuario usuario)
        {
            comentario.Filme = this;
            comentario.Usuario = usuario;

            if (!_comentarios.Contains(comentario))
            {
                this._comentarios.Add(comentario);
            }
        }
    }
}