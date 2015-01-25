using UnityEngine;
using System.Collections;
using UnitySampleAssets._2D;

public class Door : Interactive {
	[SerializeField] public bool IsLocked = true;
	[SerializeField] public string Destination;
	[SerializeField] public Color FadeColor = Color.black;

	private void Execute(GameObject player) {
		Application.LoadLevel (Destination);
	}

	protected override bool IsPermitted(Platformer2DUserControl player) {
		return !IsLocked || player.HasKey;
	}

	protected override void Interact(Platformer2DUserControl player) {
		Fade.RunAction(FadeColor, AudioSucceed.length, this.Execute, player.gameObject);
	}
}
