using UnityEngine;
using UnityEditor;

public static class Editor_VNK_Menu {
	[MenuItem("Tools/VNK Menu/New Dialog")]
	static void CreateStartDialog(){
		GameObject dialog = new GameObject();
		dialog.name = "--New Dialog";
		dialog.AddComponent<VNK_PlayDialogOnStart>();
		dialog.AddComponent<VNK_DialogCreator>();
		dialog.GetComponent<VNK_PlayDialogOnStart>().dialog = dialog.GetComponent<VNK_DialogCreator>();
	}
	
	
	[MenuItem("Tools/VNK Menu/Create GameManager Object")]
	static void CreateGameManager(){
		GameObject gameManager = new GameObject();
		gameManager.name = "_GameManager";
		gameManager.AddComponent<VNK_LanguageManager>();
		gameManager.AddComponent<VNK_DialogManager>();
		gameManager.AddComponent<VNK_TouchManager>();
		gameManager.AddComponent<VNK_FadeCamera>();
		gameManager.AddComponent<VNK_ResumeLastDialog>();
		
		VNK_TouchManager touchManagerComp = gameManager.GetComponent<VNK_TouchManager>();
		
		touchManagerComp.cameraObj = Camera.main;
	}


	[MenuItem("Tools/VNK Menu/Setup InGame Buttons/Setup Next Button")]
	static void SetupDialogButton_NextButton(){
		if(Selection.activeTransform){
			GameObject selObj = Selection.activeTransform.gameObject;
			if(!selObj.GetComponent<Collider>()){
				selObj.AddComponent<BoxCollider>();
			}
			selObj.AddComponent<VNK_NextDialogButton>();
			VNK_NextDialogButton nextButtonComp = selObj.GetComponent<VNK_NextDialogButton>();
			if(selObj.GetComponent<SpriteRenderer>()){
				nextButtonComp.buttonSprite = selObj.GetComponent<SpriteRenderer>();
				nextButtonComp.spriteReleased = selObj.GetComponent<SpriteRenderer>().sprite;
			}
		}
		else{
			Debug.LogError("Please select a GameObject (one with a SpriteRender if possible)");
		}
	}

	[MenuItem("Tools/VNK Menu/Setup InGame Buttons/Setup Save Button")]
	static void SetupDialogButton_SaveButton(){
		if(Selection.activeTransform){
			GameObject selObj = Selection.activeTransform.gameObject;
			if(!selObj.GetComponent<Collider>()){
				selObj.AddComponent<BoxCollider>();
			}
			selObj.AddComponent<VNK_SaveLoadAutoButton>();
			VNK_SaveLoadAutoButton saveLoadButtonComp = selObj.GetComponent<VNK_SaveLoadAutoButton>();
			saveLoadButtonComp.buttonType = VNK_SaveLoadAutoButton.ButtonTypeEnum.Save;
			if(selObj.GetComponent<SpriteRenderer>()){
				saveLoadButtonComp.buttonSprite = selObj.GetComponent<SpriteRenderer>();
				saveLoadButtonComp.spriteReleased = selObj.GetComponent<SpriteRenderer>().sprite;
			}
		}
		else{
			Debug.LogError("Please select a GameObject (one with a SpriteRender if possible)");
		}
	}
	
	[MenuItem("Tools/VNK Menu/Setup InGame Buttons/Setup Load Button")]
	static void SetupDialogButton_LoadButton(){
		if(Selection.activeTransform){
			GameObject selObj = Selection.activeTransform.gameObject;
			if(!selObj.GetComponent<Collider>()){
				selObj.AddComponent<BoxCollider>();
			}
			selObj.AddComponent<VNK_SaveLoadAutoButton>();
			VNK_SaveLoadAutoButton saveLoadButtonComp = selObj.GetComponent<VNK_SaveLoadAutoButton>();
			saveLoadButtonComp.buttonType = VNK_SaveLoadAutoButton.ButtonTypeEnum.Load;
			if(selObj.GetComponent<SpriteRenderer>()){
				saveLoadButtonComp.buttonSprite = selObj.GetComponent<SpriteRenderer>();
				saveLoadButtonComp.spriteReleased = selObj.GetComponent<SpriteRenderer>().sprite;
			}
		}
		else{
			Debug.LogError("Please select a GameObject (one with a SpriteRender if possible)");
		}
	}
	
