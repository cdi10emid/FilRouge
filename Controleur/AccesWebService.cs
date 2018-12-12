using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using System.Threading.Tasks;
using ClassMetier;

namespace Controleur
{
    public class AccesWebService
    {
        private static string URL_SERVICE = "http://user15.2isa.org/Service1.svc";

        //Le controleur utilise la librairy tierce RestSharp (package NuGet)  
        private RestClient client;

        public AccesWebService()
        {
            client = new RestClient(URL_SERVICE);
        }
        public List<Offre> WebAfficheOffre()
        {
            List<Offre> listeOffre = null;
            var request = new RestRequest("offre", Method.GET);

            var response = client.Execute<List<Offre>>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                listeOffre = response.Data;
            }
            return listeOffre;
        }
    }
}
