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
		if (dtime < 0.0f) {
			dtime = -dtime;
		} else {
			if (!fadeIn) {
				if (target != null)
					target(invoker);
				fadeIn = true;
				target = null;
				invoker = null;
			}
			if (dtime >= fadeTime) {
				texture.enabled = false;
				isActive = false;
			}
		}
		dtime /= fadeTime;
		if (!(dtime >= 0.0f)) {
			dtime = 0.0f;
		} else if (!(dtime <= 1.0f)) {
			dtime = 1.0f;
		}
		texture.color = new Color(
			targetColor.r, targetColor.g, targetColor.b,
			Mathf.Pow (1.0f - dtime, FadePower));
	}

	public static void RunAction(Color color, float time, Action target, GameObject invoker, float targetTime) {
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
			f.targetTime = targetTime;
			f.fadeTime = time;
			f.isActive = true;
			f.fadeIn = false;
		}
	}

	public static void RunAction(Color color, float time, Action target, GameObject invoker) {
		RunAction (color, time, target, invoker, Time.time + time);
	}
}
