using Source.Core.StateMachine;
using Source.Core.StateMachine.ScriptableObjects;
using UnityEngine;

[CreateAssetMenu(fileName = "IsMoving", menuName = "State Machines/Conditions/Is Moving")]
public class IsMovingConditionSO : StateConditionSO<IsMovingCondition>
{
	public float treshold = 0.02f;
}

public class IsMovingCondition : Condition
{
	protected new IsMovingConditionSO OriginSO => (IsMovingConditionSO)base.OriginSO;
	private PlayerController _playerController;

	public override void Awake(StateMachine stateMachine)
	{
		_playerController = stateMachine.GetComponent<PlayerController>();
	}
	
	protected override bool Statement()
	{
		Vector3 movementVector = _playerController.MovementInput;
		movementVector.y = 0f;
		return movementVector.magnitude > OriginSO.treshold;
	}
}
