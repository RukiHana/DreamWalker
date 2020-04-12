using UnityEngine;
using System.Collections;

public class VNK_DialogCreator : MonoBehaviour {
	//The dialog ID is used to switch dialog screen
	public int dialogID;
	
	//The name of the character
	public string characterName = "Name";
	
	public GameObject dialogObj;
	public Color textColor = new Color(0.0f, 0.0f, 0.0f, 1.0f);
	public bool colorReset;
	public Color resetColor = new Color(0.0f, 0.0f, 0.0f, 1.0f); // When the dialog will end you'll probably want to reset

	//The text which will be shown
	public string dialogText = "Dialog text goes here";
	public string dialogTextItalian = "Dialog text goes here (Italian)";
	public string dialogText_Spanish = "Dialog text goes here (Spanish)";
	public string dialogText_German = "Dialog text goes here (German)";
	public string dialogText_French = "Dialog text goes here (French)";
	public string dialogText_Japanese = "Dialog text goes here (Japanese)";
	public string dialogText_Chinese = "Dialog text goes here (Chinese)";
	public string dialogText_Russian = "Dialog text goes here (Russian)";

	//Change character sprite
	public bool changeCharaSprite;
	public SpriteRenderer[] characters;
	public Sprite[] charaSprite;

	//Move sprite
	public bool moveChara;
	public GameObject[] charactersToMove;
	public Vector3[] charactersNewPosition;
	public float[] timesToMove;

	//Fade sprite
	public bool fadeSprite;
	public SpriteRenderer[] spriteToFade;
	public float[] fadeToVal;
	public float[] timesToFade;

	//Change Background
	public bool changeBackground;
	public bool fadeChanging;
	public Sprite newBackground;
	public Sprite newBackground_question01;
	public Sprite newBackground_question02;
	public Sprite newBackground_question03;
	public Sprite newBackground_question04;

	//Save stuff
	public bool saveState;
	public bool saveCurrentLevel;
	public string levelName;

	//Flip character
	public bool flipChara;
	public GameObject[] charaToFlip;
	public Vector3[] rotateCharaTo;
	public float[] rotateInTime;

	//move to ID
	public int moveToID;

	//Audios
	public AudioClip bgAmbienceClip;
	public AudioClip bgFxClip;
	public AudioClip bgMusicClip;
	public AudioClip charaVoiceClip;
	public AudioClip gameplayFxClip;
	
	//You can create two kind of dialog Standard (Next button) dialog
	//And mutiple dialog (up to four chooices)
	public string[] dialogTypeArray = new string[] {"Standard", "MultipleChoice"};
	public int dialogType;
	
	//The string for the three question you can ask
	public string questionOne;
	public string questionTwo;
	public string questionThree;
	public string questionFour;
	public string questionOne_Italian;
	public string questionTwo_Italian;
	public string questionThree_Italian;
	public string questionFour_Italian;
	public string questionOne_Spanish;
	public string questionTwo_Spanish;
	public string questionThree_Spanish;
	public string questionFour_Spanish;
	public string questionOne_German;
	public string questionTwo_German;
	public string questionThree_German;
	public string questionFour_German;
	public string questionOne_French;
	public string questionTwo_French;
	public string questionThree_French;
	public string questionFour_French;
	public string questionOne_Japanese;
	public string questionTwo_Japanese;
	public string questionThree_Japanese;
	public string questionFour_Japanese;
	public string questionOne_Chinese;
	public string questionTwo_Chinese;
	public string questionThree_Chinese;
	public string questionFour_Chinese;
	public string questionOne_Russian;
	public string questionTwo_Russian;
	public string questionThree_Russian;
	public string questionFour_Russian;

	// The ID we will brought to if we choose an answer
	public int questionOneToID;
	public int questionTwoToID;
	public int questionThreeToID;
	public int questionFourToID;
	
	//Is that the last dialog screen? Should I destroy it on dialog end?
	public bool isLastOne;
	public bool destroyOnEnd;
	public bool switchDialog;
	public GameObject newDialog;
	
	//Want to destroy object
	public bool wantToDestroyObj;
	public GameObject objToDestroy;
	
	//Want to send message to object
	public bool wantToSendMessageToObj;
	public GameObject objToSendMessage;
	public string messageToSend;
	
