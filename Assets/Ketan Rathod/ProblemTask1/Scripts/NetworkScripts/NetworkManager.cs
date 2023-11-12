using System;
using UnityEngine;

namespace ProblemTask1.Network
{
    public class NetworkManager : MonoBehaviour
    {
        private static NetworkManager instance;
        
        public static EventHandler<NetworkTransformPosition> OnPositionUpdate;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        public static void SendPosition(NetworkTransformPosition position)
        {
            OnPositionUpdate?.Invoke(null, position);
        }
    }
}
