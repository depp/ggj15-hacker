using UnityEngine;
using System.Collections;
using UnitySampleAssets._2D;

public class Teleporter : Interactive {
	[SerializeField] public Transform Target;
	[SerializeField] public float SwirlSpeed = 2.0f;
	[SerializeField] public float FadeTime = 0.2f;
	[SerializeField] public Color FadeColor = Color.cyan;

	private Transform swirl;

	// Use this for initialization
	void Start () {
		if (Target == null)
			Debug.LogError ("Teleporter has no target.");
		swirl = transform.Find ("Swirl");
		if (swirl == null)
			Debug.LogError ("Teleporter is missing swirl");
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();
		float angle = Time.time * SwirlSpeed * 360.0f;
		swirl.localRotation = Quaternion.AngleAxis (angle, Vector3.forward);
	}

	private void Execute(GameObject player) {
		if (Target == null)
			return;
		Vector3 newPosition = Target.position;
		BoxCollider2D box = Target.GetComponent<BoxCollider2D> ();
		if (box != null)
			newPosition = Target.transform.TransformPoint(box.center);
		player.transform.position = newPosition;
	}

	protected override void Interact(Platformer2DUserControl player) {
		Fade.RunAction (FadeColor, FadeTime, this.Execute, player.gameObject);
	}
}
