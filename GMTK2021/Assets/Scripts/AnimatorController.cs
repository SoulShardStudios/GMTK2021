using UnityEngine;
public class AnimatorController : MonoBehaviour
{
    [SerializeField] protected Animator _animator;
    string _currentState;
    protected void ChangeAnimState(string state)
    {
        if (_currentState == state)
            return;
        _animator.Play(state);
        _currentState = state;
    }
}