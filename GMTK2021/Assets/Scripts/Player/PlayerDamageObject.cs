using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class PlayerDamageObject : MonoBehaviour
{
    [SerializeField] int _damage;
    [SerializeField] float _destoryAfter;
    Timer _deathTimer = new Timer(0);
    void OnTriggerEnter2D(Collider2D collision)
    {
        Entity entity = collision.GetComponent<Entity>();
        if (entity)
            entity.TakeDamage(_damage);
    }
    void OnEnable()
    {
        _deathTimer = new Timer(_destoryAfter);
        _deathTimer.OnDone += DestoryThis;
    }
    private void OnDisable() => _deathTimer.OnDone -= DestoryThis;
    void Update() => _deathTimer.HandleTimerScaled();
    void DestoryThis() => Destroy(gameObject);
}