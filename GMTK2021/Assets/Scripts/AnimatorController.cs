using UnityEngine;
[RequireComponent(typeof(Animator))]
public class AnimatorController : MonoBehaviour
{
    protected Animator _animator;
    string _currentState;
    protected void ChangeAnimState(string state)
    {
        if (_currentState == state)
            return;
        _animator.Play(state);
        _currentState = state;
    }
}