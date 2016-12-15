using UnityEngine;
using System.Collections;

public class WorldInteraction : MonoBehaviour {
	NavMeshAgent playerAgent;

	void Start() {
		playerAgent = GetComponent<NavMeshAgent>();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) {

			GetInteraction();

		}
	}

	void GetInteraction() {
		Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit interactionInfo;
		if (Physics.Raycast(interactionRay, out interactionInfo)) {
			GameObject interactiveObject = interactionInfo.collider.gameObject;
			if (interactiveObject.tag == "Interactable Object") {
				interactiveObject.GetComponent<InteractableObject.Interactable>().MoveToInteraction( playerAgent );
			} else {
				playerAgent.stoppingDistance = 0;
				playerAgent.destination = interactionInfo.point;
			}
		} 
	}
}
