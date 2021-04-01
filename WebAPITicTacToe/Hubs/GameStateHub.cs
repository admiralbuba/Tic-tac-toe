using Core.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace API.Hubs
{   
    [EnableCors("AllowOrigin")]
    public class GameStateHub : Hub
    {
        public async Task Send(ButtonInfo buttonInfo)
        {
            await this.Clients.Others.SendAsync("ChangeButton", buttonInfo);
        }
    }
}
