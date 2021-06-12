using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Door : MonoBehaviour
{
    [SerializeField] Sprite _closed, _open;
    [SerializeField] bool _startClosed;
    [HideInInspector] public bool playerIsOverDoor, isClosed;
    [SerializeField] string _playerID;
    SpriteRenderer _renderer;
    private void OnEnable()
    {
        _renderer = GetComponent<SpriteRenderer>();
        isClosed = _startClosed;
        _renderer.sprite = _startClosed ? _closed : _open;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_playerID))
        {
            Debug.Log(isClosed && collision.GetComponent<Player>().hasKey);
            if (isClosed && collision.GetComponent<Player>().hasKey)
            {
                _renderer.sprite = _open;
                isClosed = false;
            }
            playerIsOverDoor = true;
            _renderer.color = Color.green;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(_playerID))
        {
            playerIsOverDoor = false;
            _renderer.color = Color.white;
        }
            
    }
}