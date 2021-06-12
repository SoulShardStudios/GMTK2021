using Pathfinding;
using UnityEngine;

[RequireComponent(typeof(AIDestinationSetter))]
[RequireComponent(typeof(AIPath))]
public abstract class Entity : MonoBehaviour
{
    [SerializeField] Transform _targetedPlayer;
    [SerializeField] bool _isFlying;
    [SerializeField] bool _isMelee;
    [SerializeField] string _entityName;
    [SerializeField] float _baseHealth;
    [SerializeField] float _baseDamage;
    [SerializeField] float _detectionRange = 7;

    AIDestinationSetter _aiDestinationSetter;
    AIPath _aiPath;
    float _currentHealth;

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
            _aiPath.pickNextWaypointDist = 1;
    }

    void FixedUpdate()
    {
        // check if player is near enough to follow him
        _aiPath.canMove = Vector2.Distance(transform.position, _targetedPlayer.position) <= _detectionRange;
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

    protected void OnDeath() { }
}
