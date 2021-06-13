using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] int _baseDamage;
    [SerializeField] bool _destroyOnCollision = true;
    void OnTriggerEnter2D(Collider2D other)
    {
        // check for player collision
        var player = other.gameObject.GetComponent<Player>();

        if (player)
        {
            PlayerHealthManager.ApplyDamage(_baseDamage);
            
            if(_destroyOnCollision)
                Destroy(gameObject);
        }
    }
}
