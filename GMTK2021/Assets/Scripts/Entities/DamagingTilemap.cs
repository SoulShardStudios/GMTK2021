using UnityEngine;
public class DamagingTilemap : MonoBehaviour
{
    [SerializeField] int _damage;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerA") || collision.CompareTag("PlayerB"))
            PlayerHealthManager.ApplyDamage(_damage);
    }
}