	private bool isPlayingThisDialog;
	private string internalDialogText;
	private string internalQuestionOne;
	private string internalQuestionTwo;
	private string internalQuestionThree;
	private string internalQuestionFour;
	private string buttonText;
	
	public static bool canGoOnNextScreen;
	
	public static bool canGoToQuestion01;
	public static bool canGoToQuestion02;
	public static bool canGoToQuestion03;
	public static bool canGoToQuestion04;

	private bool canFadeBack01 = false;
	private bool canFadeBack02 = false;
	private bool canChangeScreen = true;
	private bool isShowingDialog = false;
	
	private bool playedBgFxClip = false;
	private bool playedCharaVoiceClip = false;
	private bool playedGameplayFxClip = false;

	private bool autoMovedToNextScreen = false;

	private VNK_DialogCreator newDialogComp;

	public GameObject x;
	public AudioSource a;
	private bool isFade = false;
	private float tim=2.0f;

	void Start(){
//
//		x = GameObject.Find ("Background_Music");
//		a= x.GetComponent<AudioSource> ();

	}
	
	void Update(){
//		if (isFade && a.volume>0) {
//			
//			a.volume -= 0.3f;
//			tim -= 1.0f * Time.deltaTime;
//
////			if (tim < 0) {
////				isFade = false;
////				tim = 2.0f;
////			}
//		}

		ShowCurrentDialog();
		
/*
        //코드 수정 부분 16.07.22//
        //Enter 입력으로 넥스트 버튼과 동일한 효과 적용
        if (Input.GetKeyDown(KeyCode.Space))
        {
            VNK_DialogCreator.canGoOnNextScreen = true;
        }
        */
        HandleNextSentenceStuff();
    }
	
	public void AssignScript(){
		gameObject.AddComponent<VNK_DialogCreator>();
	}
	
	public void Play(){
		VNK_DialogManager.isEnabled = true;
		isPlayingThisDialog = true;
	}
	
	public void Stop(){
		if(dialogObj != null){
			if(dialogObj.activeSelf){
				dialogObj.SetActive(false);
			}
		}
		canGoToQuestion01 = false;
		canGoToQuestion02 = false;
		canGoToQuestion03 = false;
		canGoToQuestion04 = false;
		autoMovedToNextScreen = false;

		canChangeScreen = true;

		VNK_DialogManager.isEnabled = false;
		isPlayingThisDialog = false;
		VNK_DialogManager.privateID = 0;
		VNK_DialogManager.currentDialog = null;
		isShowingDialog = false;
	}

