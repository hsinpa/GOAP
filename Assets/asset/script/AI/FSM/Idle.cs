using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AI {
	public class Idle : State {
		AIAgent mSelf;
			
		public void enter (AIAgent p_self) {
			mSelf = p_self;
		}

		public void execute () {
			
			HashSet<KeyValuePair<string,object>> worldState = mSelf.dataProvider.getWorldState();
			HashSet<KeyValuePair<string,object>> goal = mSelf.dataProvider.createGoalState();

			// Plan
			Queue<GoapAction> plan = mSelf.planner.plan(mSelf.gameObject,	mSelf.availableActions, worldState, goal);
			if (plan != null) {
				// we have a plan, hooray!
				mSelf.currentActions = plan;
				//mSelf.dataProvider.planFound(goal, plan);
				mSelf.ChangeState(new PerformAction());
			} else {
				// ugh, we couldn't get a plan
				Debug.Log("<color=orange>Failed Plan:</color>"+(goal));
				mSelf.dataProvider.planFailed(goal);
			}
			
		}
		
		public void exit () {
			
		}
	}
}