	[MenuItem("Tools/VNK Menu/Setup InGame Buttons/Setup Auto Button")]
	static void SetupDialogButton_AutoButton(){
		if(Selection.activeTransform){
			GameObject selObj = Selection.activeTransform.gameObject;
			if(!selObj.GetComponent<Collider>()){
				selObj.AddComponent<BoxCollider>();
			}
			selObj.AddComponent<VNK_SaveLoadAutoButton>();
			VNK_SaveLoadAutoButton saveLoadButtonComp = selObj.GetComponent<VNK_SaveLoadAutoButton>();
			saveLoadButtonComp.buttonType = VNK_SaveLoadAutoButton.ButtonTypeEnum.Auto;
			if(selObj.GetComponent<SpriteRenderer>()){
				saveLoadButtonComp.buttonSprite = selObj.GetComponent<SpriteRenderer>();
				saveLoadButtonComp.spriteReleased = selObj.GetComponent<SpriteRenderer>().sprite;
			}
		}
		else{
			Debug.LogError("Please select a GameObject (one with a SpriteRender if possible)");
		}
	}

	[MenuItem("Tools/VNK Menu/Setup InGame Buttons/Setup Question 01 Button")]
	static void SetupDialogButton_Question01Button(){
		if(Selection.activeTransform){
			GameObject selObj = Selection.activeTransform.gameObject;
			if(!selObj.GetComponent<Collider>()){
				selObj.AddComponent<BoxCollider>();
			}
			selObj.AddComponent<VNK_QuestionButton>();
			VNK_QuestionButton questionButtonComp = selObj.GetComponent<VNK_QuestionButton>();
			questionButtonComp.questionType = VNK_QuestionButton.QuestionsEnum.Question01;
			if(selObj.GetComponent<SpriteRenderer>()){
				questionButtonComp.buttonSprite = selObj.GetComponent<SpriteRenderer>();
				questionButtonComp.spriteReleased = selObj.GetComponent<SpriteRenderer>().sprite;
			}
		}
		else{
			Debug.LogError("Please select a GameObject (one with a SpriteRender if possible)");
		}
	}

	[MenuItem("Tools/VNK Menu/Setup InGame Buttons/Setup Question 02 Button")]
	static void SetupDialogButton_Question02Button(){
		if(Selection.activeTransform){
			GameObject selObj = Selection.activeTransform.gameObject;
			if(!selObj.GetComponent<Collider>()){
				selObj.AddComponent<BoxCollider>();
			}
			selObj.AddComponent<VNK_QuestionButton>();
			VNK_QuestionButton questionButtonComp = selObj.GetComponent<VNK_QuestionButton>();
			questionButtonComp.questionType = VNK_QuestionButton.QuestionsEnum.Question02;
			if(selObj.GetComponent<SpriteRenderer>()){
				questionButtonComp.buttonSprite = selObj.GetComponent<SpriteRenderer>();
				questionButtonComp.spriteReleased = selObj.GetComponent<SpriteRenderer>().sprite;
			}
		}
		else{
			Debug.LogError("Please select a GameObject (one with a SpriteRender if possible)");
		}
	}

	[MenuItem("Tools/VNK Menu/Setup InGame Buttons/Setup Question 03 Button")]
	static void SetupDialogButton_Question03Button(){
		if(Selection.activeTransform){
			GameObject selObj = Selection.activeTransform.gameObject;
			if(!selObj.GetComponent<Collider>()){
				selObj.AddComponent<BoxCollider>();
			}
			selObj.AddComponent<VNK_QuestionButton>();
			VNK_QuestionButton questionButtonComp = selObj.GetComponent<VNK_QuestionButton>();
			questionButtonComp.questionType = VNK_QuestionButton.QuestionsEnum.Question03;
			if(selObj.GetComponent<SpriteRenderer>()){
				questionButtonComp.buttonSprite = selObj.GetComponent<SpriteRenderer>();
				questionButtonComp.spriteReleased = selObj.GetComponent<SpriteRenderer>().sprite;
			}
		}
		else{
			Debug.LogError("Please select a GameObject (one with a SpriteRender if possible)");
		}
	}
	
