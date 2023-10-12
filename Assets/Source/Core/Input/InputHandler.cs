using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputHandler", menuName = "Input/Input Handler")]
public class InputHandler : ScriptableObject, InputActions.IGameplayActions
{
    public event UnityAction<Vector2> MoveEvent = delegate { };
    
    private InputActions _playerInput;
    
    private void OnEnable()
    {
        if (_playerInput == null)
        {
            _playerInput = new InputActions();
            _playerInput.Gameplay.SetCallbacks(this);
        }
        
        _playerInput.Gameplay.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Gameplay.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveEvent.Invoke(context.ReadValue<Vector2>());
    }
}
