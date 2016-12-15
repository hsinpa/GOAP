using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AI {
	public class TestUnit : Unit {

		public override HashSet<KeyValuePair<string,object>> createGoalState () {
			HashSet<KeyValuePair<string,object>> goal = new HashSet<KeyValuePair<string,object>> ();
			goal.Add(new KeyValuePair<string, object>("findPlayer", true ));
			return goal;
		}

	}
}