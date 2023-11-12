using ProblemTask1.NetworkUtilites;
using UnityEngine;

namespace ProblemTask1
{
    [RequireComponent(typeof(Rigidbody))]
    public class MasterPlayer : MonoBehaviour
    {
        [SerializeField] float moveSpeed;
       
        Rigidbody rb;
        Vector3 moveDirection;
        INetworkTransform netwokrTransform;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }
        private void Start()
        {
            netwokrTransform = GetComponent<INetworkTransform>();   
        }

        // Update is called once per frame
        void Update()
        {
            var hor = Input.GetAxis("Horizontal");
            var ver = Input.GetAxis("Vertical");
            moveDirection = new Vector3(hor, 0, ver);
        }

        private void FixedUpdate()
        {
            rb.velocity = moveDirection * moveSpeed;

            if (rb.velocity.magnitude >0 && !rb.IsSleeping())
            {
                netwokrTransform.SendNetworkPosition(rb.velocity);
            }
        }

    }
}
