using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class TitleUIControler : MonoBehaviour
{
    [SerializeField] UIButton _play, _exit;
    [SerializeField] string _level1;
    void OnEnable()
    {
        _play.clickCallback += Play;
        _exit.clickCallback += Exit;
    }
    void OnDisable()
    {
        _play.clickCallback -= Play;
        _exit.clickCallback -= Exit;
    }
    void Play(PointerEventData eventData) => SceneManager.LoadScene(_level1, LoadSceneMode.Single);
    void Exit(PointerEventData eventData) => Application.Quit();
}