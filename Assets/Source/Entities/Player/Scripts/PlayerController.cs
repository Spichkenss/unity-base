using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private Transform _gameplayCameraTransform;

    [NonSerialized] public Vector3 MovementInput;
    [NonSerialized] public Vector3 MovementVector;
    
    public bool IsRunHolding { get; private set; }
    public bool IsJumpPressed { get; private set; }
    public bool IsAttackPressed { get; private set; }
    
    private Vector2 _inputVector;
    private float _previousSpeed;

    private void OnEnable()
    {
        _inputHandler.MoveEvent += OnMove;
    }

    private void OnDisable()
    {
        _inputHandler.MoveEvent -= OnMove;
    }

    private void OnMove(Vector2 inputVector)
    {
        _inputVector = inputVector;
    }

    private void Update()
    {
        RecalculateMovement();
    }

    private void RecalculateMovement()
    {
        var cameraForward = _gameplayCameraTransform.forward;
        cameraForward.y = 0f;
        var cameraRight = _gameplayCameraTransform.right;
        cameraRight.y = 0f;
        
        var adjustedMovement = cameraRight.normalized * _inputVector.x + cameraForward.normalized * _inputVector.y;

        MovementInput = adjustedMovement.normalized;
    }
}