using System;
using System.Runtime.Serialization;

namespace PipocaoWebService.Classes
{
    [DataContract]
    public class Comentario
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public DateTime Data { get; set; }

        [DataMember]
        public bool Gostei { get; set; }

        [DataMember]
        public string Texto { get; set; }

        [DataMember]
        public int Nota { get; set; }

        [DataMember]
        public Filme Filme { get; set; }
    }
}