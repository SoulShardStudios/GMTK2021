using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
public class GameUIControler : MonoBehaviour
{
    #region Vars
    [SerializeField] UIButton _pauseExit, _unpause, _gameOverExit, _retry, _retry2;
    [SerializeField] Image _hpBar;
    [SerializeField] Image _playerAKey, _playerBKey;
    [SerializeField] string _title;
    [SerializeField] GameObject _pause, _gameOver;
    [SerializeField] InputAction _input;
    [HideInInspector] public bool isPaused { get; private set; }
    [HideInInspector] public static GameUIControler S { get; private set; }
    #endregion
    #region Init Methods
    private void OnEnable()
    {
        S = this;
        //input management
        _input.Enable();
        _input.performed += TogglePause;
        //pause stuff
        isPaused = false;
        Time.timeScale = 1;
        _pause.SetActive(false);
        _pauseExit.clickCallback += ExitGame;
        _unpause.clickCallback += TogglePause;
        //game over setup
        _gameOver.SetActive(false);
        _gameOverExit.clickCallback += ExitGame;
        _retry.clickCallback += RetryLevel;
        _retry2.clickCallback += RetryLevel;
    }
    private void OnDisable()
    {
        _input.Disable();
        _pauseExit.clickCallback -= ExitGame;
        _unpause.clickCallback -= TogglePause;
        _gameOverExit.clickCallback -= ExitGame;
        _retry.clickCallback -= RetryLevel;
        _retry2.clickCallback -= RetryLevel;
    }
    #endregion
    #region Pause Funcs
    public void TogglePause(InputAction.CallbackContext context) => TogglePause();
    public void TogglePause(PointerEventData eventData) => TogglePause();
    private void TogglePause()
    {
        AudioManager.S.PlaySound("pause");
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        _pause.SetActive(isPaused);
    }
    #endregion
    #region UI State Funcs
    public void TogglePlayerKeyDisplay(bool toggle, string PlayerID) => (PlayerID == "PlayerA" ? _playerAKey : _playerBKey).gameObject.SetActive(toggle);
    public void UpdateHPUI(float fillamount) => _hpBar.fillAmount = fillamount;
    #endregion
    #region Game State Funcs
    private void ExitGame(PointerEventData eventData)
    {
        isPaused = false;
        SceneManager.LoadScene(_title, LoadSceneMode.Single);
    }
    #endregion
    #region Death UI Funcs
    void RetryLevel(PointerEventData eventData) => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    public void EnableDeathUI()
    {
        isPaused = true;
        _gameOver.SetActive(true);
    }
    #endregion
}