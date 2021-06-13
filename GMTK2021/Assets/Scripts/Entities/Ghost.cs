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
        _shootTimer.OnDone += Shoot;
        _shootTimer.Reset();
    }

    void Shoot()
    {
        // instantiate the projectile
        var projectile = Instantiate(_projectile, transform.position, Quaternion.identity);
        Destroy(projectile.gameObject, 5f);
        
        var direction = (_targetedPlayer.position - transform.position).normalized * 1.3f;
        
        projectile.AddForce(direction, ForceMode2D.Impulse);
    }

    protected override void UpdateLoop()
    {
        // handle timers
        _shootTimer.HandleTimerScaled();
        Debug.Log(_shootTimer.CurrentCooldown);
    }
}