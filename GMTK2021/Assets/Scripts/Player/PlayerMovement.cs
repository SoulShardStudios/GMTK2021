using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _playerSpeed;

    Vector2 _inputMovementVector;
    Rigidbody2D _rigidbody2D;
    
    void Awake()
    {
        // cache references
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // handle the movement
        _rigidbody2D.velocity = _inputMovementVector * _playerSpeed;
    }

    #region PlayerInput callbacks

    public void OnMovement(InputAction.CallbackContext context)
    {
        _inputMovementVector = context.ReadValue<Vector2>();
    }
    
    #endregion
}
