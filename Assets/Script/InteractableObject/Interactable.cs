using UnityEngine;
using System.Collections;


namespace InteractableObject {
	public class Interactable : MonoBehaviour {
		NavMeshAgent playerAgent;

		public virtual void MoveToInteraction(NavMeshAgent p_agent) {
			this.playerAgent = p_agent;
			playerAgent.stoppingDistance = 2.1f;
			playerAgent.destination = transform.position;
			Interact();
		} 

		public virtual void Interact() { 
			Debug.Log( "Base interaction" );
		}

	}
}