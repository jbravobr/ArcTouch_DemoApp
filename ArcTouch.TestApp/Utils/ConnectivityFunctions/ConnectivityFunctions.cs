using System;
using System.Threading.Tasks;

namespace ArcTouch.TestApp
{
    public class ConnectivityFunctions : IConnectivityFunctions
    {
        public bool IsConnected()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsConnectedAsync()
        {
            if (App.IsEmulatingAndroid)
                return true;

            if (!Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
                return false;

            var checkConnection = await Plugin.Connectivity.CrossConnectivity.Current.IsReachable(Constants.RemoteHostForTestConnection);
            return checkConnection;
        }
    }
}