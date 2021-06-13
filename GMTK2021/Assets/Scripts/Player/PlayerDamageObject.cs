using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class PlayerDamageObject : MonoBehaviour
{
    [SerializeField] int _damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Entity entity = collision.GetComponent<Entity>();
        if (entity)
            entity.TakeDamage(_damage);
    }
}