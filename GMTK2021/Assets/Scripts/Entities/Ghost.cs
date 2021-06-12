using UnityEngine;

public class Ghost : Entity
{
    [SerializeField] LayerMask _obstacleLayer;
    protected override void PhysicsUpdate()
    {
        var distance = Vector2.Distance(transform.position, _targetedPlayer.position);
        Debug.Log(distance);
        
        var ray = Physics2D.Raycast(
            transform.position, 
            _targetedPlayer.position - transform.position, 
            distance, 
            _obstacleLayer);

        shouldMove = ray.collider != null || (distance > .7f);
    }
}