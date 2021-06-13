using Pathfinding;
using UnityEngine;

[RequireComponent(typeof(AIDestinationSetter))]
[RequireComponent(typeof(AIPath))]
public abstract class Entity : MonoBehaviour
{
    [SerializeField] protected Transform _targetedPlayer;
    [SerializeField] bool _isFlying;
    [SerializeField] bool _isMelee;
    [SerializeField] string _entityName;
    [SerializeField] float _baseHealth;
    [SerializeField] float _baseDamage;
    [SerializeField] float _detectionRange = 7;

    AIDestinationSetter _aiDestinationSetter;
    AIPath _aiPath;
    float _currentHealth;
    readonly Timer _moveCooldown = new Timer(1.2f);

    protected bool shouldMove = true;

    void Awake()
    {
        // cache references
        _aiDestinationSetter = GetComponent<AIDestinationSetter>();
        _aiPath = GetComponent<AIPath>();
        
        // initialize entity stats
        _currentHealth = _baseDamage;
        
        // set ai props
        _aiDestinationSetter.target = _targetedPlayer;

        if(_isFlying) 
            _aiPath.pickNextWaypointDist = 5;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // check if enemy deals melee damage
        if(!_isMelee)
            return;

        // check for player collision
        var player = other.gameObject.GetComponent<Player>();

        if (player)
            PlayerHealthManager.ApplyDamage((int)_baseDamage);
        
        // apply cooldown for movement
        _moveCooldown.Reset();
    }

    void Update()
    {
        // handle timers
        _moveCooldown.HandleTimerScaled();
        
        UpdateLoop();
    }

    void FixedUpdate()
    {
        // check if player is near enough to follow him

        var isInDistance = Vector2.Distance(transform.position, _targetedPlayer.position) <= _detectionRange;

        _aiPath.canMove = isInDistance && shouldMove && _moveCooldown.IsDone();
        
        PhysicsUpdateLoop();
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        
        // check if entity should still be alive
        if (_currentHealth <= 0)
        {
            OnDeath();
            Destroy(gameObject);
        }
    }

    protected virtual void OnDeath() { }
    protected virtual void PhysicsUpdateLoop() {} // passing fixed update to subclasses
    protected virtual void UpdateLoop() {} // passing update to subclasses
}
