using UnityEngine;
[RequireComponent(typeof(Player))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerAnimator : AnimatorController
{
    #region Direction Based Anim Vars
    [SerializeField] AnimationBlender _idleBlender, _walkBlender, _attackBlender;
    Player _player;
    [HideInInspector] public Vector2 _cachedDirection;
    #endregion
    #region FlashAnimVars
    int _flashes = 0;
    int dir = 0;
    SpriteRenderer _renderer;
    [SerializeField] float _flashSpeed;
    #endregion
    void Awake()
    {
        // cache references
        _player = GetComponent<Player>();
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (_flashes > 0)
            HandleDamageFlash();
    }
    public void HandleAnimation()
    {
        // TODO: add some logic tied with PlayerAttack? so it plays attack animation

        var normalizedMovementVector = _player.InputMovementVector.normalized;
        if (!_player.isAttacking)
        {
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
        else
            ChangeAnimState(_attackBlender.GetBlendedAnimation(_cachedDirection));
    }
    public void StartDamageFlash() => _flashes = 6;
    void HandleDamageFlash()
    {
        _flashes--;
        /*
        dir = _flashes % 2 == 0 ? -1 : 1;
        _renderer.color = ModAlpha(_renderer.color, dir*_flashSpeed);
        if (_renderer.color.a >= 1 || _renderer.color.a <= 0)
            _flashes--;
        */
    }
    Color ModAlpha(Color toMod, float modBy) => new Color(toMod.r, toMod.g, toMod.b, toMod.a + modBy);
}
