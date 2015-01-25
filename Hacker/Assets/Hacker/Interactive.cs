using UnityEngine;
using System.Collections;
using UnitySampleAssets._2D;

public abstract class Interactive : MonoBehaviour {
	[SerializeField] public float BobRate = 4.0f;
	[SerializeField] public float BobAmount = 0.3f;
	[SerializeField] public Sprite ArrowSprite;
	[SerializeField] public Sprite NoEntrySprite;
	
	private Transform arrowTransform;
	private Vector2 startVector;
	private SpriteRenderer sprite;
	private bool isActive;
	private bool isPermitted;
	
	public void Awake()
	{
		arrowTransform = transform.Find ("Arrow");
		if (arrowTransform == null) {
			Debug.LogError ("Interactive has no arrow!");
			return;
		}
		startVector = arrowTransform.localPosition;
		sprite = arrowTransform.GetComponent<SpriteRenderer>();
		if (sprite == null) {
			Debug.LogError ("Interactive has no sprite!");
			return;
		}
		sprite.enabled = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (isActive)
			return;
		Platformer2DUserControl p = other.GetComponent<Platformer2DUserControl>();
		if (p == null)
			return;
		isActive = true;
		sprite.enabled = true;
		if (IsPermitted (p)) {
			p.InteractionObj = this;
			sprite.sprite = ArrowSprite;
		} else {
			sprite.sprite = NoEntrySprite;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (!isActive)
			return;
		Platformer2DUserControl p = other.GetComponent<Platformer2DUserControl>();
		if (p == null)
			return;
		isActive = false;
		sprite.enabled = false;
		if (p.InteractionObj == this)
			p.InteractionObj = null;
	}

	protected virtual void Update()
	{
		if (!isActive)
			return;
		arrowTransform.localPosition = startVector + new Vector2(0.0f, BobAmount * Mathf.Sin (BobRate * Time.time));
	}

	protected virtual bool IsPermitted(Platformer2DUserControl player) {
		return true;
	}

	public abstract void Interact(Platformer2DUserControl player);
}
