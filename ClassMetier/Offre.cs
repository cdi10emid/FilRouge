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
        public Offre()
        {

        }
    }
}
