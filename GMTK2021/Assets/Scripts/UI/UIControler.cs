using UnityEngine;
using UnityEngine.UI;
public class UIControler : MonoBehaviour
{
    [SerializeField] Image _hpBar;
    [HideInInspector] public static UIControler S { get; private set; }
    private void OnEnable() => S = this;
    public void UpdateHPUI(float fillamount) => _hpBar.fillAmount = fillamount;
}