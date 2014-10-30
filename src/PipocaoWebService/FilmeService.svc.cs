using System.Collections.Generic;
using System.Linq;
using DAL.Classes;
using DAL.Repositories;
using PipocaoWebService.Classes;

namespace PipocaoWebService
{
	public class FilmeService : IFilmeService
	{
		private readonly IFilmeRepository filmeRepository;
		private readonly IComentarioRepository comentarioRepository;

		public FilmeService(IFilmeRepository repo)
		{
			filmeRepository = repo;
		}

		public FilmeService(IComentarioRepository repo)
		{
			comentarioRepository = repo;
		}

		public FilmeService(IFilmeRepository filmeRepo, IComentarioRepository comentarioRepo)
		{
			filmeRepository = filmeRepo;
			comentarioRepository = comentarioRepo;
		}

		public List<Filme> buscaFilmes()
		{
			return filmeRepository.All().Select(o => converterFilme(o)).ToList();
		}

		public List<Comentario> buscaComentariosPorFilme(string titulo)
		{
			return comentarioRepository.FilterByMovie(titulo).Select(o => converterComentario(o)).ToList();
		}

		private Filme converterFilme(IFilme iFilme)
		{
			var filme = new Filme
			{
				Id = iFilme.Id,
				Titulo = iFilme.Titulo,
				Descricao = iFilme.Descricao,
				UrlImagem = iFilme.UrlImagem,
				UrlTrailer = iFilme.UrlTrailer,
				tipomidia = iFilme.TipoMidia
			};
			return filme;
		}

		private Comentario converterComentario(IComentario iComentario)
		{
			var comentario = new Comentario
			{
				Id = iComentario.Id,
				Filme = converterFilme(iComentario.Filme),
				Gostei = iComentario.Gostei,
				Nota = iComentario.Nota,
				Texto = iComentario.Texto,
				Data = iComentario.Data
			};
			return comentario;
		}
	}
}