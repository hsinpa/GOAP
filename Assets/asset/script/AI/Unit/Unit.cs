using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AI {
	public abstract class Unit : MonoBehaviour, IGoap {

		public HashSet<KeyValuePair<string,object>> getWorldState () {
			HashSet<KeyValuePair<string,object>> worldData = new HashSet<KeyValuePair<string,object>> ();

			worldData.Add(new KeyValuePair<string, object>("hasMana", true ));

			return worldData;
		}

		public abstract HashSet<KeyValuePair<string,object>> createGoalState ();


		public void planFailed (HashSet<KeyValuePair<string, object>> failedGoal)
		{
			throw new System.NotImplementedException ();
		}
		public void planFound (HashSet<KeyValuePair<string, object>> goal, Queue<GoapAction> actions)
		{
			throw new System.NotImplementedException ();
		}
		public void actionsFinished ()
		{
			Debug.Log("Action Done");
		}
		public void planAborted (GoapAction aborter)
		{
			throw new System.NotImplementedException ();
		}
		public bool moveAgent (GoapAction nextAction)
		{
			throw new System.NotImplementedException ();
		}
	}
}