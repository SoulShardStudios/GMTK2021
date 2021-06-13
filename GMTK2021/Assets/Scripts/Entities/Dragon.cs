using UnityEngine;

public class Dragon : Entity
{
    [SerializeField] Rigidbody2D _projectile;
    readonly Timer _shootTimer = new Timer(3f, true);
    void Start()
    {
        // sub to timer actions
        _shootTimer.OnDone += () => Shoot(_projectile, 1.5f);
        _shootTimer.Reset();
    }

    protected override void UpdateLoop()
    {
        // handle timers
        _shootTimer.HandleTimerScaled();
    }
}