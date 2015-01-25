using UnityEngine;
using System.Collections;
using UnitySampleAssets._2D;

public class Interactive : MonoBehaviour {
	const float BobRate = 4.0f;
	const float BobAmount = 0.3f;
	private Transform arrowTransform;
	private Vector2 startVector;
	private SpriteRenderer arrowSprite;
	private bool isActive;
	
	public void Awake()
	{
		arrowTransform = transform.Find ("Arrow");
		if (arrowTransform == null) {
			Debug.LogError ("Interactive has no arrow!");
			return;
		}
		startVector = arrowTransform.localPosition;
		arrowSprite = arrowTransform.GetComponent<SpriteRenderer>();
		if (arrowSprite == null) {
			Debug.LogError ("Interactive has no sprite!");
			return;
		}
		arrowSprite.enabled = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (isActive)
			return;
		Platformer2DUserControl p = other.GetComponent<Platformer2DUserControl>();
		if (p == null)
			return;
		isActive = true;
		arrowSprite.enabled = true;
		p.InteractionObj = this;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (!isActive)
			return;
		Platformer2DUserControl p = other.GetComponent<Platformer2DUserControl>();
		if (p == null)
			return;
		isActive = false;
		arrowSprite.enabled = false;
		if (p.InteractionObj == this)
			p.InteractionObj = null;
	}

	public void Update()
	{
		if (!isActive)
			return;
		arrowTransform.localPosition = startVector + new Vector2(0.0f, BobAmount * Mathf.Sin (BobRate * Time.time));
	}
}
