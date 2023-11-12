using ProblemTask1.NetworkUtilites;
using System.Runtime.InteropServices;
using UnityEngine;

namespace ProblemTask1.Network
{
    public class NetworkObject : MonoBehaviour, INetworkTransform
    {
        private NetworkTransformPosition transformPosition;

        public Vector3 GetPosition { get; private set; }

        public void SendNetworkPosition(Vector3 networkTransform)
        {
            transformPosition.x= networkTransform.x.FloatConvertToShort();
            transformPosition.y= networkTransform.y.FloatConvertToShort();
            transformPosition.z= networkTransform.z.FloatConvertToShort();

            NetworkManager.SendPosition(transformPosition);
        }

        private void OnEnable()
        {
            NetworkManager.OnPositionUpdate += OnPositionUpdate;
        }
        private void OnDisable()
        {
            NetworkManager.OnPositionUpdate -= OnPositionUpdate;
        }

        private void OnPositionUpdate(object sender, NetworkTransformPosition e)
        {
            GetPosition = new(e.x, e.y, e.z);
            Debug.Log($" data {e} size {Marshal.SizeOf(e)} byte and {Marshal.SizeOf(e) * 8} bits ");
        }
    }
}
