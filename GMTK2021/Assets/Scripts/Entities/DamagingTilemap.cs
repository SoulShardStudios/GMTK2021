using UnityEngine;
public class DamagingTilemap : MonoBehaviour
{
    [SerializeField] int _damage;
    bool _isCollidingWithPlayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerA") || collision.CompareTag("PlayerB"))
            _isCollidingWithPlayer = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerA") || collision.CompareTag("PlayerB"))
            _isCollidingWithPlayer = false;
    }
    private void Update()
    {
        if (_isCollidingWithPlayer)
            PlayerHealthManager.ApplyDamage(_damage);
    }
}