using System;
using System.Threading.Tasks;

namespace ArcTouch.TestApp
{
    public interface IConnectivityFunctions
    {
        bool IsConnected();
        Task<bool> IsConnectedAsync();
    }
}