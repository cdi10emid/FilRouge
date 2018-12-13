using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMetier
{
   public class Contact
    {
        /// <summary>
        /// Attribut Id Contact
        /// </summary>
        public int IdContact { get;  set; }
        /// <summary>
        /// attribut nom de l'entreprise
        /// </summary>
        public string NomEntreprise { get; set; }
        /// <summary>
        /// attribut nom du contact
        /// </summary>
        public string NomContact { get; set; }
        /// <summary>
        /// attribut nom du contact
        /// </summary>
        public string TelContact { get; set; }
        /// <summary>
        /// attribut mail du contact
        /// </summary>
        public string MailContact { get; set; }
        /// <summary>
        /// Constructeur contact
        /// </summary>
        public Contact()
        {

        }
    }
}