	void ShowCurrentDialog(){
		if(VNK_DialogManager.isEnabled && dialogID == VNK_DialogManager.privateID && isPlayingThisDialog && VNK_DialogManager.currentDialog == this.gameObject){
			VNK_DialogManager.staticNextButton.SetActive(canChangeScreen);
			VNK_DialogManager.staticLoadButton.SetActive(canChangeScreen);
			VNK_DialogManager.staticSaveButton.SetActive(canChangeScreen);
			VNK_DialogManager.staticSettingButton.SetActive(canChangeScreen);
			VNK_DialogManager.staticAutoButton.SetActive(canChangeScreen);


			if(changeCharaSprite){
				for(int i = 0; i < characters.Length; i++){
					characters[i].sprite = charaSprite[i];
				}
			}
			if(moveChara){
				for(int i = 0; i < charactersToMove.Length; i++){
					iTween.MoveTo(charactersToMove[i], iTween.Hash("position", charactersNewPosition[i], "islocal", true, "time", timesToMove[i]));
				}
			}
			if(fadeSprite){
				for(int i = 0; i < spriteToFade.Length; i++){
					iTween.ColorTo(spriteToFade[i].gameObject, new Color(spriteToFade[i].color.r, spriteToFade[i].color.g, spriteToFade[i].color.b, fadeToVal[i]), timesToFade[i]);
				}
			}
			if(flipChara){
				for(int i = 0; i < charaToFlip.Length; i++){
					iTween.RotateTo(charaToFlip[i], rotateCharaTo[i], rotateInTime[i]);
				}
			}


			if(bgAmbienceClip != null && VNK_DialogManager.staticBgAmbience.clip != bgAmbienceClip){
				VNK_DialogManager.staticBgAmbience.clip = bgAmbienceClip;
				VNK_DialogManager.staticBgAmbience.Play();
			}
			if(bgFxClip != null && !playedBgFxClip){
				playedBgFxClip = true;
				VNK_DialogManager.staticBgFX.PlayOneShot(bgFxClip);
			}
			if(bgMusicClip != null && VNK_DialogManager.staticBgMusic.clip != bgMusicClip){
				VNK_DialogManager.staticBgMusic.clip = bgMusicClip;
				VNK_DialogManager.staticBgMusic.volume = 1;
				VNK_DialogManager.staticBgMusic.Play();
			}
			if(charaVoiceClip != null && !playedCharaVoiceClip){
				playedCharaVoiceClip = true;

				SoundManager s = GameObject.Find ("_SoundsEmitter").GetComponent<SoundManager> ();
				StartCoroutine (s.fadeOut ());
				//isFade = true;
				//StartCoroutine ("fadeInOut");
				//VNK_DialogManager.staticCharaVoice.PlayOneShot(charaVoiceClip);
			}
			if(gameplayFxClip != null && !playedGameplayFxClip){
				playedGameplayFxClip = true;
				VNK_DialogManager.staticGameplayFX.PlayOneShot(gameplayFxClip);
			}


			#region StandardDialog
			//if it's a standard dialog
			if(dialogType == 0){
				//Show Dialog hide question
				VNK_DialogManager.staticDialogUI.SetActive(true);
				VNK_DialogManager.staticQuestionUI.SetActive(false);

				// AutoNextScreen
				if(!autoMovedToNextScreen && VNK_DialogManager.autoGoToNextScreen){
					StartCoroutine("AutoNextScreen");
				}
				
				if(VNK_LanguageManager.gameLanguage == VNK_LanguageManager.LanguagesEnum.English){
					internalDialogText = dialogText;
				}
				if(VNK_LanguageManager.gameLanguage == VNK_LanguageManager.LanguagesEnum.Italian){
					internalDialogText = dialogTextItalian;
				}
				if(VNK_LanguageManager.gameLanguage == VNK_LanguageManager.LanguagesEnum.Spanish){
					internalDialogText = dialogText_Spanish;
				}
				if(VNK_LanguageManager.gameLanguage == VNK_LanguageManager.LanguagesEnum.German){
					internalDialogText = dialogText_German;
				}
				if(VNK_LanguageManager.gameLanguage == VNK_LanguageManager.LanguagesEnum.French){
					internalDialogText = dialogText_French;
				}
				if(VNK_LanguageManager.gameLanguage == VNK_LanguageManager.LanguagesEnum.Japanese){
					internalDialogText = dialogText_Japanese;
				}
				if(VNK_LanguageManager.gameLanguage == VNK_LanguageManager.LanguagesEnum.Chinese){
					internalDialogText = dialogText_Chinese;
				}
				if(VNK_LanguageManager.gameLanguage == VNK_LanguageManager.LanguagesEnum.Russian){
					internalDialogText = dialogText_Russian;
				}

				VNK_DialogManager.staticDialogText.color = textColor;

				//show dialog and character name label
				VNK_DialogManager.staticNameText.text = characterName;
                /*
				if(!isShowingDialog){
					StartCoroutine("ShowDialog", internalDialogText);
				}*/
				VNK_DialogManager.staticDialogText.text = internalDialogText;
			}
			#endregion
			
			#region MultipleQuestion
			//It's a multiple choice dialog
			if(dialogType == 1){
				//Show question hide dialog
				VNK_DialogManager.staticDialogUI.SetActive(false);
				VNK_DialogManager.staticQuestionUI.SetActive(true);

				if(VNK_LanguageManager.gameLanguage == VNK_LanguageManager.LanguagesEnum.English){
					internalQuestionOne = questionOne;
					internalQuestionTwo = questionTwo;
					internalQuestionThree = questionThree;
					internalQuestionFour = questionFour;
				}
				if(VNK_LanguageManager.gameLanguage == VNK_LanguageManager.LanguagesEnum.Italian){
					internalQuestionOne = questionOne_Italian;
					internalQuestionTwo = questionTwo_Italian;
					internalQuestionThree = questionThree_Italian;
					internalQuestionFour = questionFour_Italian;
				}
				if(VNK_LanguageManager.gameLanguage == VNK_LanguageManager.LanguagesEnum.Spanish){
					internalQuestionOne = questionOne_Spanish;
					internalQuestionTwo = questionTwo_Spanish;
					internalQuestionThree = questionThree_Spanish;
					internalQuestionFour = questionFour_Spanish;
				}
				if(VNK_LanguageManager.gameLanguage == VNK_LanguageManager.LanguagesEnum.German){
					internalQuestionOne = questionOne_German;
					internalQuestionTwo = questionTwo_German;
					internalQuestionThree = questionThree_German;
					internalQuestionFour = questionFour_German;
				}
				if(VNK_LanguageManager.gameLanguage == VNK_LanguageManager.LanguagesEnum.French){
					internalQuestionOne = questionOne_French;
					internalQuestionTwo = questionTwo_French;
					internalQuestionThree = questionThree_French;
					internalQuestionFour = questionFour_French;
				}
				if(VNK_LanguageManager.gameLanguage == VNK_LanguageManager.LanguagesEnum.Japanese){
					internalQuestionOne = questionOne_Japanese;
					internalQuestionTwo = questionTwo_Japanese;
					internalQuestionThree = questionThree_Japanese;
					internalQuestionFour = questionFour_Japanese;
				}
				if(VNK_LanguageManager.gameLanguage == VNK_LanguageManager.LanguagesEnum.Chinese){
					internalQuestionOne = questionOne_Chinese;
					internalQuestionTwo = questionTwo_Chinese;
					internalQuestionThree = questionThree_Chinese;
					internalQuestionFour = questionFour_Chinese;
				}
				if(VNK_LanguageManager.gameLanguage == VNK_LanguageManager.LanguagesEnum.Russian){
					internalQuestionOne = questionOne_Russian;
					internalQuestionTwo = questionTwo_Russian;
					internalQuestionThree = questionThree_Russian;
					internalQuestionFour = questionFour_Russian;
				}

				// Is the question text is different than "" or " " we can display the button and give to the button labe the question text
				if(internalQuestionOne == "" || internalQuestionOne == " "){
					VNK_DialogManager.staticQuestion01Obj.SetActive(false);
				}
				if(internalQuestionOne != "" || internalQuestionOne == " "){
					VNK_DialogManager.staticQuestion01Obj.SetActive(true);
					VNK_DialogManager.staticQuestion01Text.text = internalQuestionOne;
				}
				
				if(internalQuestionTwo == "" || internalQuestionTwo == " "){
					VNK_DialogManager.staticQuestion02Obj.SetActive(false);
				}
				if(internalQuestionTwo != "" || internalQuestionTwo == " "){
					VNK_DialogManager.staticQuestion02Obj.SetActive(true);
					VNK_DialogManager.staticQuestion02Text.text = internalQuestionTwo;
				}
				
				if(internalQuestionThree == "" || internalQuestionThree == " "){
					VNK_DialogManager.staticQuestion03Obj.SetActive(false);
				}
				if(internalQuestionThree != "" || internalQuestionThree == " "){
					VNK_DialogManager.staticQuestion03Obj.SetActive(true);
					VNK_DialogManager.staticQuestion03Text.text = internalQuestionThree;
				}
				
				if(internalQuestionFour == "" || internalQuestionFour == " "){
					VNK_DialogManager.staticQuestion04Obj.SetActive(false);
				}
				if(internalQuestionFour != "" || internalQuestionFour == " "){
					VNK_DialogManager.staticQuestion04Obj.SetActive(true);
					VNK_DialogManager.staticQuestion04Text.text = internalQuestionFour;
				}
			}	
			#endregion
		}
	}
	
