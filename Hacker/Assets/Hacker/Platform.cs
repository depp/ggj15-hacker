using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {
	void Awake () {
		SpriteRenderer sprite = GetComponent<SpriteRenderer>();
		Vector2 ssize = sprite.bounds.size;
		Vector2 sscale = transform.localScale;
		ssize.x /= sscale.x;
		ssize.y /= sscale.y;
		GameObject prefab = new GameObject();
		SpriteRenderer csprite = prefab.AddComponent<SpriteRenderer>();
		csprite.sprite = sprite.sprite;

		GameObject child;
		int w = (int)Mathf.Round (sscale.x), h = (int)Mathf.Round (sscale.y);
		for (int y = 0; y < h; y++) {
			for (int x = 0; x < w; x++) {
				child = (GameObject) Instantiate (prefab);
				child.transform.parent = transform;
				child.transform.position = transform.position +
					new Vector3(x * ssize.x,
					            y * ssize.y,
					            0);
			}
		}

		sprite.enabled = false;
		Destroy (prefab);
	}
}
