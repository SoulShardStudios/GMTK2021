using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerAnimator : MonoBehaviour
{
    [Header("Animation names idle")]
    [SerializeField] string _idleTop;
    [SerializeField] string _idleBottom;
    [SerializeField] string _idleLeft;
    [SerializeField] string _idleRight;
    [Header("Animation names walk")]
    [SerializeField] string _walkTop;
    [SerializeField] string _walkBottom;
    [SerializeField] string _walkLeft;
    [SerializeField] string _walkRight;

    PlayerMovement _playerMovement;
    
    void Awake()
    {
        // cache references
        _playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        HandleAnimation();
    }

    void HandleAnimation()
    {
        // TODO: add some logic tied with PlayerAttack? so it plays attack animation

        var normalizedMovementVector = _playerMovement.InputMovementVector.normalized;

        
    }
}
