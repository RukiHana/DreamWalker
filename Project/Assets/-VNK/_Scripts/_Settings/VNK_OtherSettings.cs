using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class VNK_OtherSettings : MonoBehaviour {
	
	public enum OtherSettEnum {DialogSpeed, SetFullscreen, AutoDialogSpeed}
	public OtherSettEnum buttonType = OtherSettEnum.DialogSpeed;
	
	public SpriteRenderer buttonSprite;
	public Sprite spriteReleased;
	public Sprite spritePressed;
	public AudioClip buttonPressAudio;
	public GameObject dialogSpeedObj;
	public float dialogSpeedObj_fullScale;
	public SpriteRenderer toggleSprite;
	public Sprite toggleNo;
	public Sprite toggleYes;
	
	private AudioSource thisAudioSource;
	private Transform dialogSpeedObjTrans;
	

	// Use this for initialization
	void Start(){
		thisAudioSource = gameObject.GetComponent<AudioSource>();
		if(buttonType == OtherSettEnum.DialogSpeed || buttonType == OtherSettEnum.AutoDialogSpeed){
			dialogSpeedObjTrans = dialogSpeedObj.GetComponent<Transform>();
		}
	}
	
	// Update is called once per frame
	void Update(){
		if(buttonType == OtherSettEnum.DialogSpeed){
			dialogSpeedObjTrans.localScale = new Vector3(dialogSpeedObj_fullScale * (VNK_DialogManager.dialogSpeed / VNK_DialogManager.staticMaxDialogSpeed), dialogSpeedObjTrans.localScale.y, dialogSpeedObjTrans.localScale.z);
		}
		else if(buttonType == OtherSettEnum.AutoDialogSpeed){
			dialogSpeedObjTrans.localScale = new Vector3(dialogSpeedObj_fullScale * (VNK_DialogManager.currentAutoDialogSpeed / VNK_DialogManager.staticMaxAutoDialogSpeed), dialogSpeedObjTrans.localScale.y, dialogSpeedObjTrans.localScale.z);
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
			if(VNK_DialogManager.dialogSpeed >= VNK_DialogManager.staticMaxDialogSpeed){
				VNK_DialogManager.dialogSpeed = 0.01f;
			}
			if(VNK_DialogManager.dialogSpeed < 0.1f){
				VNK_DialogManager.dialogSpeed += 0.01f;
			}
			
			VNK_DialogManager.dialogSpeed = Mathf.Clamp(VNK_DialogManager.dialogSpeed, 0.01f, 0.1f);
			
			PlayerPrefs.SetFloat("keyDialogSpeed", VNK_DialogManager.dialogSpeed);
		}
		else if(buttonType == OtherSettEnum.SetFullscreen){
			Screen.fullScreen = !Screen.fullScreen;
			
			VNK_DialogManager.SaveBool("keyIsFullscreen", Screen.fullScreen);
		}
		else if(buttonType == OtherSettEnum.AutoDialogSpeed){
			if(VNK_DialogManager.currentAutoDialogSpeed >= VNK_DialogManager.staticMaxAutoDialogSpeed){
				VNK_DialogManager.currentAutoDialogSpeed = VNK_DialogManager.staticMinAutoDialogSpeed;
			}
			if(VNK_DialogManager.currentAutoDialogSpeed < VNK_DialogManager.staticMaxAutoDialogSpeed){
				VNK_DialogManager.currentAutoDialogSpeed += 0.5f;
			}
			
			PlayerPrefs.SetFloat("keyAutoDialogSpeed", VNK_DialogManager.currentAutoDialogSpeed);
		}
	}

	void HandleButtonDown(){
		if(buttonSprite != null){
			buttonSprite.sprite = spritePressed;
		}
	}
}
