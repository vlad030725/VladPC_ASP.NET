using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface ISocketService
    {
        List<SocketDto> GetSocket();

        SocketDto GetSockets(int id);

        void CreateSocket(SocketDto socket);

        void UpdateSocket(SocketDto socket);

        void DeleteSocket(int id);
    }
}
