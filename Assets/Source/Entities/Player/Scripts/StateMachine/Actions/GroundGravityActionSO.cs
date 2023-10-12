using Source.Core.StateMachine;
using Source.Core.StateMachine.ScriptableObjects;
using UnityEngine;

[CreateAssetMenu(fileName = "GroundGravity", menuName = "State Machines/Actions/Player/Ground Gravity")]
public class GroundGravityActionSO : StateActionSO<GroundGravityAction>
{
	[Tooltip("Vertical movement pulling down the player to keep it anchored to the ground.")]
	public float verticalPull = -5f;
}

public class GroundGravityAction : StateAction
{
	//Component references
	private PlayerController _protagonistScript;

	private GroundGravityActionSO _originSO => (GroundGravityActionSO)base.OriginSO; // The SO this StateAction spawned from

	public override void Awake(StateMachine stateMachine)
	{
		_protagonistScript = stateMachine.GetComponent<PlayerController>();
	}

	public override void OnUpdate()
	{
		_protagonistScript.MovementVector.y = _originSO.verticalPull;
	}
}
