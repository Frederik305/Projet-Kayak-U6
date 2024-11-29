using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Splines;

public class KayakController : MonoBehaviour
{
    public Animator _animator;
    private InputAction _paddleRightAction;
    private InputAction _paddleLeftAction;
    public float mouseVerticalSensitivity = 30f; // Sensibilité de la caméra
    public float mouseHorizontalSensitivity = 50f;
    private InputAction lookAction;
    public Camera camera;
    private float xRotation = 0f;
    private float yRotation = 90f;

    private bool isPaddlingRight;
    private bool isPaddlingLeft;

    public bool isLeftPaddleUnderwater;
    public bool isRightPaddleUnderwater;

    [SerializeField] Rigidbody kayakRigidBody;
    public float paddleForce = 30f;         // Force maximale
    public float paddleRotationForce = 20f; // Force de rotation maximale
    public float forceIncreaseRate = 10f;   // Vitesse à laquelle la force augmente
    private float currentForce = 500f;
    private float currentTorque = 1f;
    private Coroutine paddleForceCoroutine;
    private Vector2 entreeMouvement;
    private GameSession gameSession;

    private void Start()
    {
        // Verrouiller le curseur pour qu'il ne bouge pas en dehors de la fenêtre de jeu
        gameSession = FindFirstObjectByType<GameSession>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    void OnPause()
    {
        gameSession.Pause();

    }
    void OnResume()
    {
        gameSession.Resume();
    }

    
    void OnMove(InputValue valeur)
    {
        
        entreeMouvement = valeur.Get<Vector2>();
        Debug.Log((entreeMouvement.x,entreeMouvement.y));

    }

    private void PaddlingRight()
    {
        
        _animator.ResetTrigger("PaddleLeft");
        _animator.SetTrigger("PaddleRight");
        float curentSpeed = _animator.GetFloat("Speed");
        if (curentSpeed < 0) { _animator.SetFloat("Speed", curentSpeed * -1); }


        if (paddleForceCoroutine != null)
            StopCoroutine(paddleForceCoroutine);

        // Commencez à appliquer la force vers la droite
        
        paddleForceCoroutine = StartCoroutine(ApplyPaddlingForce(kayakRigidBody.transform.forward, -kayakRigidBody.transform.up));
        

    }

    private void PaddlingLeft()
    {
        
        _animator.ResetTrigger("PaddleRight");
        _animator.SetTrigger("PaddleLeft");
        float curentSpeed = _animator.GetFloat("Speed");
        if (curentSpeed< 0) { _animator.SetFloat("Speed", curentSpeed * -1); }
        if (paddleForceCoroutine != null)
            StopCoroutine(paddleForceCoroutine);

        // Commencez à appliquer la force vers la gauche
        
        paddleForceCoroutine = StartCoroutine(ApplyPaddlingForce(kayakRigidBody.transform.forward, kayakRigidBody.transform.up));

        

    }

    private void ReversePaddlingRight()
    {

        // Commencez à appliquer la force vers la gauche
        
        _animator.ResetTrigger("PaddleLeft");
        _animator.SetTrigger("PaddleRight");
        float curentSpeed=_animator.GetFloat("Speed");
        if (curentSpeed > 0) { _animator.SetFloat("Speed", curentSpeed * -1); }
        
        if (paddleForceCoroutine != null)
            StopCoroutine(paddleForceCoroutine);
        paddleForceCoroutine = StartCoroutine(ApplyPaddlingForce(-kayakRigidBody.transform.forward, kayakRigidBody.transform.up));

    }
    private void ReversePaddlingLeft()
    {

        // Commencez à appliquer la force vers la gauche
        
        _animator.ResetTrigger("PaddleRight");
        _animator.SetTrigger("PaddleLeft");
        float curentSpeed = _animator.GetFloat("Speed");
        if(curentSpeed > 0) {_animator.SetFloat("Speed", curentSpeed * -1); }
        
        if (paddleForceCoroutine != null)
            StopCoroutine(paddleForceCoroutine);
        paddleForceCoroutine = StartCoroutine(ApplyPaddlingForce(-kayakRigidBody.transform.forward, -kayakRigidBody.transform.up));

    }



    private void CheckIdleState()
    {
        // Ne revenir à l'état "Idle" que si aucune touche n'est enfoncée
        if (!isPaddlingRight && !isPaddlingLeft)
        {
            _animator.ResetTrigger("PaddleRight");
            _animator.ResetTrigger("PaddleLeft");
            _animator.SetTrigger("Idle");
            if (paddleForceCoroutine != null)
                StopCoroutine(paddleForceCoroutine);
        }
    }
    private void Update()
    {
        Debug.Log(isPaddlingLeft + " " + isPaddlingRight);
        Look();
        if(entreeMouvement.x < 0)
        {
            isPaddlingLeft = true;
            if(entreeMouvement.y < 0) ReversePaddlingLeft();
            else PaddlingLeft();
        }
        else if (entreeMouvement.x > 0)
        {
            isPaddlingRight=true;
            if(entreeMouvement.y < 0)ReversePaddlingRight();
            else PaddlingRight();
        }
       
        else
        {
            isPaddlingRight=false;
            isPaddlingLeft=false;
            CheckIdleState();
        }
    }
    private void FixedUpdate()
    {
        
        
        //Debug.Log(isPaddlingLeft + " " + isPaddlingRight);
    }


    private IEnumerator ApplyPaddlingForce(Vector3 forwardDirection, Vector3 torqueDirection)
    {
        currentForce = 0f;
        currentTorque = 0f;

        

        while ((isPaddlingLeft && isLeftPaddleUnderwater) || (isPaddlingRight && isRightPaddleUnderwater))
        {
        // Appliquer la force pendant la durée spécifiée

            
            // Augmenter progressivement la force et le couple
            currentForce = Mathf.Min(currentForce + forceIncreaseRate, paddleForce* Time.deltaTime);
            currentTorque = Mathf.Min(currentTorque + forceIncreaseRate * Time.deltaTime, paddleRotationForce);

            // Appliquer la force et le couple au kayak
            kayakRigidBody.AddForce(currentForce * forwardDirection );
            kayakRigidBody.AddTorque(currentTorque * torqueDirection, ForceMode.Force);
            yield return null; 

        }

            // Réinitialiser les forces quand l'animation se termine
        currentForce = 0f;
        currentTorque = 0f;

       
    }



    private void Look()
    {
        // Récupérer le mouvement de la souris ou du joystick
        Vector2 lookInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        // Appliquer la sensibilité
        float mouseX = lookInput.x * mouseHorizontalSensitivity * Time.deltaTime;
        float mouseY = lookInput.y * mouseVerticalSensitivity * Time.deltaTime;

        // Gérer la rotation verticale (axe X)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limiter la rotation verticale

        // Gérer la rotation horizontale (axe Y)
        yRotation += mouseX; // Ajouter l'entrée de la souris à la rotation horizontale
        yRotation = Mathf.Clamp(yRotation, -140f, 140f);

        // Appliquer la rotation sur les deux axes
        camera.transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }


}
