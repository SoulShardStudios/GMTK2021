using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour
{
    [SerializeField] float _playerSpeed;
    [HideInInspector] public bool hasKey;
    public Vector2 InputMovementVector { get; private set; }
    Rigidbody2D _rigidbody2D;
    void Awake()
    {
        // cache references
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (GameUIControler.S.isPaused)
            InputMovementVector = Vector2.zero;
        // handle the movement
        _rigidbody2D.velocity = InputMovementVector * _playerSpeed;
    }
    #region PlayerInput callbacks
    public void OnMovement(InputAction.CallbackContext context)
    {
        if (!GameUIControler.S.isPaused)
            InputMovementVector = context.ReadValue<Vector2>();
        else
            InputMovementVector = Vector2.zero;
    }

    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            hasKey = true;
            Destroy(collision.gameObject);
            GameUIControler.S.TogglePlayerKey(hasKey, gameObject.name);
        }
    }
}