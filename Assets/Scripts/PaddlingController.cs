using UnityEngine;

public class PaddlingController : MonoBehaviour
{
    [SerializeField] private Floater floater;
    [SerializeField] private KayakController kayakController;

    public enum PaddleSide { LeftPaddle, RightPaddle }

    [SerializeField] private PaddleSide paddleSide;
    [SerializeField] private AudioClip[] PaddleAudioClips;

    [SerializeField] private AudioSource paddleAudioSource;
    

    private bool wasUnderwater = false; // Pour suivre l'�tat pr�c�dent du paddle

    // Update is called once per frame
    void Update()
    {
        bool isUnderwater = transform.position.y < floater.waterHeight;

        if (isUnderwater && !wasUnderwater) // D�tecte l'entr�e dans l'eau
        {
           // PlayRandomPaddleSound();
            paddleAudioSource.Play();

            if (paddleSide == PaddleSide.LeftPaddle)
            {
                kayakController.isLeftPaddleUnderwater = true;
                Debug.Log("Paddle Left");
            }
            else if (paddleSide == PaddleSide.RightPaddle)
            {
                kayakController.isRightPaddleUnderwater = true;
                Debug.Log("Paddle Right");
            }
        }
        else if (!isUnderwater && wasUnderwater) // D�tecte la sortie de l'eau
        {
            if (paddleSide == PaddleSide.LeftPaddle)
            {
                kayakController.isLeftPaddleUnderwater = false;
            }
            else if (paddleSide == PaddleSide.RightPaddle)
            {
                kayakController.isRightPaddleUnderwater = false;
            }
        }

        wasUnderwater = isUnderwater; // Met � jour l'�tat pr�c�dent
    }
    /*
    private void PlayRandomPaddleSound()
    {
        if (PaddleAudioClips.Length > 0 && paddleAudioSource != null)
        {
            int randomIndex = Random.Range(0, PaddleAudioClips.Length);
            paddleAudioSource.PlayOneShot(PaddleAudioClips[randomIndex]);
        }
    }*/
}