	[MenuItem("Tools/VNK Menu/Setup InGame Buttons/Setup Question 04 Button")]
	static void SetupDialogButton_Question04Button(){
		if(Selection.activeTransform){
			GameObject selObj = Selection.activeTransform.gameObject;
			if(!selObj.GetComponent<Collider>()){
				selObj.AddComponent<BoxCollider>();
			}
			selObj.AddComponent<VNK_QuestionButton>();
			VNK_QuestionButton questionButtonComp = selObj.GetComponent<VNK_QuestionButton>();
			questionButtonComp.questionType = VNK_QuestionButton.QuestionsEnum.Question04;
			if(selObj.GetComponent<SpriteRenderer>()){
				questionButtonComp.buttonSprite = selObj.GetComponent<SpriteRenderer>();
				questionButtonComp.spriteReleased = selObj.GetComponent<SpriteRenderer>().sprite;
			}
		}
		else{
			Debug.LogError("Please select a GameObject (one with a SpriteRender if possible)");
		}
	}
	
	[MenuItem("Tools/VNK Menu/Setup InGame Buttons/Setup Setting Button (Open)")]
	static void SetupDialogButton_SettingButton_Open(){
		if(Selection.activeTransform){
			GameObject selObj = Selection.activeTransform.gameObject;
			if(!selObj.GetComponent<Collider>()){
				selObj.AddComponent<BoxCollider>();
			}
			selObj.AddComponent<VNK_SettingsButton>();
			VNK_SettingsButton settingButtonComp = selObj.GetComponent<VNK_SettingsButton>();
			settingButtonComp.buttonType = VNK_SettingsButton.ButtoTypeEnum.Open;
			if(selObj.GetComponent<SpriteRenderer>()){
				settingButtonComp.buttonSprite = selObj.GetComponent<SpriteRenderer>();
				settingButtonComp.spriteReleased = selObj.GetComponent<SpriteRenderer>().sprite;
			}
		}
		else{
			Debug.LogError("Please select a GameObject (one with a SpriteRender if possible)");
		}
	}
	
	[MenuItem("Tools/VNK Menu/Setup InGame Buttons/Setup Setting Button (Close)")]
	static void SetupDialogButton_SettingButton_Close(){
		if(Selection.activeTransform){
			GameObject selObj = Selection.activeTransform.gameObject;
			if(!selObj.GetComponent<Collider>()){
				selObj.AddComponent<BoxCollider>();
			}
			selObj.AddComponent<VNK_SettingsButton>();
			VNK_SettingsButton settingButtonComp = selObj.GetComponent<VNK_SettingsButton>();
			settingButtonComp.buttonType = VNK_SettingsButton.ButtoTypeEnum.Close;
			if(selObj.GetComponent<SpriteRenderer>()){
				settingButtonComp.buttonSprite = selObj.GetComponent<SpriteRenderer>();
				settingButtonComp.spriteReleased = selObj.GetComponent<SpriteRenderer>().sprite;
			}
		}
		else{
			Debug.LogError("Please select a GameObject (one with a SpriteRender if possible)");
		}
	}


