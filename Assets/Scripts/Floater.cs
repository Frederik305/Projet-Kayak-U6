using UnityEngine;
using UnityEngine.Rendering.HighDefinition;



public class Floater : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Rigidbody objectWithFloaters;
    [SerializeField] float dephBefSub;
    [SerializeField] float buoyancy;
    [SerializeField] int floaters;
    [SerializeField] float waterDrag;
    [SerializeField] float waterAngularDrag;
    [SerializeField] float currentSpeed=0.5f;
    [SerializeField] public WaterSurface waterSurface;
    private WaterSearchParameters Search;
    private WaterSearchResult SearchResult;
    public float waterHeight;

    private void FixedUpdate()
    {
        objectWithFloaters.AddForceAtPosition(Physics.gravity / floaters, transform.position, ForceMode.Acceleration);
        
        Search.startPositionWS = transform.position;
        Search.includeDeformation = true;
        
        waterSurface.ProjectPointOnWaterSurface(Search, out SearchResult);
        waterHeight = SearchResult.projectedPositionWS.y;

        // Si le kayak est sous la surface de l'eau
        if (transform.position.y < waterHeight)
        {
            // Calculer la force de flottabilit�
            float displacementMulti = Mathf.Clamp01((waterHeight - transform.position.y) / dephBefSub) * buoyancy;

            // Appliquer la force de flottabilit�
            objectWithFloaters.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMulti, 0f), transform.position, ForceMode.Acceleration);

            // Appliquer la r�sistance de l'eau
            objectWithFloaters.AddForce(displacementMulti * -objectWithFloaters.linearVelocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            objectWithFloaters.AddTorque(displacementMulti * -objectWithFloaters.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);

            ApplyWaterCurrent();
        }


    }
    private void ApplyWaterCurrent()
    {
        // Récupérer la direction et la vitesse du courant à la position de l'objet
        Vector3 currentDirection = SearchResult.currentDirectionWS; // Direction du courant
        

        // Calculer la force du courant
        Vector3 currentForce = currentDirection * currentSpeed * buoyancy;

        // Appliquer la force du courant à l'objet
        objectWithFloaters.AddForce(currentForce, ForceMode.Acceleration);
    }
}