using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ClassAccesData;
using ClassMetier;

namespace WebService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service : IService
    {
        public List<Offre> AfficheOffreByDate(string Debut, string Fin)
        {
            AccesOffre accesOffre = new AccesOffre();
            return accesOffre.AfficheOffreByDate(Convert.ToInt32(Debut), Convert.ToInt32( Fin));
        }



        public List<Offre> GetOffreAsJson()
        {
            AccesOffre accesOffre = new AccesOffre();
            return accesOffre.AfficheOffre();

        }

        public List<Offre> GetOffreByIdPoste(string IdPoste)
        {
            AccesOffre accesOffre = new AccesOffre();
            return accesOffre.AfficheOffreByIdPoste(Convert.ToInt32(IdPoste));
        }
        public List<Offre> GetOffreByIdPosteIdContrat(string IdPoste, string IdContrat)
        {
            AccesOffre accesOffre = new AccesOffre();
            return accesOffre.AfficheOffreByIdPosteIdContrat(Convert.ToInt32(IdPoste), Convert.ToInt32(IdContrat));
        }

        public List<Offre> GetOffreByIdPosteIdContratIdRegion(string IdPoste, string IdContrat, string IdRegion)
        {
            AccesOffre accesOffre = new AccesOffre();
            return accesOffre.AfficheOffreByIdPosteIdContratIdRegion(Convert.ToInt32(IdPoste), Convert.ToInt32(IdContrat), Convert.ToInt32(IdRegion));
        }
    }
}
