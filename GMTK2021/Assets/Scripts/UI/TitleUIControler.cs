using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class TitleUIControler : MonoBehaviour
{
    [SerializeField] UIButton _play;
    [SerializeField] string _level1;
    private void OnEnable()
    {
        _play.clickCallback += Play;
    }
    private void OnDisable()
    {
        _play.clickCallback -= Play;
    }
    private void Play(PointerEventData eventData)
    {
        SceneManager.LoadScene(_level1, LoadSceneMode.Single);
    }
}