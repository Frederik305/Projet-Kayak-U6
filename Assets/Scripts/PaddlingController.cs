using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class PaddlingController : MonoBehaviour
{
    [SerializeField]  private Floater floater;
    
    [SerializeField] private KayakController kayakController;
    public enum PaddleSide { LeftPaddle, RightPaddle}

    [SerializeField] private PaddleSide paddleSide;
    

    // Update is called once per frame
    void Update()
    {

        
        if (paddleSide == PaddleSide.LeftPaddle && transform.position.y < floater.waterHeight) 
        {
            kayakController.isLeftPaddleUnderwater = true;
            Debug.Log("Paddle Left"); 
            
        }
        else if (paddleSide == PaddleSide.RightPaddle && transform.position.y < floater.waterHeight)
        {
            kayakController.isRightPaddleUnderwater = true;
            Debug.Log("Paddle Right");
        }
        else if (paddleSide == PaddleSide.RightPaddle && transform.position.y > floater.waterHeight)
        {
            kayakController.isRightPaddleUnderwater = false;
            //
        }
        else if (paddleSide == PaddleSide.LeftPaddle && transform.position.y > floater.waterHeight) 
        { 
            kayakController.isLeftPaddleUnderwater = false;
        }
        Debug.Log(kayakController.isLeftPaddleUnderwater + " " + kayakController.isRightPaddleUnderwater);
    }
}
