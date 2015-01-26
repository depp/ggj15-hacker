using UnityEngine;
using System.Collections;

public enum Direction {
	Left, Right, Up, Down
}

public class Bob : MonoBehaviour {
	[SerializeField] public float BobHeight = 2.0f;
	[SerializeField] public float BobPeriod = 3.0f;
	[SerializeField] public float BobPhase = 0.0f;
	[SerializeField] public Direction BobDirection = Direction.Up;

	private Vector3 zeroPos;

	// Use this for initialization
	void Start () {
		zeroPos = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		float bob = Mathf.Sin ((Time.time / BobPeriod + BobPhase) * (2.0f * Mathf.PI));
		float distance = (bob + 1.0f) * BobHeight * 0.5f;
		Vector3 direction = Vector3.zero;
		switch (BobDirection) {
		case Direction.Left:  direction = new Vector3(-1.0f,  0.0f, 0.0f); break;
		case Direction.Right: direction = new Vector3(+1.0f,  0.0f, 0.0f); break;
		case Direction.Up:    direction = new Vector3( 0.0f, +1.0f, 0.0f); break;
		case Direction.Down:  direction = new Vector3( 0.0f, -1.0f, 0.0f); break;
		}
		transform.localPosition = zeroPos + distance * direction;
	}
}
