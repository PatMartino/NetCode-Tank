using Unity.Netcode;
using UnityEngine;

namespace Server
{
    public class ConnectionButtons : MonoBehaviour
    {
        public void StartHost()
        {
            NetworkManager.Singleton.StartHost();
        }
        public void StartClient()
        {
            NetworkManager.Singleton.StartClient();
        }
    }
}
