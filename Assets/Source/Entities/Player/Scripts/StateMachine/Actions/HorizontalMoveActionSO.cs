using Source.Core.StateMachine;
using Source.Core.StateMachine.ScriptableObjects;
using UnityEngine;

[CreateAssetMenu(fileName = "HorizontalMove", menuName = "State Machines/Actions/Player/Horizontal Move")]
public class HorizontalMoveActionSO : StateActionSO<HorizontalMoveAction>
{
	[Tooltip("Horizontal XZ plane speed multiplier")]
	public float speed = 8f;
}

public class HorizontalMoveAction : StateAction
{
	//Component references
	private PlayerController _protagonistScript;
	private HorizontalMoveActionSO _originSO => (HorizontalMoveActionSO)base.OriginSO; // The SO this StateAction spawned from

	public override void Awake(StateMachine stateMachine)
	{
		_protagonistScript = stateMachine.GetComponent<PlayerController>();
	}

	public override void OnUpdate()
	{
		//delta.Time is used when the movement is applied (ApplyMovementVectorAction)
		_protagonistScript.MovementVector.x = _protagonistScript.MovementInput.x * _originSO.speed;
		_protagonistScript.MovementVector.z = _protagonistScript.MovementInput.z * _originSO.speed;
	}
}
