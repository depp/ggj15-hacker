using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	[SerializeField] public bool IsLocked = true;
	[SerializeField] public string Destination;
	[SerializeField] public float FadeTime = 0.5f;
	[SerializeField] public Color FadeColor = Color.black;

	public void Interact(GameObject player) {
		Fade.RunAction(FadeColor, FadeTime, this.Execute, player);
	}

	private void Execute(GameObject player) {
		Application.LoadLevel (Destination);
	}
}
