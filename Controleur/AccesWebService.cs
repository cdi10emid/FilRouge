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
        private static string URL_SERVICE = "http://user15.2isa.org/Service.svc";

        //Le controleur utilise la librairy tierce RestSharp (package NuGet)  
        private RestClient client;
        /// <summary>
        /// Construteur AccesWebService
        /// </summary>
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
        public List<Offre> WebAfficheOffreByIdPoste(string IdPoste)
        {
            List<Offre> listeOffre = null;
            var request = new RestRequest("offre/{IdPoste}", Method.GET);
            request.AddParameter("IdPoste", IdPoste.ToString(), ParameterType.UrlSegment);

            var response = client.Execute<List<Offre>>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                listeOffre = response.Data;
            }
            return listeOffre;
        }
        public List<Offre> WebAfficheOffreByIdPosteIdContrat(string IdPoste,string IdContrat)
        {
            List<Offre> listeOffre = null;
            var request = new RestRequest("offre/{IdPoste}/{IdContrat}", Method.GET);
            request.AddUrlSegment("IdPoste", IdPoste.ToString());
            request.AddUrlSegment("IdContrat", IdContrat.ToString());
          

            var response = client.Execute<List<Offre>>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                listeOffre = response.Data;
            }
            return listeOffre;
        }
        public List<Offre> WebAfficheOffreByIdPosteIdContratIdRegion(string IdPoste, string IdContrat,string IdRegion)
        {
            List<Offre> listeOffre = null;
            var request = new RestRequest("offre/{IdPoste}/{IdContrat}/{IdRegion}", Method.GET);
            request.AddUrlSegment("IdPoste", IdPoste.ToString());
            request.AddUrlSegment("IdContrat", IdContrat.ToString());
            request.AddUrlSegment("IdRegion", IdRegion.ToString());


            var response = client.Execute<List<Offre>>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                listeOffre = response.Data;
            }
            return listeOffre;
        }
        //public List<Offre> WebAfficheOffreByDate(string DateDebut,string DateFin)
        //{
        //    List<Offre> listeOffre = null;
        //    var request = new RestRequest("offre/{DateDebut}/{DateFin}", Method.GET);
        //    request.AddUrlSegment("DateDebut", DateDebut.ToString());
        //    request.AddUrlSegment("DateFin", DateFin.ToString());

        //    var response = client.Execute<List<Offre>>(request);
        //    if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //    {
        //        listeOffre = response.Data;
        //    }
        //    return listeOffre;
        //}
    }
}
