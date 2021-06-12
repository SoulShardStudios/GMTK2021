using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Player))]
public class PlayerAnimator : AnimatorController
{
    [SerializeField] AnimationBlender _idleBlender, _walkBlender;
    Player _playerMovement;
    Vector2 _cachedDirection;
    void Awake()
    {
        // cache references
        _playerMovement = GetComponent<Player>();
        _animator = GetComponent<Animator>();
    }
    void Update() => HandleAnimation();
    void HandleAnimation()
    {
        // TODO: add some logic tied with PlayerAttack? so it plays attack animation

        var normalizedMovementVector = _playerMovement.InputMovementVector.normalized;
        if (normalizedMovementVector != Vector2.zero)
        {
            _cachedDirection = normalizedMovementVector;
            ChangeAnimState(_walkBlender.GetBlendedAnimation(normalizedMovementVector));
        }
        else
        {
            ChangeAnimState(_idleBlender.GetBlendedAnimation(_cachedDirection));
        }
            
    }
}
