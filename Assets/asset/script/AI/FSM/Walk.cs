using UnityEngine;
using System.Collections;

namespace AI {
	public class Walk : State {
		AIAgent mSelf;
		Transform mTarget;

		public void enter (AIAgent p_self) {
			mSelf = p_self;
		}

		public void execute () {
			float distance = Vector3.Distance(mTarget.position, mSelf.transform.position);

			if ( distance > 1) {
				Vector3 moveDir = mSelf.transform.forward * mSelf.speed;
				mSelf.transform.Translate(moveDir * Time.deltaTime);

			} else {
				
			}
		}
		
		public void exit () {
			
		}
	}
}
