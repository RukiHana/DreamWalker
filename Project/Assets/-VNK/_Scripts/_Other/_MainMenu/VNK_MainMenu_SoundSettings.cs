using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class VNK_MainMenu_SoundSettings : MonoBehaviour {

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

	private float retrievedBgAmbience;
	private float retrievedBgSoundFx;
	private float retrievedBgMusic;
	private float retrievedCharaVoice;
	private float retrievedOtherFx;
	
	
	// Use this for initialization
	void Start(){
		thisAudioSource = gameObject.GetComponent<AudioSource>();
		soundLevelObjTrans = soundLevelObj.GetComponent<Transform>();

		
		if(PlayerPrefs.HasKey("keyBgAmbienceVolume")){
			retrievedBgAmbience = PlayerPrefs.GetFloat("keyBgAmbienceVolume");
		}
		else{
			retrievedBgAmbience = 1.0f;
		}
		if(PlayerPrefs.HasKey("keyBgFXVolume")){
			retrievedBgSoundFx = PlayerPrefs.GetFloat("keyBgFXVolume");
		}
		else{
			retrievedBgSoundFx = 1.0f;
		}
		if(PlayerPrefs.HasKey("keyBgMusicVolume")){
			retrievedBgMusic = PlayerPrefs.GetFloat("keyBgMusicVolume");
		}
		else{
			retrievedBgMusic = 1.0f;
		}
		if(PlayerPrefs.HasKey("keyCharaVoiceVolume")){
			retrievedCharaVoice = PlayerPrefs.GetFloat("keyCharaVoiceVolume");
		}
		else{
			retrievedCharaVoice = 1.0f;
		}
		if(PlayerPrefs.HasKey("keyGameplayFXVolume")){
			retrievedOtherFx = PlayerPrefs.GetFloat("keyGameplayFXVolume");
		}
		else{
			retrievedOtherFx = 1.0f;
		}

	}
	
	// Update is called once per frame
	void Update(){
		if(PlayerPrefs.HasKey("keyBgAmbienceVolume")){
			retrievedBgAmbience = PlayerPrefs.GetFloat("keyBgAmbienceVolume");
		}
		if(PlayerPrefs.HasKey("keyBgFXVolume")){
			retrievedBgSoundFx = PlayerPrefs.GetFloat("keyBgFXVolume");
		}
		if(PlayerPrefs.HasKey("keyBgMusicVolume")){
			retrievedBgMusic = PlayerPrefs.GetFloat("keyBgMusicVolume");
		}
		if(PlayerPrefs.HasKey("keyCharaVoiceVolume")){
			retrievedCharaVoice = PlayerPrefs.GetFloat("keyCharaVoiceVolume");
		}
		if(PlayerPrefs.HasKey("keyGameplayFXVolume")){
			retrievedOtherFx = PlayerPrefs.GetFloat("keyGameplayFXVolume");
		}


		if(soundType == SoundTypeEnum.BgAmbience){
			soundLevelObjTrans.localScale = new Vector3(soundLevelObj_fullScale * retrievedBgAmbience, soundLevelObjTrans.localScale.y, soundLevelObjTrans.localScale.z);
		}
		else if(soundType == SoundTypeEnum.BgSoundFx){
			soundLevelObjTrans.localScale = new Vector3(soundLevelObj_fullScale * retrievedBgSoundFx, soundLevelObjTrans.localScale.y, soundLevelObjTrans.localScale.z);
		}
		else if(soundType == SoundTypeEnum.BgMusic){
			soundLevelObjTrans.localScale = new Vector3(soundLevelObj_fullScale * retrievedBgMusic, soundLevelObjTrans.localScale.y, soundLevelObjTrans.localScale.z);
		}
		else if(soundType == SoundTypeEnum.CharaVoice){
			soundLevelObjTrans.localScale = new Vector3(soundLevelObj_fullScale * retrievedCharaVoice, soundLevelObjTrans.localScale.y, soundLevelObjTrans.localScale.z);
		}
		else if(soundType == SoundTypeEnum.OtherFx){
			soundLevelObjTrans.localScale = new Vector3(soundLevelObj_fullScale * retrievedOtherFx, soundLevelObjTrans.localScale.y, soundLevelObjTrans.localScale.z);
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
			if(retrievedBgAmbience >= 1.0f){
				retrievedBgAmbience = 0.0f;
			}
			if(retrievedBgAmbience < 1.0f){
				retrievedBgAmbience += 0.1f;
			}

			PlayerPrefs.SetFloat("keyBgAmbienceVolume", retrievedBgAmbience);
		}
		else if(soundType == SoundTypeEnum.BgSoundFx){
			if(retrievedBgSoundFx >= 1.0f){
				retrievedBgSoundFx = 0.0f;
			}
			if(retrievedBgSoundFx < 1.0f){
				retrievedBgSoundFx += 0.1f;
			}

			PlayerPrefs.SetFloat("keyBgFXVolume", retrievedBgSoundFx);
		}
		else if(soundType == SoundTypeEnum.BgMusic){
			if(retrievedBgMusic >= 1.0f){
				retrievedBgMusic = 0.0f;
			}
			if(retrievedBgMusic < 1.0f){
				retrievedBgMusic += 0.1f;
			}
			
			PlayerPrefs.SetFloat("keyBgMusicVolume", retrievedBgMusic);
		}
		else if(soundType == SoundTypeEnum.CharaVoice){
			if(retrievedCharaVoice >= 1.0f){
				retrievedCharaVoice = 0.0f;
			}
			if(retrievedCharaVoice < 1.0f){
				retrievedCharaVoice += 0.1f;
			}
			
			PlayerPrefs.SetFloat("keyCharaVoiceVolume", retrievedCharaVoice);
		}
		else if(soundType == SoundTypeEnum.OtherFx){
			if(retrievedOtherFx >= 1.0f){
				retrievedOtherFx = 0.0f;
			}
			if(retrievedOtherFx < 1.0f){
				retrievedOtherFx += 0.1f;
			}
			
			PlayerPrefs.SetFloat("keyGameplayFXVolume", retrievedOtherFx);
		}
	}
	void HandleButtonDown(){
		if(buttonSprite != null){
			buttonSprite.sprite = spritePressed;
		}
	}
}
