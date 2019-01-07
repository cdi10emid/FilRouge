using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassAccesData
{
    /// <summary>
    /// Class de gestion des exeptions
    /// </summary>
    [Serializable]
    
    public class DAOException : Exception
    {
        /// <summary>
        /// constructeur DAOException
        /// </summary>
        public DAOException() { }
        /// <summary>
        /// constructeur DAOException
        /// </summary>
        /// <param name="message"></param>
        public DAOException(string message) : base(message) { }
        /// <summary>
        /// constructeur DAOException
        /// </summary>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public DAOException(string message, Exception inner) : base(message, inner) { }
        /// <summary>
        /// constructeur DAOException
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected DAOException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
