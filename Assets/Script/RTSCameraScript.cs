using UnityEngine;
using System.Collections;

public class RTSCameraScript : MonoBehaviour {
	public GameObject target;
	public int distance = 20,
				speed = 10;

	public void Update() {
		Vector3 newCameraPosition = new Vector3(target.transform.position.x , transform.position.y, target.transform.position.z);
		newCameraPosition -= (-Vector3.forward) * distance;

		transform.position = Vector3.Lerp(transform.position, newCameraPosition, speed * Time.deltaTime);

		transform.LookAt(target.transform.position);
	}

}
