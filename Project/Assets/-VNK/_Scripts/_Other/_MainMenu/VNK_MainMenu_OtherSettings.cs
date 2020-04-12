using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class VNK_MainMenu_OtherSettings : MonoBehaviour {
	
	public enum OtherSettEnum {DialogSpeed, SetFullscreen, ResetData, AutoDialogSpeed}
	public OtherSettEnum buttonType = OtherSettEnum.DialogSpeed;
	
	public SpriteRenderer buttonSprite;
	public Sprite spriteReleased;
	public Sprite spritePressed;
	public AudioClip buttonPressAudio;
	public GameObject dialogSpeedObj;
	public float baseDialogSpeed = 0.05f;
	public float maxDialogSpeed = 0.1f; //Lower is faster
	public float minAutoDialog = 1.0f;
	public float maxAutoDialog = 20.0f;
	public float baseAutoDialog = 7.0f;
	public float dialogSpeedObj_fullScale;
	public SpriteRenderer toggleSprite;
	public Sprite toggleNo;
	public Sprite toggleYes;
	
	private AudioSource thisAudioSource;
	private Transform dialogSpeedObjTrans;
	private float currentDialogSpeed;
	private float currentAutoDialogSpeed;
	

	// Use this for initialization
	void Start(){
		thisAudioSource = gameObject.GetComponent<AudioSource>();
		if(buttonType == OtherSettEnum.DialogSpeed || buttonType == OtherSettEnum.AutoDialogSpeed){
			dialogSpeedObjTrans = dialogSpeedObj.GetComponent<Transform>();
		}

		if(PlayerPrefs.HasKey("keyDialogSpeed")){
			currentDialogSpeed = PlayerPrefs.GetFloat("keyDialogSpeed");
		}
		else{
			currentDialogSpeed = baseDialogSpeed;
		}
		
		if(PlayerPrefs.HasKey("keyAutoDialogSpeed")){
			currentAutoDialogSpeed = PlayerPrefs.GetFloat("keyAutoDialogSpeed");
		}
		else{
			currentAutoDialogSpeed = baseAutoDialog;
		}
	}
	
	// Update is called once per frame
	void Update(){
		if(buttonType == OtherSettEnum.DialogSpeed){
			dialogSpeedObjTrans.localScale = new Vector3(dialogSpeedObj_fullScale * (currentDialogSpeed / maxDialogSpeed), dialogSpeedObjTrans.localScale.y, dialogSpeedObjTrans.localScale.z);
		}
		else if(buttonType == OtherSettEnum.AutoDialogSpeed){
			dialogSpeedObjTrans.localScale = new Vector3(dialogSpeedObj_fullScale * (currentAutoDialogSpeed / maxAutoDialog), dialogSpeedObjTrans.localScale.y, dialogSpeedObjTrans.localScale.z);
		}
		else if(buttonType == OtherSettEnum.SetFullscreen){
			if(Screen.fullScreen){
				toggleSprite.sprite = toggleYes;
			}
			else{
				toggleSprite.sprite = toggleNo;
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
		if(buttonSprite != null){
			buttonSprite.sprite = spriteReleased;
		}
		if(buttonPressAudio){
			thisAudioSource.PlayOneShot(buttonPressAudio);
		}
		
		
		if(buttonType == OtherSettEnum.DialogSpeed){
			if(currentDialogSpeed >= maxDialogSpeed){
				currentDialogSpeed = 0.01f;
			}
			if(currentDialogSpeed < 0.1f){
				currentDialogSpeed += 0.01f;
			}

			currentDialogSpeed = Mathf.Clamp(currentDialogSpeed, 0.01f, 0.1f);

			PlayerPrefs.SetFloat("keyDialogSpeed", currentDialogSpeed);
		}
		else if(buttonType == OtherSettEnum.SetFullscreen){
			Screen.fullScreen = !Screen.fullScreen;
			
			VNK_DialogManager.SaveBool("keyIsFullscreen", Screen.fullScreen);
		}
		else if(buttonType == OtherSettEnum.ResetData){
			PlayerPrefs.DeleteAll();
		}
		else if(buttonType == OtherSettEnum.AutoDialogSpeed){
			if(currentAutoDialogSpeed >= maxAutoDialog){
				currentAutoDialogSpeed = minAutoDialog;
			}
			if(currentAutoDialogSpeed < maxAutoDialog){
				currentAutoDialogSpeed += 0.5f;
			}
			
			PlayerPrefs.SetFloat("keyAutoDialogSpeed", currentAutoDialogSpeed);
		}
	}

	void HandleButtonDown(){
		if(buttonSprite != null){
			buttonSprite.sprite = spritePressed;
		}
	}
}
