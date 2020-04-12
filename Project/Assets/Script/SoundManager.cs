using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {


	public IEnumerator fadeIn(){
		GameObject x = GameObject.Find ("Background_Music");
		AudioSource a = x.GetComponent<AudioSource> ();

		while (a.volume <= 1) {
			a.volume += 0.05f;
			yield return new WaitForSeconds (0.1f);
		}
		//a.volume = 1;
		yield return null;
	}

	public IEnumerator fadeOut(){
		GameObject x = GameObject.Find ("Background_Music");
		AudioSource a = x.GetComponent<AudioSource> ();

		while (a.volume > 0) {
			a.volume -= 0.05f;
			yield return new WaitForSeconds (0.1f);
		}
		//a.volume = 1;
		yield return null;
	}
}
