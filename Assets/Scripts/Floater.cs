using UnityEngine;
using UnityEngine.Rendering.HighDefinition;



public class Floater : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody objectWithFloaters;
    public float dephBefSub;
    public float buoyancy;
    public int floaters;
    public float waterDrag;
    public float waterAngularDrag;

    public WaterSurface waterSurface;
    WaterSearchParameters Search;
    WaterSearchResult SearchResult;
    

    private void FixedUpdate()
    {
        objectWithFloaters.AddForceAtPosition(Physics.gravity / floaters, transform.position, ForceMode.Acceleration);

        Search.targetPositionWS = transform.position;
        waterSurface.ProjectPointOnWaterSurface(Search, out SearchResult);

        // Si le kayak est sous la surface de l'eau
        if (transform.position.y < SearchResult.projectedPositionWS.y)
        {
            // Calculer la force de flottabilit�
            float displacementMulti = Mathf.Clamp01((SearchResult.projectedPositionWS.y - transform.position.y) / dephBefSub) * buoyancy;

            // Appliquer la force de flottabilit�
            objectWithFloaters.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMulti, 0f), transform.position, ForceMode.Acceleration);

            // Appliquer la r�sistance de l'eau
            objectWithFloaters.AddForce(displacementMulti * -objectWithFloaters.linearVelocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            objectWithFloaters.AddTorque(displacementMulti * -objectWithFloaters.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    }
}