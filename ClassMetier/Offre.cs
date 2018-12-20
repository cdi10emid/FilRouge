using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClassMetier
{
    [DataContract]
    public class Offre
    {
        /// <summary>
        /// attribut idregion
        /// </summary>
        [DataMember]
        public int IdRegion { get; set; }
        /// <summary>
        /// attribut idcontrat
        /// </summary>
        [DataMember]
        public int IdContrat { get; set; }
        /// <summary>
        /// attribut idcontact
        /// </summary>
        [DataMember]
        public int IdContact{ get; set; }

        /// <summary>
        /// Attribut idposte
        /// </summary>
        [DataMember]
        public int IdPoste { get; set; }
        /// <summary>
        /// attribut IdOffre de l'offre en base de donnée
        /// </summary>
        [DataMember]
        public int IdOffre { get; set; }
        /// <summary>
        /// attribut Titre de l'offre
        /// </summary>
        [DataMember]
        public string Titre { get; set; }
        /// <summary>
        /// Attribut DateParution de l'offre
        /// </summary>
        [DataMember]
        public DateTime DateParution { get; set; }
     
       
        /// <summary>
        /// Attribut Description de l'offre
        /// </summary>
        [DataMember]
        public string Description { get; set; }
        /// <summary>
        /// Attribut LienWeb vers l'offre
        /// </summary>
        [DataMember]
        public string LienWeb { get; set; }
        /// <summary>
        /// attribut nom de l'entreprise
        /// </summary>
        [DataMember]
        public string NomEntreprise { get; set; }
        /// <summary>
        /// Attribut nom du contact
        /// </summary>
        [DataMember]
        public string NomContact { get; set; }
        /// <summary>
        /// atrribut téléphone du contact
        /// </summary>
        [DataMember]
        public string TelContact { get; set; }
        /// <summary>
        /// Attribut mail du contact
        /// </summary>
        [DataMember]
        public string MailContact { get; set; }
        /// <summary>
        /// attribut type de contrat
        /// </summary>
        [DataMember]
        public string TypeContrat { get; set; }
        /// <summary>
        /// attribut nom de la région
        /// </summary>
        [DataMember]
        public string Nomregion { get; set; }
        /// <summary>
        /// attribut type de poste
        /// </summary>
        [DataMember]
        public string TypePoste { get; set; }
       
       

        public Offre()
        {

        }
    }
}
