using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class VNK_SettingsButton : MonoBehaviour {
	
	public enum ButtoTypeEnum {Open, Close}
	public ButtoTypeEnum buttonType = ButtoTypeEnum.Open;
	
	public SpriteRenderer buttonSprite;
	public Sprite spriteReleased;
	public Sprite spritePressed;
	public AudioClip buttonPressAudio;
	public GameObject settingMenu;
	
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
		
		
		if(buttonType == ButtoTypeEnum.Open){
			if(!VNK_DialogManager.showSettingMenu){
				VNK_DialogManager.showSettingMenu = true;
				settingMenu.SetActive(true);
				Time.timeScale = 0.0f;
			}
		}
		else if(buttonType == ButtoTypeEnum.Close){
			if(VNK_DialogManager.showSettingMenu){
				VNK_DialogManager.showSettingMenu = false;
				settingMenu.SetActive(false);
				Time.timeScale = 1.0f;
			}
		}
	}
	
	void HandleButtonDown(){
		if(buttonSprite != null){
			buttonSprite.sprite = spritePressed;
		}
	}
}
