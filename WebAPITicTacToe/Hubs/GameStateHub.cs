using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace API.Hubs
{
    [EnableCors("AllowOrigin")]
    public class GameStateHub : Hub
    {

    }
}
