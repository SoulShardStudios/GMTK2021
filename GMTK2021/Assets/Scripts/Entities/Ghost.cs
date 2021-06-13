using UnityEngine;

public class Ghost : Entity
{
    [SerializeField] LayerMask _obstacleLayer;
    [SerializeField] Rigidbody2D _projectile;
    readonly Timer _shootTimer = new Timer(2f, true);
    protected override void PhysicsUpdateLoop()
    {
        var distance = Vector2.Distance(transform.position, _targetedPlayer.position);
        
        var ray = Physics2D.Raycast(
            transform.position, 
            _targetedPlayer.position - transform.position, 
            distance, 
            _obstacleLayer);

        shouldMove = ray.collider || (distance > .7f);
    }

    void Start()
    {
        // sub to timer actions
        _shootTimer.OnDone += () => Shoot(_projectile, 1.3f);
        _shootTimer.Reset();
    }

    protected override void UpdateLoop()
    {
        // handle timers
        _shootTimer.HandleTimerScaled();
    }
}