using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
public class GameUIControler : MonoBehaviour
{
    [SerializeField] UIButton _exit, _continue;
    [SerializeField] Image _hpBar;
    [SerializeField] Image _playerAKey, _playerBKey;
    [SerializeField] string _title;
    [SerializeField] GameObject _pause;
    [HideInInspector] public bool isPaused { get; private set; }
    [HideInInspector] public static GameUIControler S { get; private set; }

    [SerializeField] InputAction _input;
    private void OnEnable()
    {
        _input.Enable();
        _input.performed += TogglePause;
        isPaused = false;
        Time.timeScale = 1;
        _pause.SetActive(false);
        S = this;
        _exit.clickCallback += ExitGame;
        _continue.clickCallback += TogglePause;
    }
    private void OnDisable()
    {
        _input.Disable();
        _exit.clickCallback -= ExitGame;
        _continue.clickCallback -= TogglePause;
    }
    public void UpdateHPUI(float fillamount) => _hpBar.fillAmount = fillamount;
    private void ExitGame(PointerEventData eventData)
    {
        isPaused = false;
        SceneManager.LoadScene(_title, LoadSceneMode.Single);
    }
    public void TogglePause(InputAction.CallbackContext context) => TogglePause();
    public void TogglePause(PointerEventData eventData) => TogglePause();
    private void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        _pause.SetActive(isPaused);
    }
    public void TogglePlayerKey(bool toggle, string PlayerID) => (PlayerID == "PlayerA" ? _playerAKey : _playerBKey).gameObject.SetActive(toggle);
}