	[MenuItem("Tools/VNK Menu/Setup Audio Settings Buttons/Setup BgAmbience Button")]
	static void SetupSettingsButton_AudioButton_BgAmbience(){
		if(Selection.activeTransform){
			GameObject selObj = Selection.activeTransform.gameObject;
			if(!selObj.GetComponent<Collider>()){
				selObj.AddComponent<BoxCollider>();
			}
			selObj.AddComponent<VNK_SoundSettings>();
			VNK_SoundSettings soundButtonComp = selObj.GetComponent<VNK_SoundSettings>();
			soundButtonComp.soundType = VNK_SoundSettings.SoundTypeEnum.BgAmbience;
			if(selObj.GetComponent<SpriteRenderer>()){
				soundButtonComp.buttonSprite = selObj.GetComponent<SpriteRenderer>();
				soundButtonComp.spriteReleased = selObj.GetComponent<SpriteRenderer>().sprite;
			}
		}
		else{
			Debug.LogError("Please select a GameObject (one with a SpriteRender if possible)");
		}
	}

	[MenuItem("Tools/VNK Menu/Setup Audio Settings Buttons/Setup BgSoundFx Button")]
	static void SetupSettingsButton_AudioButton_BgSoundFx(){
		if(Selection.activeTransform){
			GameObject selObj = Selection.activeTransform.gameObject;
			if(!selObj.GetComponent<Collider>()){
				selObj.AddComponent<BoxCollider>();
			}
			selObj.AddComponent<VNK_SoundSettings>();
			VNK_SoundSettings soundButtonComp = selObj.GetComponent<VNK_SoundSettings>();
			soundButtonComp.soundType = VNK_SoundSettings.SoundTypeEnum.BgSoundFx;
			if(selObj.GetComponent<SpriteRenderer>()){
				soundButtonComp.buttonSprite = selObj.GetComponent<SpriteRenderer>();
				soundButtonComp.spriteReleased = selObj.GetComponent<SpriteRenderer>().sprite;
			}
		}
		else{
			Debug.LogError("Please select a GameObject (one with a SpriteRender if possible)");
		}
	}

	[MenuItem("Tools/VNK Menu/Setup Audio Settings Buttons/Setup BgMusic Button")]
	static void SetupSettingsButton_AudioButton_BgMusic(){
		if(Selection.activeTransform){
			GameObject selObj = Selection.activeTransform.gameObject;
			if(!selObj.GetComponent<Collider>()){
				selObj.AddComponent<BoxCollider>();
			}
			selObj.AddComponent<VNK_SoundSettings>();
			VNK_SoundSettings soundButtonComp = selObj.GetComponent<VNK_SoundSettings>();
			soundButtonComp.soundType = VNK_SoundSettings.SoundTypeEnum.BgMusic;
			if(selObj.GetComponent<SpriteRenderer>()){
				soundButtonComp.buttonSprite = selObj.GetComponent<SpriteRenderer>();
				soundButtonComp.spriteReleased = selObj.GetComponent<SpriteRenderer>().sprite;
			}
		}
		else{
			Debug.LogError("Please select a GameObject (one with a SpriteRender if possible)");
		}
	}

	[MenuItem("Tools/VNK Menu/Setup Audio Settings Buttons/Setup CharaVoice Button")]
	static void SetupSettingsButton_AudioButton_CharaVoice(){
		if(Selection.activeTransform){
			GameObject selObj = Selection.activeTransform.gameObject;
			if(!selObj.GetComponent<Collider>()){
				selObj.AddComponent<BoxCollider>();
			}
			selObj.AddComponent<VNK_SoundSettings>();
			VNK_SoundSettings soundButtonComp = selObj.GetComponent<VNK_SoundSettings>();
			soundButtonComp.soundType = VNK_SoundSettings.SoundTypeEnum.CharaVoice;
			if(selObj.GetComponent<SpriteRenderer>()){
				soundButtonComp.buttonSprite = selObj.GetComponent<SpriteRenderer>();
				soundButtonComp.spriteReleased = selObj.GetComponent<SpriteRenderer>().sprite;
			}
		}
		else{
			Debug.LogError("Please select a GameObject (one with a SpriteRender if possible)");
		}
	}
	
