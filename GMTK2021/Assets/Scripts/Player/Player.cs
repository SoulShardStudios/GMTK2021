using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerAnimator))]
public class Player : MonoBehaviour
{
    #region Vars
    [SerializeField] float _playerSpeed;
    [HideInInspector] public bool hasKey;
    public Vector2 InputMovementVector { get; private set; }
    Rigidbody2D _rigidbody2D;
    [HideInInspector] public PlayerAnimator animator;
    bool _isDead, _isCrouched;
    #endregion
    #region Update/Init Methods
    void Awake()
    {
        // cache references
        animator = GetComponent<PlayerAnimator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void OnEnable() => PlayerHealthManager.AddToManager(this);
    void FixedUpdate()
    {
        if (GameUIControler.S.isPaused || _isDead)
            InputMovementVector = Vector2.zero;
        else
            animator.HandleAnimation();
        // handle the movement
        _rigidbody2D.velocity = InputMovementVector * _playerSpeed * (_isCrouched ? 0.5f : 1);
    }
    #endregion
    #region PlayerInput callbacks
    public void OnMovement(InputAction.CallbackContext context)
    {
        if (!GameUIControler.S.isPaused)
            InputMovementVector = context.ReadValue<Vector2>();
        else
            InputMovementVector = Vector2.zero;
    }
    public void OnCrouched(InputAction.CallbackContext context)
    {
        Debug.Log(_isCrouched);
        _isCrouched = !_isCrouched;
    }
    #endregion
    #region Colision Checks
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            hasKey = true;
            Destroy(collision.gameObject);
            GameUIControler.S.TogglePlayerKeyDisplay(hasKey, tag);
        }
    }
    #endregion
    public void Death()
    {
        _isDead = true;
    }
}