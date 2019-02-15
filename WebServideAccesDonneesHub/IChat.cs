using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebServideAccesDonneesHub
{
   public interface IChat
    {
        Task SendOffreById(List<Offre> ListeOffre);
        Task SendOffreAll(List<Offre> ListeOffre);
        Task SendOffreByDate(List<Offre> ListeOffre);
    }
}