	IEnumerator ShowDialog(string dialogText){
		isShowingDialog = true;
		
		for(int i = 0; i <= dialogText.Length; i ++){
			VNK_DialogManager.staticDialogText.text = dialogText.Substring(0, i);
			//PlaySoundHere
			yield return new WaitForSeconds(VNK_DialogManager.dialogSpeed);
		}
	}

	IEnumerator AutoNextScreen(){
		autoMovedToNextScreen = true;

		yield return new WaitForSeconds(VNK_DialogManager.currentAutoDialogSpeed);

		GoToNextScreen();
	}

	void HandleNextSentenceStuff(){
		if(canGoOnNextScreen == true && VNK_DialogManager.isEnabled && dialogID == VNK_DialogManager.privateID && isPlayingThisDialog && VNK_DialogManager.currentDialog == this.gameObject && canChangeScreen){
			GoToNextScreen();
		}
		
		if(canGoToQuestion01 == true && VNK_DialogManager.isEnabled && dialogID == VNK_DialogManager.privateID && isPlayingThisDialog && VNK_DialogManager.currentDialog == this.gameObject && canChangeScreen){
			if(changeBackground && newBackground_question01 != null){ //Background02 is over Background01
				if(fadeChanging){
					if(VNK_DialogManager.staticBackground01.color.a != 0.0f && VNK_DialogManager.staticBackground02.color.a == 0.0f && !canFadeBack02){
						FadeBackground02(newBackground_question01);
					}
					else if(VNK_DialogManager.staticBackground01.color.a == 0.0f && VNK_DialogManager.staticBackground02.color.a != 0.0f && !canFadeBack01){
						FadeBackground01(newBackground_question01);
					}
				}
				else{
					if(VNK_DialogManager.staticBackground01.color.a != 0.0f && VNK_DialogManager.staticBackground02.color.a == 0.0f){
						VNK_DialogManager.staticBackground01.sprite = newBackground;
					}
					else if(VNK_DialogManager.staticBackground01.color.a == 0.0f && VNK_DialogManager.staticBackground02.color.a != 0.0f){
						VNK_DialogManager.staticBackground02.sprite = newBackground;
					}
				}
			}
			
			canGoToQuestion01 = false;
			VNK_DialogManager.privateID = questionOneToID;
		}
		if(canGoToQuestion02 == true && VNK_DialogManager.isEnabled && dialogID == VNK_DialogManager.privateID && isPlayingThisDialog && VNK_DialogManager.currentDialog == this.gameObject && canChangeScreen){
			if(changeBackground && newBackground_question02 != null){ //Background02 is over Background01
				if(fadeChanging){
					if(VNK_DialogManager.staticBackground01.color.a != 0.0f && VNK_DialogManager.staticBackground02.color.a == 0.0f && !canFadeBack02){
						FadeBackground02(newBackground_question02);
					}
					else if(VNK_DialogManager.staticBackground01.color.a == 0.0f && VNK_DialogManager.staticBackground02.color.a != 0.0f && !canFadeBack01){
						FadeBackground01(newBackground_question02);
					}
				}
				else{
					if(VNK_DialogManager.staticBackground01.color.a != 0.0f && VNK_DialogManager.staticBackground02.color.a == 0.0f){
						VNK_DialogManager.staticBackground01.sprite = newBackground;
					}
					else if(VNK_DialogManager.staticBackground01.color.a == 0.0f && VNK_DialogManager.staticBackground02.color.a != 0.0f){
						VNK_DialogManager.staticBackground02.sprite = newBackground;
					}
				}
			}
			
			canGoToQuestion02 = false;
			VNK_DialogManager.privateID = questionTwoToID;
		}
		if(canGoToQuestion03 == true && VNK_DialogManager.isEnabled && dialogID == VNK_DialogManager.privateID && isPlayingThisDialog && VNK_DialogManager.currentDialog == this.gameObject && canChangeScreen){
			if(changeBackground && newBackground_question03 != null){ //Background02 is over Background01
				if(fadeChanging){
					if(VNK_DialogManager.staticBackground01.color.a != 0.0f && VNK_DialogManager.staticBackground02.color.a == 0.0f && !canFadeBack02){
						FadeBackground02(newBackground_question03);
					}
					else if(VNK_DialogManager.staticBackground01.color.a == 0.0f && VNK_DialogManager.staticBackground02.color.a != 0.0f && !canFadeBack01){
						FadeBackground01(newBackground_question03);
					}
				}
				else{
					if(VNK_DialogManager.staticBackground01.color.a != 0.0f && VNK_DialogManager.staticBackground02.color.a == 0.0f){
						VNK_DialogManager.staticBackground01.sprite = newBackground;
					}
					else if(VNK_DialogManager.staticBackground01.color.a == 0.0f && VNK_DialogManager.staticBackground02.color.a != 0.0f){
						VNK_DialogManager.staticBackground02.sprite = newBackground;
					}
				}
			}
			
			canGoToQuestion03 = false;
			VNK_DialogManager.privateID = questionThreeToID;
		}
		if(canGoToQuestion04 == true && VNK_DialogManager.isEnabled && dialogID == VNK_DialogManager.privateID && isPlayingThisDialog && VNK_DialogManager.currentDialog == this.gameObject && canChangeScreen){
			if(changeBackground && newBackground_question04 != null){ //Background02 is over Background01
				if(fadeChanging){
					if(VNK_DialogManager.staticBackground01.color.a != 0.0f && VNK_DialogManager.staticBackground02.color.a == 0.0f && !canFadeBack02){
						FadeBackground02(newBackground_question04);
					}
					else if(VNK_DialogManager.staticBackground01.color.a == 0.0f && VNK_DialogManager.staticBackground02.color.a != 0.0f && !canFadeBack01){
						FadeBackground01(newBackground_question04);
					}
				}
				else{
					if(VNK_DialogManager.staticBackground01.color.a != 0.0f && VNK_DialogManager.staticBackground02.color.a == 0.0f){
						VNK_DialogManager.staticBackground01.sprite = newBackground;
					}
					else if(VNK_DialogManager.staticBackground01.color.a == 0.0f && VNK_DialogManager.staticBackground02.color.a != 0.0f){
						VNK_DialogManager.staticBackground02.sprite = newBackground;
					}
				}
			}
			
			canGoToQuestion04 = false;
			VNK_DialogManager.privateID = questionFourToID;
		}
	}

