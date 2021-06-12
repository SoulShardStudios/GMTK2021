using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PauseUIControler : MonoBehaviour
{
    [SerializeField] UIButton _exit, _continue;
    [SerializeField] Image _hpBar;
    [SerializeField] string _title;
    [SerializeField] GameObject _pause;
    [HideInInspector] public bool isPaused { get; private set; }
    [HideInInspector] public static PauseUIControler S { get; private set; }

    [SerializeField] InputAction _input;
    private void OnEnable()
    {
        _input.Enable();
        _input.performed += TogglePause;
        isPaused = false;
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
        SceneManager.LoadScene(_title, LoadSceneMode.Single);
    }
    public void TogglePause(InputAction.CallbackContext context) => TogglePause();
    public void TogglePause(PointerEventData eventData) => TogglePause();
    public void TogglePause()
    {
        isPaused = !isPaused;
        _pause.SetActive(isPaused);
    }
}