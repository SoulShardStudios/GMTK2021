using UnityEngine;
using UnityEngine.SceneManagement;
// loads the UI scene if its not already loaded
public class UILoader : MonoBehaviour
{
    [SerializeField] string UI;
    private void OnEnable()
    {
        if (!SceneManager.GetSceneByName(UI).isLoaded)
            SceneManager.LoadScene(UI, LoadSceneMode.Additive);
    }

}