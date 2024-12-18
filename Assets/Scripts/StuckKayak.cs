using UnityEngine;
using System.Collections;

public class StuckKayak : MonoBehaviour
{
    private Vector3 initialPosition;
    [SerializeField] private float radius;
    [SerializeField] private int pointsInSample;
    [SerializeField] private float delayBetweenPoints;
    [SerializeField] private int amountOfPointsNeededInRadius;

    private void OnCollisionEnter(Collision collision)
    {
        initialPosition = transform.position;

        StartCoroutine(LogPositionCoroutine());
    }

    private IEnumerator LogPositionCoroutine()
    {
        int pointsInRange = 0;

        for (int i = 0; i < pointsInSample; i++)
        {
            Vector3 currentPosition = transform.position;

            if (Vector3.Distance(initialPosition, currentPosition) <= radius)
            {
                pointsInRange++;
                
            }
            

            yield return new WaitForSeconds(delayBetweenPoints);
        }

        if (pointsInRange >= amountOfPointsNeededInRadius)
        {
            
            EndSession();
        }
    }
    private void EndSession()
    {
        GameSession gameSession = FindFirstObjectByType<GameSession>();
        gameSession.Finish();
    }
}
