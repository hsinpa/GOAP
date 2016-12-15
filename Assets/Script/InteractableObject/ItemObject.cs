using UnityEngine;
using System.Collections;

namespace InteractableObject {
	public class ItemObject : Interactable {

		public override void Interact ()
		{
			Debug.Log("Item Interaction ");
	//		base.Interact ();
		}
	}
}