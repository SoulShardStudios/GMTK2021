using UnityEngine;
[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerAnimator))]
public class PlayerBProjectiles : MonoBehaviour
{
    [SerializeField] GameObject _projectile;
    [SerializeField] GameObject[] exitPoints;
    [SerializeField] float _speed;
    // UDLR
    PlayerAnimator _player;
    private void OnEnable() => _player = GetComponent<PlayerAnimator>();
    public void FireProjectile()
    {
        Vector2Int dir = RoundVector2(_player._cachedDirection);
        if (dir.x != 0 && dir.y != 0)
            dir.x = 0;
        Vector3 spawnPos = exitPoints[GetExitPoint(dir)].transform.position;
        GameObject G = Instantiate(_projectile, spawnPos, Quaternion.identity, null);
        G.GetComponent<Rigidbody2D>().AddForce((Vector2)dir * _speed);
    }
    int GetExitPoint(Vector2Int Direction)
    {
        if (Direction == Vector2Int.down)
            return 0;
        if (Direction == Vector2Int.down)
            return 1;
        if (Direction == Vector2Int.left)
            return 2;
        if (Direction == Vector2Int.right)
            return 3;
        return -1;
    }
    private Vector2Int RoundVector2(Vector2 ToRound)
    {
        int x = Mathf.RoundToInt(ToRound.x);
        int y = Mathf.RoundToInt(ToRound.y);
        return new Vector2Int(x, y);
    }
}