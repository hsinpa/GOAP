using UnityEngine;
using System.Collections;

namespace AI {
	public interface State {
		void execute();
		void enter(AIAgent target);
		void exit();
	}
}