using Unity.VisualScripting;
using UnityEngine;

public class Kayak_Spawner : MonoBehaviour
{
    [SerializeField] private GameObject kayak;
    [SerializeField] private GameObject riverPrefab;
    void Start()
    {
        Instantiate(kayak, transform.localPosition, transform.localRotation);

        //GameObject subObject1 = kayak.Find("floater");
    }
}
