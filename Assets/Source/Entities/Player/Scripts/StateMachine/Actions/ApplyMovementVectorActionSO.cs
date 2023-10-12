using Source.Core.StateMachine;
using Source.Core.StateMachine.ScriptableObjects;
using UnityEngine;

[CreateAssetMenu(fileName = "ApplyMovementVector", menuName = "State Machines/Actions/Player/Apply Movement Vector")]
public class ApplyMovementVectorActionSO : StateActionSO<ApplyMovementVectorAction> { }

public class ApplyMovementVectorAction : StateAction
{
	//Component references
	private PlayerController _protagonistScript;
	private CharacterController _characterController;

	public override void Awake(StateMachine stateMachine)
	{
		_protagonistScript = stateMachine.GetComponent<PlayerController>();
		_characterController = stateMachine.GetComponent<CharacterController>();
	}

	public override void OnUpdate()
	{
		_characterController.Move(_protagonistScript.MovementVector * Time.deltaTime);
		_protagonistScript.MovementVector = _characterController.velocity;
	}
}
