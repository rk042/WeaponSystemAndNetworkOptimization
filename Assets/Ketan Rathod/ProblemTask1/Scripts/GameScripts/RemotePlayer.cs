using ProblemTask1.NetworkUtilites;
using UnityEngine;

namespace ProblemTask1
{
    public class RemotePlayer : MonoBehaviour
    {
        Rigidbody rb;
        INetworkTransform networkTransform;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }
        private void Start()
        {
            networkTransform = GetComponent<INetworkTransform>();
        }

        private void Update()
        {
            rb.velocity = networkTransform.GetPosition;
        }
    }
}
