using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	[SerializeField] public bool IsLocked = true;
	[SerializeField] public string Destination;

	public void Interact(GameObject player) {
		Fade.GoToLevel(Color.black, Destination);
	}
}
