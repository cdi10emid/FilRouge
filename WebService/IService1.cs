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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService1
    {

       

        [OperationContract]
        [WebGet(UriTemplate = "offre", ResponseFormat = WebMessageFormat.Json)]
        List<Offre> GetOffreAsJson();
        [OperationContract]
        [WebGet(UriTemplate = "contrat", ResponseFormat = WebMessageFormat.Json)]
        List<Contrat> GetContrats();

        // TODO: ajoutez vos opérations de service ici
    }



    
}
