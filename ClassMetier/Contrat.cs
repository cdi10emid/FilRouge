using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClassMetier
{
    [DataContract]
    public  class Contrat
    {
        
        /// <summary>
        /// attribut IdContrat
        /// </summary>
        [DataMember]
        public int IdContrat { get; set; }
        /// <summary>
        /// attribut type du contrat
        /// </summary>
        [DataMember]
        public string TypeContrat { get; set; }
        /// <summary>
        /// Constructeur du contrat
        /// </summary>
        public Contrat()
        {

        }
        public override string ToString()
        {
            return TypeContrat;
        }
    }
}
