using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		Player p = other.GetComponent<Player>();
		if (p == null || p.hasKey)
			return;
		Destroy (GetComponent<Collider2D>());
		transform.parent = other.gameObject.transform;
		transform.localPosition = new Vector3(-0.5f, 0.5f, 0.0f);
		p.hasKey = true;
	}
}
