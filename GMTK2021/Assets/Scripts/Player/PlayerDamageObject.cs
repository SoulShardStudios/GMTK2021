using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Collider2D))]
public class PlayerDamageObject : MonoBehaviour
{
    [SerializeField] int _damage;
    [SerializeField] float _destoryAfter;
    [SerializeField] bool _shouldDestory;
    void OnTriggerEnter2D(Collider2D collision)
    {
        Entity entity = collision.GetComponent<Entity>();
        if (entity)
            entity.TakeDamage(_damage);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_shouldDestory)
            Destroy(gameObject);
    }
    private void OnEnable()
    {
        if (_shouldDestory)
            StartCoroutine(DestroyThis());
    }
    IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(_destoryAfter);
        Destroy(gameObject);
    }
}