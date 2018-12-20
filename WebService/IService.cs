using ClassMetier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WebService
{
    
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebGet(UriTemplate = "offre", ResponseFormat = WebMessageFormat.Json)]
        List<Offre> GetOffreAsJson();

        [OperationContract]
        [WebGet(UriTemplate = "offre/{IdPoste}", ResponseFormat = WebMessageFormat.Json)]
        List<Offre> GetOffreByIdPoste(string IdPoste);

        [OperationContract]
        [WebGet(UriTemplate = "offre/{IdPoste}/{IdContrat}", ResponseFormat = WebMessageFormat.Json)]
        List<Offre> GetOffreByIdPosteIdContrat(string IdPoste, string IdContrat);

        [OperationContract]
        [WebGet(UriTemplate = "offre/{IdPoste}/{IdContrat}/{IdRegion}", ResponseFormat = WebMessageFormat.Json)]
        List<Offre> GetOffreByIdPosteIdContratIdRegion(string IdPoste, string IdContrat, string IdRegion);

        [OperationContract]
        [WebGet(UriTemplate = "contrat", ResponseFormat = WebMessageFormat.Json)]
        List<Contrat> GetContrats();

        //[OperationContract]
        //[WebGet(UriTemplate = "offre/{DateDebut}/{DateFin}", ResponseFormat = WebMessageFormat.Json)]
        //List<Offre> AfficheOffreByDate(string DateDebut, string DateFin);
    }
}
