using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DAL.Classes;
using PipocaoWebService.Classes;


namespace PipocaoWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFilmeWc" in both code and config file together.
    [ServiceContract]
    public interface IFilmeService
    {
       

        [OperationContract]
        [WebGet(UriTemplate = "/buscaFilmes", ResponseFormat = WebMessageFormat.Xml)]
        List<Filme> buscaFilmes();

        [OperationContract]
        [WebGet(UriTemplate = "/buscaComentariosPorFilme/{titulo}", ResponseFormat = WebMessageFormat.Xml)]
        List<Comentario> buscaComentariosPorFilme(string titulo);

    }
}
