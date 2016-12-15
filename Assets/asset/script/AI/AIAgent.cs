using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AI {
	public class AIAgent : MonoBehaviour {
		public HashSet<GoapAction> availableActions;
		public Queue<GoapAction> currentActions;
		public IGoap dataProvider; // this is the implementing class that provides our world data and listens to feedback on planning
		public GoapPlanner planner;

		public State currentState;

		public int speed;

		void Start () {
			availableActions = new HashSet<GoapAction> ();
			currentActions = new Queue<GoapAction> ();
			planner = new GoapPlanner ();

			findDataProvider();
			LoadActions();
//			HashSet<KeyValuePair<string,object>> worldState = dataProvider.getWorldState();
//			HashSet<KeyValuePair<string,object>> goal = dataProvider.createGoalState();
//
//			Queue<GoapAction> plan = planner.plan(gameObject, availableActions, worldState, goal);

			ChangeState(new Idle());
		}

		private void Update() {
			currentState.execute();
		}

		public void addAction(GoapAction a) {
			availableActions.Add (a);
		}

		public GoapAction getAction(System.Type action) {
			foreach (GoapAction g in availableActions) {
				if (g.GetType().Equals(action) )
				    return g;
			}
			return null;
		}

		public void removeAction(GoapAction action) {
			availableActions.Remove (action);
		}

		public bool hasActionPlan() {
			return currentActions.Count > 0;
		}

		private void findDataProvider() {
			foreach (Component comp in gameObject.GetComponents(typeof(Component)) ) {
				if ( typeof(IGoap).IsAssignableFrom(comp.GetType()) ) {
					dataProvider = (IGoap)comp;
					return;
				}
			}
		}

		public void ChangeState(State newState) {
			if (currentState != null) currentState.exit();
			currentState = newState;
			currentState.enter(this);
		}

		private void LoadActions () {
		GoapAction[] actions = gameObject.GetComponents<GoapAction>();
		foreach (GoapAction a in actions) {
				availableActions.Add (a);
			}
		}

	}
}