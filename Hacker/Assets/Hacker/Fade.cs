using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {
	[SerializeField] public float FadeTime = 0.5f;
	[SerializeField] public float FadePower = 2.0f;

	private GUITexture texture;
	private string targetLevel;
	private Color targetColor;
	private float targetTime;
	private bool fadeIn;
	private bool isActive;

	// Use this for initialization
	void Start () {
		texture = GetComponent<GUITexture>();
		targetColor = Color.black;
		targetTime = Time.time;
		isActive = true;
		fadeIn = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isActive)
			return;
		float dtime = Time.time - targetTime;
		if (dtime > FadeTime) {
			if (fadeIn)
				texture.enabled = false;
			isActive = false;
			if (targetLevel != null)
				Application.LoadLevel(targetLevel);
			return;
		}
		dtime /= FadeTime;
		if (fadeIn)
			dtime = 1.0f - dtime;
		if (!(dtime >= 0.0f))
			dtime = 0.0f;
		texture.color = new Color(
			targetColor.r, targetColor.g, targetColor.b,
			Mathf.Pow (dtime, FadePower));
	}

	public static void GoToLevel(Color color, string levelName) {
		GameObject obj = GameObject.Find ("Fade");
		Fade f = obj != null ? obj.GetComponent<Fade>() : null;
		if (f == null) {
			Application.LoadLevel(Application.loadedLevelName);
			return;
		} else if (f.targetLevel == null) {
			f.texture.enabled = true;
			f.targetLevel = levelName;
			f.targetColor = color;
			f.targetTime = Time.time;
			f.isActive = true;
			f.fadeIn = false;
		}
	}
}
