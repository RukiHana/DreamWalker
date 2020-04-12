using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class VNK_NextDialogButton : MonoBehaviour {
	
	public SpriteRenderer buttonSprite;
	public Sprite spriteReleased;
	public Sprite spritePressed;
	public AudioClip buttonPressAudio;
	
	private AudioSource thisAudioSource;


	// Use this for initialization
	void Start(){
		thisAudioSource = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update(){
	
	}
	
	public void OnCustomMouseUp(){
		HandleButtonUp();
	}
	public void OnTouchUp(){
		HandleButtonUp();
	}

	public void OnTouchDown(){
		HandleButtonDown();
	}
	public void OnCustomMouseDown(){
		HandleButtonDown();
	}
	
	void HandleButtonUp(){
		if(buttonSprite != null){
			buttonSprite.sprite = spriteReleased;
		}
		if(buttonPressAudio){
			thisAudioSource.PlayOneShot(buttonPressAudio);
		}
		
		VNK_DialogCreator.canGoOnNextScreen = true;
	}
	void HandleButtonDown(){
		if(buttonSprite != null){
			buttonSprite.sprite = spritePressed;
		}
	}
}