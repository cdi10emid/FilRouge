using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClassMetier
{
    [DataContract]
    public class Poste
    {/// <summary>
     /// attribut Id Poste
     /// </summary>
      [DataMember]
        public int Idposte { get; set; }
        /// <summary>
        /// attribut nom de la région
        /// </summary>
        [DataMember]
        public string TypePoste { get; set; }
        /// <summary>
        /// Constructeur région
        /// </summary>
        public Poste()
        {

        }
        public override string ToString()
        {
            return TypePoste;
        }
    }
}
