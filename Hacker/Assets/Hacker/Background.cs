using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {
	[SerializeField] public Transform Target;
	[SerializeField] public float Parallax = 0.1f;
	private Vector3 initial;
	private Vector3 targetInitial;

	void Start() {
		initial = transform.position;
		targetInitial = Target.position;
	}

	// Update is called once per frame
	void Update () {
		transform.position = initial + (Target.position - targetInitial) * Parallax;
	}
}