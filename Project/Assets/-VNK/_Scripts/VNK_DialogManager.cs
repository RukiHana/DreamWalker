using UnityEngine;
using System.Collections;

public class VNK_DialogManager : MonoBehaviour {

	// GUI
	public bool debugResetSavedata;
	public GameObject dialogUI;
	public GameObject questionUI;
	public GameObject saveIcon;
	public GameObject nextButton;
	public GameObject saveButton;
	public GameObject loadButton;
	public GameObject autoButton;
	public GameObject settingButton;
	public TextMesh dialogText;
	public TextMesh nameText;
	public TextMesh question01Text;
	public TextMesh question02Text;
	public TextMesh question03Text;
	public TextMesh question04Text;
	public GameObject question01Obj;
	public GameObject question02Obj;
	public GameObject question03Obj;
	public GameObject question04Obj;
	public SpriteRenderer background01;
	public SpriteRenderer background02;
	public AudioSource bgAmbience;
	public AudioSource bgFX;
	public AudioSource bgMusic;
	public AudioSource charaVoice;
	public AudioSource gameplayFX;
	public float baseDialogSpeed = 0.05f;
	public float maxDialogSpeed = 0.1f; //Lower is faster
	public float minAutoDialogSpeed = 1.0f;
	public float maxAutoDialogSpeed = 20.0f;

	// These var determinate if a dialog is playing
	public static bool isEnabled;
	public static int privateID;
	public static GameObject currentDialog;

	// static GUI
	public static GameObject staticDialogUI;
	public static GameObject staticQuestionUI;
	public static TextMesh staticDialogText;
	public static TextMesh staticNameText;
	public static TextMesh staticQuestion01Text;
	public static TextMesh staticQuestion02Text;
	public static TextMesh staticQuestion03Text;
	public static TextMesh staticQuestion04Text;
	public static GameObject staticQuestion01Obj;
	public static GameObject staticQuestion02Obj;
	public static GameObject staticQuestion03Obj;
	public static GameObject staticQuestion04Obj;
	public static GameObject staticNextButton;
	public static GameObject staticSaveButton;
	public static GameObject staticLoadButton;
	public static GameObject staticAutoButton;
	public static GameObject staticSettingButton;
	public static GameObject staticDialogTextObj;
	public static SpriteRenderer staticBackground01;
	public static SpriteRenderer staticBackground02;
	public static AudioSource staticBgAmbience;
	public static AudioSource staticBgFX;
	public static AudioSource staticBgMusic;
	public static AudioSource staticCharaVoice;
	public static AudioSource staticGameplayFX;
	public static GameObject thisObj;
	public static float dialogSpeed;
	public static bool isFullscreen;
	public static float staticMaxDialogSpeed;
	public static bool showSettingMenu;
	public static bool autoGoToNextScreen;
	public static float staticMinAutoDialogSpeed;
	public static float staticMaxAutoDialogSpeed;
	public static float currentAutoDialogSpeed;

	
	// Use this for initialization
	void Awake(){
		thisObj = gameObject;
		background02.color = new Color(background02.color.r, background02.color.g, background02.color.b, 0.0f);
		
		if(PlayerPrefs.HasKey("kayLastID")){
			privateID = PlayerPrefs.GetInt("kayLastID");
		}
		else{
			privateID = 0;
		}

		if(PlayerPrefs.HasKey("keyDialogSpeed")){
			dialogSpeed = PlayerPrefs.GetFloat("keyDialogSpeed");
		}
		else{
			dialogSpeed = baseDialogSpeed;
		}

		if(PlayerPrefs.HasKey("keyAutoDialogSpeed")){
			currentAutoDialogSpeed = PlayerPrefs.GetFloat("keyAutoDialogSpeed");
		}
		else{
			currentAutoDialogSpeed = 7.0f;
		}

		//GUI
		staticDialogUI = dialogUI;
		staticQuestionUI = questionUI;

		staticDialogText = dialogText;
		staticNameText = nameText;

		staticQuestion01Text = question01Text;
		staticQuestion02Text = question02Text;
		staticQuestion03Text = question03Text;
		staticQuestion04Text = question04Text;

		staticQuestion01Obj = question01Obj;
		staticQuestion02Obj = question02Obj;
		staticQuestion03Obj = question03Obj;
		staticQuestion04Obj = question04Obj;

		staticBackground01 = background01;
		staticBackground02 = background02;

		staticNextButton = nextButton;
		staticSaveButton = saveButton;
		staticLoadButton = loadButton;
		staticAutoButton = autoButton;
		staticSettingButton = settingButton;

		staticBgAmbience = bgAmbience;
		staticBgFX = bgFX;
		staticBgMusic = bgMusic;
		staticCharaVoice = charaVoice;
		staticGameplayFX = gameplayFX;

		staticMaxDialogSpeed = maxDialogSpeed;
		
		staticMinAutoDialogSpeed = minAutoDialogSpeed;
		staticMaxAutoDialogSpeed = maxAutoDialogSpeed;
	}

