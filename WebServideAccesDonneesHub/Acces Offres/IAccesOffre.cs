using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServideAccesDonneesHub
{
    public interface IAccesOffre
    {
        Task<List<Offre>> ListeOffreInject(string IdPoste, string IdContrat, string IdRegion);
        Task<List<Offre>> ListeOffre();
        Task<List<Offre>> ListeOffrebyDate(string DateDebutint, string DateFinint);
    }
}
