using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {
	[SerializeField] public float FadeTime = 0.5f;
	[SerializeField] public float FadePower = 2.0f;

	public delegate void Action(GameObject obj);

	private GUITexture texture;
	private Action target;
	private GameObject invoker;
	private Color targetColor;
	private float targetTime;
	private float fadeTime;
	private bool fadeIn;
	private bool isActive;

	// Use this for initialization
	void Start () {
		texture = GetComponent<GUITexture>();
		targetColor = Color.black;
		targetTime = Time.time;
		fadeTime = FadeTime;
		isActive = true;
		fadeIn = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isActive)
			return;
		float dtime = Time.time - targetTime;
		if (dtime > fadeTime) {
			if (fadeIn) {
				texture.enabled = false;
				isActive = false;
				return;
			} else {
				if (target != null)
					target(invoker);
				target = null;
				invoker = null;
				fadeIn = true;
				targetTime += fadeTime;
				dtime -= fadeTime;
			}
		}
		dtime /= fadeTime;
		if (fadeIn)
			dtime = 1.0f - dtime;
		if (!(dtime >= 0.0f))
			dtime = 0.0f;
		texture.color = new Color(
			targetColor.r, targetColor.g, targetColor.b,
			Mathf.Pow (dtime, FadePower));
	}

	public static void RunAction(Color color, float time, Action target, GameObject invoker) {
		GameObject obj = GameObject.Find ("Fade");
		Fade f = obj != null ? obj.GetComponent<Fade>() : null;
		if (f == null) {
			target(invoker);
			return;
		} else if (f.target == null) {
			f.texture.enabled = true;
			f.target = target;
			f.invoker = invoker;
			f.targetColor = color;
			f.targetTime = Time.time;
			f.fadeTime = time;
			f.isActive = true;
			f.fadeIn = false;
		}
	}
}
