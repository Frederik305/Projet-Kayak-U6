using UnityEngine;
using UnityEngine.InputSystem;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Fin");

        GameObject collidedObject = collision.gameObject;
        Debug.Log("Collided with: " + collidedObject.name);

        PlayerInput kayakInputs = collidedObject.GetComponentInParent<PlayerInput>();

        if (kayakInputs != null)
        {
            kayakInputs.SwitchCurrentActionMap("UI");
            
            Debug.Log("Disabled PlayerInput.");

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Debug.Log("Mouse cursor is now visible.");

            // Stop Rigidbody movement
            /*Rigidbody rb = collidedObject.GetComponentInParent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.isKinematic = true; // Optional: makes Rigidbody stop responding to physics
                Debug.Log("Stopped Rigidbody movement.");
            }*/
        }
    }
}
