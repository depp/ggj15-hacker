using UnityEngine;
using System.Collections;
using UnitySampleAssets._2D;

public class Key : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		Platformer2DUserControl p = other.GetComponent<Platformer2DUserControl>();
		if (p == null || p.HasKey)
			return;
		Destroy (GetComponent<Collider2D>());
		transform.parent = other.gameObject.transform;
		transform.localPosition = new Vector3(-0.5f, 0.5f, 0.0f);
		p.HasKey = true;
	}
}
