using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebServideAccesDonneesHub
{
   public interface IChat
    {
       // Task SendOffre(IList<Offre> ListeOffre);
        Task SendOffreByIdPoste(List<Offre> ListeOffre);
        Task SendOffreByDate(List<Offre> ListeOffre);
    }
}
