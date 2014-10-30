using System.Runtime.Serialization;
using DAL.Helpers;

namespace PipocaoWebService.Classes
{
    [DataContract]
    public class Filme
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Titulo { get; set; }

        [DataMember]
        public string Descricao { get; set; }

        [DataMember]
        public string UrlImagem { get; set; }

        [DataMember]
        public string UrlTrailer { get; set; }

        [DataMember]
        public TipoMidia tipomidia { get; set; }
    }
}