	// This is called when we move to another dialog
	void GoToNextScreen(){
		StopCoroutine("AutoNextScreen");
		StopCoroutine("ShowDialog");
		isShowingDialog = false;
		canGoOnNextScreen = false;
		playedBgFxClip = false;
		playedCharaVoiceClip = false;
		playedGameplayFxClip = false;
		autoMovedToNextScreen = false;

		
		VNK_DialogManager.staticBgFX.Stop();
		VNK_DialogManager.staticCharaVoice.Stop();
		VNK_DialogManager.staticGameplayFX.Stop();


		if(changeBackground){ //Background02 is over Background01
			if(fadeChanging){
				if(VNK_DialogManager.staticBackground01.color.a != 0.0f && VNK_DialogManager.staticBackground02.color.a == 0.0f && !canFadeBack02){
					FadeBackground02(newBackground);
				}
				else if(VNK_DialogManager.staticBackground01.color.a == 0.0f && VNK_DialogManager.staticBackground02.color.a != 0.0f && !canFadeBack01){
					FadeBackground01(newBackground);
				}
			}
			else{
				if(VNK_DialogManager.staticBackground01.color.a != 0.0f && VNK_DialogManager.staticBackground02.color.a == 0.0f){
					VNK_DialogManager.staticBackground01.sprite = newBackground;
				}
				else if(VNK_DialogManager.staticBackground01.color.a == 0.0f && VNK_DialogManager.staticBackground02.color.a != 0.0f){
					VNK_DialogManager.staticBackground02.sprite = newBackground;
				}
			}
		}
		
		if(saveState){
			VNK_DialogManager.SaveSavedata();
			PlayerPrefs.SetString("keyLastDialog", this.gameObject.name);

			if(saveCurrentLevel){
				PlayerPrefs.SetString("keyLastLevel", levelName);
			}
		}
		if(!isLastOne){
			if(wantToDestroyObj){
				Destroy(objToDestroy);
			}
			if(wantToSendMessageToObj){
				objToSendMessage.SendMessage(messageToSend);
			}
			VNK_DialogManager.privateID = moveToID;
		}
		if(isLastOne){
			VNK_DialogManager.staticDialogText.text = "";
			
			if(colorReset){
				VNK_DialogManager.staticDialogText.color = resetColor;
			}
			if(wantToDestroyObj){
				Destroy(objToDestroy);
			}
			if(wantToSendMessageToObj){
				objToSendMessage.SendMessage(messageToSend);
			}

			if(switchDialog){
				if(destroyOnEnd){
					this.gameObject.GetComponent<VNK_DialogCreator>().Stop();
					newDialog.SetActive(true);
					VNK_DialogManager.currentDialog = newDialog;
					newDialog.GetComponent<VNK_DialogCreator>().Play();
					Destroy(gameObject);
				}
				if(!destroyOnEnd){

					this.gameObject.GetComponent<VNK_DialogCreator>().Stop();
					newDialog.SetActive(true);
					VNK_DialogManager.currentDialog = newDialog;
					newDialog.GetComponent<VNK_DialogCreator>().Play();
					this.gameObject.SetActive(false);
				}
			}
			if(!switchDialog){
				if(destroyOnEnd){
                    EndDialog e = null;//만약 챕터의 마지막 일 경우
                    e = this.gameObject.GetComponent<EndDialog>();
                    if (e != null)
                    {
                        e.callAnything();
                    }
                    Stop();
					Destroy(gameObject);
				}
				if(!destroyOnEnd){
                    EndDialog e = null;//만약 챕터의 마지막 일 경우
                    e = this.gameObject.GetComponent<EndDialog>();
                    if (e != null)
                    {
                        e.callAnything();
                    }
                    Stop();
				}
			}
		}
	}


