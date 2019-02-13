using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebServideAccesDonneesHub
{
    public class ChatHub : Hub<IChat>
    {
        private IAccesOffre _accesOffre;
        public ChatHub(IAccesOffre accesOffre)
        {
            _accesOffre = accesOffre;
        }

        public async override Task OnConnectedAsync()
        {
            await Clients.Caller.SendOffreByIdPoste(await _accesOffre.ListeOffre());
            await base.OnConnectedAsync();
        }
        public async Task SendOffreByIdPoste(string IdPoste, string IdContrat, string IdRegion)
        {
            await Clients.Caller.SendOffreByIdPoste(await _accesOffre.ListeOffreInject(IdPoste, IdContrat, IdRegion));
            await base.OnConnectedAsync();
        }
        public async Task SendOffreByDate(string DateDebut, string DateFin )
        {
            await Clients.Caller.SendOffreByDate(await _accesOffre.ListeOffrebyDate(DateDebut, DateFin));
            await base.OnConnectedAsync();
        }
    }
}
