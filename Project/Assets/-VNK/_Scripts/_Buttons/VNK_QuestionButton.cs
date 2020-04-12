using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class VNK_QuestionButton : MonoBehaviour {
	
	public enum QuestionsEnum {Question01, Question02, Question03, Question04}
	public QuestionsEnum questionType = QuestionsEnum.Question01;
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
	
	public void OnCustomMouseDown(){
		HandleButtonDown();
	}
	public void OnTouchDown(){
		HandleButtonDown();
	}


	void HandleButtonUp(){
		if(buttonSprite != null){
			buttonSprite.sprite = spriteReleased;
		}
		if(buttonPressAudio){
			thisAudioSource.PlayOneShot(buttonPressAudio);
		}

		if(questionType == QuestionsEnum.Question01){
			VNK_DialogCreator.canGoToQuestion01 = true;
		}
		if(questionType == QuestionsEnum.Question02){
			VNK_DialogCreator.canGoToQuestion02 = true;
		}
		if(questionType == QuestionsEnum.Question03){
			VNK_DialogCreator.canGoToQuestion03 = true;
		}
		if(questionType == QuestionsEnum.Question04){
			VNK_DialogCreator.canGoToQuestion04 = true;
		}
	}
	
	void HandleButtonDown(){
		if(buttonSprite != null){
			buttonSprite.sprite = spritePressed;
		}
	}
}