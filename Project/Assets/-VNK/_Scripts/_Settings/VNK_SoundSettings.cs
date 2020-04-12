using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class VNK_SoundSettings : MonoBehaviour {

	public enum SoundTypeEnum {BgAmbience, BgSoundFx, BgMusic, CharaVoice, OtherFx}
	public SoundTypeEnum soundType = SoundTypeEnum.BgAmbience;
	
	public SpriteRenderer buttonSprite;
	public Sprite spriteReleased;
	public Sprite spritePressed;
	public AudioClip buttonPressAudio;
	public GameObject soundLevelObj;
	public float soundLevelObj_fullScale;

	private AudioSource thisAudioSource;
	private Transform soundLevelObjTrans;
	
	
	// Use this for initialization
	void Start(){
		thisAudioSource = gameObject.GetComponent<AudioSource>();
		soundLevelObjTrans = soundLevelObj.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update(){
		if(soundType == SoundTypeEnum.BgAmbience){
			soundLevelObjTrans.localScale = new Vector3(soundLevelObj_fullScale * VNK_DialogManager.staticBgAmbience.volume, soundLevelObjTrans.localScale.y, soundLevelObjTrans.localScale.z);
		}
		else if(soundType == SoundTypeEnum.BgSoundFx){
			soundLevelObjTrans.localScale = new Vector3(soundLevelObj_fullScale * VNK_DialogManager.staticBgFX.volume, soundLevelObjTrans.localScale.y, soundLevelObjTrans.localScale.z);
		}
		else if(soundType == SoundTypeEnum.BgMusic){
			soundLevelObjTrans.localScale = new Vector3(soundLevelObj_fullScale * VNK_DialogManager.staticBgMusic.volume, soundLevelObjTrans.localScale.y, soundLevelObjTrans.localScale.z);
		}
		else if(soundType == SoundTypeEnum.CharaVoice){
			soundLevelObjTrans.localScale = new Vector3(soundLevelObj_fullScale * VNK_DialogManager.staticCharaVoice.volume, soundLevelObjTrans.localScale.y, soundLevelObjTrans.localScale.z);
		}
		else if(soundType == SoundTypeEnum.OtherFx){
			soundLevelObjTrans.localScale = new Vector3(soundLevelObj_fullScale * VNK_DialogManager.staticGameplayFX.volume, soundLevelObjTrans.localScale.y, soundLevelObjTrans.localScale.z);
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
		if(buttonSprite != null){
			buttonSprite.sprite = spriteReleased;
		}
		if(buttonPressAudio){
			thisAudioSource.PlayOneShot(buttonPressAudio);
		}

		
		if(soundType == SoundTypeEnum.BgAmbience){
			if(VNK_DialogManager.staticBgAmbience.volume >= 1.0f){
				VNK_DialogManager.staticBgAmbience.volume = 0.0f;
			}
			if(VNK_DialogManager.staticBgAmbience.volume < 1.0f){
				VNK_DialogManager.staticBgAmbience.volume += 0.1f;
			}

			PlayerPrefs.SetFloat("keyBgAmbienceVolume", VNK_DialogManager.staticBgAmbience.volume);
		}
		else if(soundType == SoundTypeEnum.BgSoundFx){
			if(VNK_DialogManager.staticBgFX.volume >= 1.0f){
				VNK_DialogManager.staticBgFX.volume = 0.0f;
			}
			if(VNK_DialogManager.staticBgFX.volume < 1.0f){
				VNK_DialogManager.staticBgFX.volume += 0.1f;
			}

			PlayerPrefs.SetFloat("keyBgFXVolume", VNK_DialogManager.staticBgFX.volume);
		}
		else if(soundType == SoundTypeEnum.BgMusic){
			if(VNK_DialogManager.staticBgMusic.volume >= 1.0f){
				VNK_DialogManager.staticBgMusic.volume = 0.0f;
			}
			if(VNK_DialogManager.staticBgMusic.volume < 1.0f){
				VNK_DialogManager.staticBgMusic.volume += 0.1f;
			}
			
			PlayerPrefs.SetFloat("keyBgMusicVolume", VNK_DialogManager.staticBgMusic.volume);
		}
		else if(soundType == SoundTypeEnum.CharaVoice){
			if(VNK_DialogManager.staticCharaVoice.volume >= 1.0f){
				VNK_DialogManager.staticCharaVoice.volume = 0.0f;
			}
			if(VNK_DialogManager.staticCharaVoice.volume < 1.0f){
				VNK_DialogManager.staticCharaVoice.volume += 0.1f;
			}
			
			PlayerPrefs.SetFloat("keyCharaVoiceVolume", VNK_DialogManager.staticCharaVoice.volume);
		}
		else if(soundType == SoundTypeEnum.OtherFx){
			if(VNK_DialogManager.staticGameplayFX.volume >= 1.0f){
				VNK_DialogManager.staticGameplayFX.volume = 0.0f;
			}
			if(VNK_DialogManager.staticGameplayFX.volume < 1.0f){
				VNK_DialogManager.staticGameplayFX.volume += 0.1f;
			}
			
			PlayerPrefs.SetFloat("keyGameplayFXVolume", VNK_DialogManager.staticGameplayFX.volume);
		}
	}
	void HandleButtonDown(){
		if(buttonSprite != null){
			buttonSprite.sprite = spritePressed;
		}
	}
}
