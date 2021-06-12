using UnityEngine;
using UnityEngine.SceneManagement;
// loads the UI scene if its not already loaded
public class GameManager : MonoBehaviour
{
    [SerializeField] string UI;
    void OnEnable()
    {
        if (!SceneManager.GetSceneByName(UI).isLoaded)
            SceneManager.LoadScene(UI, LoadSceneMode.Additive);
        PlayerHealthManager.Init();
    }
    void Update() => PlayerHealthManager.damageCooldown.HandleTimerScaled();
}