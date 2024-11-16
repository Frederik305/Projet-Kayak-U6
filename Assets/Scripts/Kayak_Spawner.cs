using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class Kayak_Spawner : MonoBehaviour
{
    [SerializeField] private GameObject kayak;
    [SerializeField] private GameObject riverPrefab;
    void Start()
    {
        GameObject instantiatedKayak = Instantiate(kayak, transform.localPosition, transform.localRotation);

        Floater[] floaterComponents = instantiatedKayak.GetComponentsInChildren<Floater>();

        WaterSurface waterSurfaceComponent = riverPrefab.GetComponent<WaterSurface>();

        if (waterSurfaceComponent != null)
        {
            foreach (Floater floater in floaterComponents)
            {
                floater.waterSurface = waterSurfaceComponent;
            }
        }
        else
        {
            Debug.LogWarning("WaterSurface component not found on the riverPrefab.");
        }
    }
}
