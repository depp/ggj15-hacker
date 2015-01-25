using UnityEngine;
using System.Collections;

public class Bob : MonoBehaviour {
	[SerializeField] public float BobHeight = 2.0f;
	[SerializeField] public float BobPeriod = 3.0f;
	[SerializeField] public float BobPhase = 0.0f;

	private Vector3 zeroPos;

	// Use this for initialization
	void Start () {
		zeroPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float bob = Mathf.Sin ((Time.time / BobPeriod + BobPhase) * (2.0f * Mathf.PI));
		transform.position = zeroPos + new Vector3(0.0f, bob * BobHeight, 0.0f);
	}
}