	void Update(){
      

		if(Input.GetKeyUp(KeyCode.G) && debugResetSavedata){
			ResedSavedata();
		}

		if(PlayerPrefs.HasKey("keyBgAmbienceVolume")){
			staticBgAmbience.volume = PlayerPrefs.GetFloat("keyBgAmbienceVolume");
		}
		if(PlayerPrefs.HasKey("keyBgFXVolume")){
			staticBgFX.volume = PlayerPrefs.GetFloat("keyBgFXVolume");
		}
		if(PlayerPrefs.HasKey("keyBgMusicVolume")){
		//	staticBgMusic.volume = PlayerPrefs.GetFloat("keyBgMusicVolume");
		}
		if(PlayerPrefs.HasKey("keyCharaVoiceVolume")){
			staticCharaVoice.volume = PlayerPrefs.GetFloat("keyCharaVoiceVolume");
		}
		if(PlayerPrefs.HasKey("keyGameplayFXVolume")){
			staticGameplayFX.volume = PlayerPrefs.GetFloat("keyGameplayFXVolume");
		}
		
		if(PlayerPrefs.HasKey("keyAutoDialogSpeed")){
			currentAutoDialogSpeed = PlayerPrefs.GetFloat("keyAutoDialogSpeed");
		}

		if(PlayerPrefs.HasKey("keyIsFullscreen")){
			isFullscreen = LoadBool("keyIsFullscreen");
		}
	}

	public static void SaveSavedata(){
		thisObj.GetComponent<VNK_DialogManager>().StartCoroutine("Private_SaveSavedata");
	}
	IEnumerator Private_SaveSavedata(){
		iTween.ScaleTo(saveIcon, new Vector3(1.0f, 1.0f, 1.0f), 1.0f);

		yield return new WaitForSeconds(1.0f);

		iTween.ShakeScale(saveIcon, new Vector3(0.1f, 0.1f, 0.1f), 1.0f);
		
		yield return new WaitForSeconds(1.0f);
		
		iTween.ScaleTo(saveIcon, new Vector3(0.0f, 0.0f, 0.0f), 1.0f);
		PlayerPrefs.SetInt("kayLastID", privateID);
	}

	public static void LoadSavedata(){
		thisObj.GetComponent<VNK_DialogManager>().StartCoroutine("Private_LoadSavedata");
	}
	IEnumerator Private_LoadSavedata(){
		iTween.ScaleTo(saveIcon, new Vector3(1.0f, 1.0f, 1.0f), 1.0f);
		
		yield return new WaitForSeconds(1.0f);
		
		iTween.ShakeScale(saveIcon, new Vector3(0.1f, 0.1f, 0.1f), 1.0f);
		
		yield return new WaitForSeconds(1.0f);
		
		iTween.ScaleTo(saveIcon, new Vector3(0.0f, 0.0f, 0.0f), 1.0f);
		
		if(PlayerPrefs.HasKey("kayLastID")){
			privateID = PlayerPrefs.GetInt("kayLastID");
		}
		else{
			privateID = 0;
		}
	}
	
	public static void ResedSavedata(){
		PlayerPrefs.DeleteAll();
	}
	
	// 1 is true 0 is false
	public static void SaveBool(string keyToSave, bool value){
		if(value){
			PlayerPrefs.SetInt(keyToSave, 1);
		}
		else{
			PlayerPrefs.SetInt(keyToSave, 0);
		}
	}
	public static bool LoadBool(string keyToLoad){
		int boolInt = PlayerPrefs.GetInt(keyToLoad);
		
		if(boolInt == 0){
			return false;
		}
		else if(boolInt == 1){
			return true;
		}
		return false;
	}
}