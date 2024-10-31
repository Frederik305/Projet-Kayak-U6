using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Collections;

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

    private bool isPaddlingRight = false;
    private bool isPaddlingLeft = false;

    [SerializeField] Rigidbody kayakRigidBody;
    public float paddleForce = 30f;         // Force maximale
    public float paddleRotationForce = 20f; // Force de rotation maximale
    public float forceIncreaseRate = 10f;   // Vitesse à laquelle la force augmente
    private float currentForce = 500f;
    private float currentTorque = 1f;
    private Coroutine paddleForceCoroutine;

    private void Start()
    {
        // Verrouiller le curseur pour qu'il ne bouge pas en dehors de la fenêtre de jeu
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Awake()
    {
        var playerInput = GetComponent<PlayerInput>();
        _paddleRightAction = playerInput.actions["PaddleRight"];
        _paddleLeftAction = playerInput.actions["PaddleLeft"];
        lookAction = playerInput.actions["Look"];
    }

    private void OnEnable()
    {
        _paddleRightAction.performed += ctx => OnPaddlingRight();
        _paddleRightAction.canceled += ctx => OnPaddlingRightReleased();

        _paddleLeftAction.performed += ctx => OnPaddlingLeft();
        _paddleLeftAction.canceled += ctx => OnPaddlingLeftReleased();

        lookAction.performed += ctx => OnLook(ctx);
    }

    private void OnDisable()
    {
        _paddleRightAction.performed -= ctx => OnPaddlingRight();
        _paddleRightAction.canceled -= ctx => OnPaddlingRightReleased();

        _paddleLeftAction.performed -= ctx => OnPaddlingLeft();
        _paddleLeftAction.canceled -= ctx => OnPaddlingLeftReleased();

        lookAction.performed -= ctx => OnLook(ctx);
    }

    void OnPaddlingRight()
    {
        isPaddlingRight = true;
        _animator.ResetTrigger("PaddleLeft");
        _animator.SetTrigger("PaddleRight");
        if (paddleForceCoroutine != null)
            StopCoroutine(paddleForceCoroutine);

        // Commencez à appliquer la force vers la droite
        paddleForceCoroutine = StartCoroutine(ApplyForceWhileAnimating(kayakRigidBody.transform.forward, -kayakRigidBody.transform.up));

    }

    void OnPaddlingLeft()
    {
        isPaddlingLeft = true;
        _animator.ResetTrigger("PaddleRight");
        _animator.SetTrigger("PaddleLeft");
        if (paddleForceCoroutine != null)
            StopCoroutine(paddleForceCoroutine);

        // Commencez à appliquer la force vers la gauche
        paddleForceCoroutine = StartCoroutine(ApplyForceWhileAnimating(kayakRigidBody.transform.forward, kayakRigidBody.transform.up));



    }

    void OnPaddlingRightReleased()
    {
        isPaddlingRight = false;
        CheckIdleState();
        
    }

    void OnPaddlingLeftReleased()
    {
        isPaddlingLeft = false;
        CheckIdleState();

        
    }


    void CheckIdleState()
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

    private void OnLook(InputAction.CallbackContext context)
    {
        // Récupérer le mouvement de la souris ou du joystick
        Vector2 lookInput = context.ReadValue<Vector2>();

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


    private IEnumerator ApplyForceWhileAnimating(Vector3 forwardDirection, Vector3 torqueDirection)
    {
        currentForce = 500f;
        currentTorque = 1f;

        while (isPaddlingLeft || isPaddlingRight)
        {
            // Augmenter progressivement la force et le couple (torque)
            currentForce = Mathf.Min(currentForce + forceIncreaseRate * Time.deltaTime, paddleForce);
            currentTorque = Mathf.Min(currentTorque + forceIncreaseRate * Time.deltaTime, paddleRotationForce);

            // Appliquer la force et le torque au kayak
            kayakRigidBody.AddForce(forwardDirection * currentForce * Time.deltaTime);

            // Appliquer le couple (torque) avec une direction correcte
            kayakRigidBody.AddTorque(torqueDirection * currentTorque * Time.deltaTime, ForceMode.Force);

            yield return null; // Attendre la prochaine frame
        }

        // Réinitialiser les forces quand l'animation se termine
        currentForce = 500f;
        currentTorque = 1f;
        kayakRigidBody.angularVelocity = Vector3.zero;
        
    }


}
