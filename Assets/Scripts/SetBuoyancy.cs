using UnityEngine;

public class SetBuoyancy : MonoBehaviour
{
    [SerializeField] float setBuoyancy;
    private void OnTriggerEnter(Collider other)
    {
        Floater[] floaterComponents = other.GetComponentsInChildren<Floater>();

        for (int i = 0; i < floaterComponents.Length; i++)
        {
            floaterComponents[i].buoyancy = setBuoyancy;
        }
    }
}
