using UnityEngine;

public class Spider : Entity
{
    [SerializeField] Rigidbody2D _projectile;
    readonly Timer _shootTimer = new Timer(2.8f, true);
    void Start()
    {
        // sub to timer actions
        _shootTimer.OnDone += () => Shoot(_projectile, 1.8f);
        _shootTimer.Reset();
    }

    protected override void UpdateLoop()
    {
        // handle timers
        _shootTimer.HandleTimerScaled();
    }
}