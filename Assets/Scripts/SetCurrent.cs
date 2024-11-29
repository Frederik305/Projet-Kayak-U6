using UnityEngine;

public class SetCurrent : MonoBehaviour
{
    [SerializeField] float setCurrentSpeed;
    private void OnTriggerEnter(Collider other)
    {
        Floater[] floaterComponents = other.GetComponentsInChildren<Floater>();

        for (int i = 0; i < floaterComponents.Length; i++)
        {
            floaterComponents[i].currentSpeed = setCurrentSpeed;
        }
    }
}
