using UnityEngine;
using UnityEngine.InputSystem;

public class FinishLine : MonoBehaviour
{
    
    [SerializeField] private GameSession gameSession;
    private void OnTriggerEnter(Collider collision)
    {


        GameObject collidedObject = collision.gameObject;
        

        //PlayerInput kayakInputs = collidedObject.GetComponentInParent<PlayerInput>();

        if (collision.CompareTag("kayak"))
        {
            Debug.Log("test");
            // Stop Rigidbody movement
            Rigidbody rb = collidedObject.GetComponentInParent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.isKinematic = true; // Optional: makes Rigidbody stop responding to physics
                
            }
            gameSession.Finish();
        }
        
    }
}
