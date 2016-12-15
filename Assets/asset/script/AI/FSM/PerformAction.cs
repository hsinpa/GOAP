using UnityEngine;
using System.Collections;

using UnityEngine;
using System.Collections;

namespace AI {
	public class PerformAction : State {
		AIAgent mSelf;
			
		public void enter (AIAgent p_self) {
			mSelf = p_self;
		}

		public void execute () {

			if (!mSelf.hasActionPlan()) {
				// no actions to perform
				Debug.Log("<color=red>Done actions</color>");
				mSelf.ChangeState( new Idle() );
				return;
			}

			GoapAction action = mSelf.currentActions.Peek();
			if ( action.isDone() ) {
				// the action is done. Remove it so we can perform the next one
				mSelf.currentActions.Dequeue();
			}

			if (mSelf.hasActionPlan()) {
				// perform the next action
				action = mSelf.currentActions.Peek();
				bool inRange = action.requiresInRange() ? action.isInRange() : true;

				if ( inRange ) {
					// we are in range, so perform the action
					bool success = action.perform(mSelf.gameObject);

					if (!success) {
						// action failed, we need to plan again
						mSelf.ChangeState(new Idle());
						mSelf.dataProvider.planAborted(action);
					}
				} else {
					// we need to move there first
					// push moveTo state

					Debug.Log("Move Action");
				}
			} else {
				// no actions left, move to Plan state
				mSelf.ChangeState(new Idle());
				mSelf.dataProvider.actionsFinished();
			}

		}
		
		public void exit () {
			
		}
	}
}
