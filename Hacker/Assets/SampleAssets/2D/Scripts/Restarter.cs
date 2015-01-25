using UnityEngine;

namespace UnitySampleAssets._2D
{
    public class Restarter : MonoBehaviour
    {
		[SerializeField] public float FadeTime = 0.5f;
		[SerializeField] public Color FadeColor = Color.red;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
				Fade.RunAction(FadeColor, FadeTime, this.Execute, other.gameObject);
        }

		private void Execute(GameObject player)
		{
			Application.LoadLevel (Application.loadedLevelName);
		}
    }
}