	[MenuItem("Tools/VNK Menu/Setup Audio Settings Buttons/Setup OtherFx Button")]
	static void SetupSettingsButton_AudioButton_OtherFx(){
		if(Selection.activeTransform){
			GameObject selObj = Selection.activeTransform.gameObject;
			if(!selObj.GetComponent<Collider>()){
				selObj.AddComponent<BoxCollider>();
			}
			selObj.AddComponent<VNK_SoundSettings>();
			VNK_SoundSettings soundButtonComp = selObj.GetComponent<VNK_SoundSettings>();
			soundButtonComp.soundType = VNK_SoundSettings.SoundTypeEnum.OtherFx;
			if(selObj.GetComponent<SpriteRenderer>()){
				soundButtonComp.buttonSprite = selObj.GetComponent<SpriteRenderer>();
				soundButtonComp.spriteReleased = selObj.GetComponent<SpriteRenderer>().sprite;
			}
		}
		else{
			Debug.LogError("Please select a GameObject (one with a SpriteRender if possible)");
		}
	}
	
	[MenuItem("Tools/VNK Menu/Setup Other Settings Buttons/Setup DialogSpeed Button")]
	static void SetupSettingsButton_Other_DialogSpeed(){
		if(Selection.activeTransform){
			GameObject selObj = Selection.activeTransform.gameObject;
			if(!selObj.GetComponent<Collider>()){
				selObj.AddComponent<BoxCollider>();
			}
			selObj.AddComponent<VNK_OtherSettings>();
			VNK_OtherSettings otherButtonComp = selObj.GetComponent<VNK_OtherSettings>();
			otherButtonComp.buttonType = VNK_OtherSettings.OtherSettEnum.DialogSpeed;
			if(selObj.GetComponent<SpriteRenderer>()){
				otherButtonComp.buttonSprite = selObj.GetComponent<SpriteRenderer>();
				otherButtonComp.spriteReleased = selObj.GetComponent<SpriteRenderer>().sprite;
			}
		}
		else{
			Debug.LogError("Please select a GameObject (one with a SpriteRender if possible)");
		}
	}
	
	[MenuItem("Tools/VNK Menu/Setup Other Settings Buttons/Setup AutoSpeed Button")]
	static void SetupSettingsButton_Other_AutoSpeed(){
		if(Selection.activeTransform){
			GameObject selObj = Selection.activeTransform.gameObject;
			if(!selObj.GetComponent<Collider>()){
				selObj.AddComponent<BoxCollider>();
			}
			selObj.AddComponent<VNK_OtherSettings>();
			VNK_OtherSettings otherButtonComp = selObj.GetComponent<VNK_OtherSettings>();
			otherButtonComp.buttonType = VNK_OtherSettings.OtherSettEnum.AutoDialogSpeed;
			if(selObj.GetComponent<SpriteRenderer>()){
				otherButtonComp.buttonSprite = selObj.GetComponent<SpriteRenderer>();
				otherButtonComp.spriteReleased = selObj.GetComponent<SpriteRenderer>().sprite;
			}
		}
		else{
			Debug.LogError("Please select a GameObject (one with a SpriteRender if possible)");
		}
	}
	
	[MenuItem("Tools/VNK Menu/Setup Other Settings Buttons/Setup SetFullscreen Button")]
	static void SetupSettingsButton_Other_SetFullscreen(){
		if(Selection.activeTransform){
			GameObject selObj = Selection.activeTransform.gameObject;
			if(!selObj.GetComponent<Collider>()){
				selObj.AddComponent<BoxCollider>();
			}
			selObj.AddComponent<VNK_OtherSettings>();
			VNK_OtherSettings otherButtonComp = selObj.GetComponent<VNK_OtherSettings>();
			otherButtonComp.buttonType = VNK_OtherSettings.OtherSettEnum.SetFullscreen;
			if(selObj.GetComponent<SpriteRenderer>()){
				otherButtonComp.buttonSprite = selObj.GetComponent<SpriteRenderer>();
				otherButtonComp.spriteReleased = selObj.GetComponent<SpriteRenderer>().sprite;
			}
		}
		else{
			Debug.LogError("Please select a GameObject (one with a SpriteRender if possible)");
		}
	}
}