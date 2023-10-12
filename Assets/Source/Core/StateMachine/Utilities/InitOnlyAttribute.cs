using System;
using UnityEngine;

namespace Source.Core.StateMachine
{
	[AttributeUsage(AttributeTargets.Field)]
	public class InitOnlyAttribute : PropertyAttribute { }
}
