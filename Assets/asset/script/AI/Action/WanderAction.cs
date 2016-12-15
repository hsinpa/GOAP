using UnityEngine;
using System.Collections;

public class WanderAction : GoapAction {
	public float maxVelocity = 5;
	public GameObject targetTree; // where we get the logs from

	public WanderAction() {
		addPrecondition ("hasMana", true); // can't drop off firewood if we don't already have some
		addEffect ("findPlayer", true); // we collected firewood
	}
	
	#region implemented abstract members of GoapAction

	public override void reset ()
	{
	}

	public override bool isDone ()
	{
		return false;
		}

	public override bool checkProceduralPrecondition (GameObject agent)
	{
		target = targetTree;
		return true;

	}

	public override bool perform (GameObject agent)	{
		Debug.Log("Wander go");
		Debug.Log(target.name);
		float distance = Vector3.Distance(target.transform.position, agent.transform.position);
		AI.AIAgent aiAgent = agent.GetComponent<AI.AIAgent>();
			if ( distance > 1f) {
			Vector3 lookAtDir = Vector3.Normalize( target.transform.position - agent.transform.position);

			var angle = Mathf.Atan2(lookAtDir.y, lookAtDir.x) * Mathf.Rad2Deg;
				transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

//				Vector3 moveDir = lookAtDir * maxVelocity;
//				aiAgent.transform.LookAt( target.transform );
				aiAgent.transform.Translate( (Vector2.right ) *  maxVelocity * Time.deltaTime);
			}
		return true;
	}

	public override bool requiresInRange ()
	{
		return false;

	}

	#endregion
}
