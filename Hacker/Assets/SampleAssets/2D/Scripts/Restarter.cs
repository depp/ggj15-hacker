using UnityEngine;

namespace UnitySampleAssets._2D
{
    public class Restarter : MonoBehaviour
    {
		[SerializeField] public Color FadeColor = Color.red;
		[SerializeField] public AudioClip Fall;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player") {
				if (Fall != null) {
					AudioSource.PlayClipAtPoint(Fall, Vector3.zero);
				}
				Fade.RunAction(FadeColor, Fall.length, this.Execute, other.gameObject);
			}
        }

		private void Execute(GameObject player)
		{
			Application.LoadLevel (Application.loadedLevelName);
		}
    }
}