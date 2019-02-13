using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServideAccesDonneesHub
{
 
    public class Offre
    {
        /// <summary>
        /// attribut idregion
        /// </summary>
      
        public int IdRegion { get; set; }
        /// <summary>
        /// attribut idcontrat
        /// </summary>
    
        public int IdContrat { get; set; }
        /// <summary>
        /// attribut idcontact
        /// </summary>
       
        public int IdContact { get; set; }

        /// <summary>
        /// Attribut idposte
        /// </summary>
       
        public int IdPoste { get; set; }
        /// <summary>
        /// attribut IdOffre de l'offre en base de donnée
        /// </summary>
       
        public int IdOffre { get; set; }
        /// <summary>
        /// attribut Titre de l'offre
        /// </summary>
     
        public string Titre { get; set; }
        /// <summary>
        /// Attribut DateParution de l'offre
        /// </summary>
   
        public DateTime DateParution { get; set; }


        /// <summary>
        /// Attribut Description de l'offre
        /// </summary>
       
        public string Description { get; set; }
        /// <summary>
        /// Attribut LienWeb vers l'offre
        /// </summary>
      
        public string LienWeb { get; set; }
        /// <summary>
        /// attribut nom de l'entreprise
        /// </summary>
      
        public string NomEntreprise { get; set; }
        /// <summary>
        /// Attribut nom du contact
        /// </summary>
      
        public string NomContact { get; set; }
        /// <summary>
        /// atrribut téléphone du contact
        /// </summary>
        
        public string TelContact { get; set; }
        /// <summary>
        /// Attribut mail du contact
        /// </summary>
       
        public string MailContact { get; set; }
        /// <summary>
        /// attribut type de contrat
        /// </summary>
    
        public string TypeContrat { get; set; }
        /// <summary>
        /// attribut nom de la région
        /// </summary>
      
        public string Nomregion { get; set; }
        /// <summary>
        /// attribut type de poste
        /// </summary>
       
        public string TypePoste { get; set; }



        public Offre()
        {

        }
    }
}