	void FadeBackground01(Sprite newBack){
		canFadeBack01 = true;
		canFadeBack02 = true;
		VNK_DialogManager.staticBackground01.color = new Color(VNK_DialogManager.staticBackground01.color.r, VNK_DialogManager.staticBackground01.color.g, VNK_DialogManager.staticBackground01.color.b, 1.0f);
		VNK_DialogManager.staticBackground01.sprite = newBack;
		
		Hashtable ht = iTween.Hash("from", 1.0f, "to", 0.0f, "time", 1.5f, "onupdate","ChangeBackground02Value", "oncomplete", "ChangeSpriteAlpha02", "onstart", "StartFading");
		iTween.ValueTo(this.gameObject, ht);
	}
	void FadeBackground02(Sprite newBack){
		canFadeBack02 = true;
		canFadeBack01 = true;
		VNK_DialogManager.staticBackground02.sprite = newBack;
		
		Hashtable ht = iTween.Hash("from", 0.0f, "to", 1.0f, "time", 1.5f, "onupdate","ChangeBackground02Value", "oncomplete", "ChangeSpriteAlpha01", "onstart", "StartFading");
		iTween.ValueTo(this.gameObject, ht);
	}


	void ChangeBackground02Value(float newValue){
		VNK_DialogManager.staticBackground02.color = new Color(VNK_DialogManager.staticBackground02.color.r, VNK_DialogManager.staticBackground02.color.g, VNK_DialogManager.staticBackground02.color.b, newValue);
		//Debug.Log(newValue);
	}


