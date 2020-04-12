using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class VNK_SaveLoadAutoButton : MonoBehaviour {

	public enum ButtonTypeEnum {Load, Save, Auto}

	public ButtonTypeEnum buttonType = ButtonTypeEnum.Save;
	public SpriteRenderer buttonSprite;
	public Sprite spriteReleased;
	public Sprite spritePressed;
	public AudioClip buttonPressAudio;
	public bool saveLevelToo;
	public string levelName;
	
	private AudioSource thisAudioSource;


	// Use this for initialization
	void Start(){
		thisAudioSource = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update(){
		if(buttonType == ButtonTypeEnum.Auto){
			if(!VNK_DialogManager.autoGoToNextScreen){
				buttonSprite.sprite = spriteReleased;
			}
			if(VNK_DialogManager.autoGoToNextScreen){
				buttonSprite.sprite = spritePressed;
			}
		}
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
		if(buttonSprite != null && buttonType != ButtonTypeEnum.Auto){
			buttonSprite.sprite = spriteReleased;
		}
		if(buttonPressAudio){
			thisAudioSource.PlayOneShot(buttonPressAudio);
		}

		if(buttonType == ButtonTypeEnum.Save){
			VNK_DialogManager.SaveSavedata();
			PlayerPrefs.SetString("keyLastDialog", VNK_DialogManager.currentDialog.name);
			if(saveLevelToo){
				PlayerPrefs.SetString("keyLastLevel", levelName);
			}
		}
		else if(buttonType == ButtonTypeEnum.Load){
			VNK_DialogManager.LoadSavedata();
		}
		else if(buttonType == ButtonTypeEnum.Auto){
			VNK_DialogManager.autoGoToNextScreen = !VNK_DialogManager.autoGoToNextScreen;
		}
	}
	void HandleButtonDown(){
		if(buttonSprite != null && buttonType != ButtonTypeEnum.Auto){
			buttonSprite.sprite = spritePressed;
		}
	}
}