	void StartFading(){
		canChangeScreen = false;
	}


	void ChangeSpriteAlpha01(){
		VNK_DialogManager.staticBackground01.color = new Color(VNK_DialogManager.staticBackground01.color.r, VNK_DialogManager.staticBackground01.color.g, VNK_DialogManager.staticBackground01.color.b, 0.0f);
		VNK_DialogManager.staticBackground02.color = new Color(VNK_DialogManager.staticBackground02.color.r, VNK_DialogManager.staticBackground02.color.g, VNK_DialogManager.staticBackground02.color.b, 1.0f);
		canFadeBack01 = false;
		canFadeBack02 = false;
		VNK_DialogManager.staticBackground01.sprite = null;
		canChangeScreen = true;
	}
	void ChangeSpriteAlpha02(){
		VNK_DialogManager.staticBackground01.color = new Color(VNK_DialogManager.staticBackground01.color.r, VNK_DialogManager.staticBackground01.color.g, VNK_DialogManager.staticBackground01.color.b, 1.0f);
		VNK_DialogManager.staticBackground02.color = new Color(VNK_DialogManager.staticBackground02.color.r, VNK_DialogManager.staticBackground02.color.g, VNK_DialogManager.staticBackground02.color.b, 0.0f);
		canFadeBack01 = false;
		VNK_DialogManager.staticBackground02.sprite = null;
		canChangeScreen = true;
	}
//		
//	public IEnumerator fadeInOut(){
//		Debug.Log ("DDD");
//		GameObject x = GameObject.Find ("Background_Music");
//		AudioSource a = x.GetComponent<AudioSource> ();
//
//		while (a.volume > 0) {
//			a.volume -= 0.5f;
//			yield return new WaitForSeconds (0.1f);
//		}
//		//a.volume = 1;
//		yield return null;
//	}

	public IEnumerator wait3Sec(){
		canChangeScreen = false;
		yield return new WaitForSeconds (3);
		canChangeScreen = true;
		yield return null;
	}
}
