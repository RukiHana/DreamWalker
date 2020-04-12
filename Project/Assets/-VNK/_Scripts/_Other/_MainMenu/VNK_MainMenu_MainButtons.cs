using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class VNK_MainMenu_MainButtons : MonoBehaviour {
	
	public enum MainButtonEnum {NewGameButton, LoadGame, OpenSettingsButton, CloseSettingsButton}
	public MainButtonEnum buttonType = MainButtonEnum.NewGameButton;

	public TextMesh buttonTextMesh;
	public SpriteRenderer buttonSprite;
	public Sprite spriteReleased;
	public Sprite spritePressed;
	public AudioClip buttonPressAudio;
	public string newGame_LevelToLoad;
	public GameObject settingMenu;
	
	private AudioSource thisAudioSource;
	private VNK_FadeCamera camFadeComp;
	private string loadGame_LevelToLoad;
	
	private bool calledNewGame;
	private bool calledLoadGame;


	// Use this for initialization
	void Start(){
		calledNewGame = false;
		calledLoadGame = false;

		thisAudioSource = gameObject.GetComponent<AudioSource>();
		camFadeComp = Camera.main.GetComponent<VNK_FadeCamera>();
	}
	
	// Update is called once per frame
	void Update(){
		if(PlayerPrefs.HasKey("keyLastLevel")){
			loadGame_LevelToLoad = PlayerPrefs.GetString("keyLastLevel");
		}
		else{
			loadGame_LevelToLoad = null;
		}

		if(calledNewGame && camFadeComp.alpha >= 1.0f && buttonType == MainButtonEnum.NewGameButton){
			Application.LoadLevel(newGame_LevelToLoad);
		}

		if(buttonType == MainButtonEnum.LoadGame){
			if(loadGame_LevelToLoad == null){
				if(buttonSprite != null){
					buttonSprite.color = new Color(buttonSprite.color.r, buttonSprite.color.g, buttonSprite.color.b, 0.5f);
				}
				if(buttonTextMesh != null){
					buttonTextMesh.color = new Color(buttonTextMesh.color.r, buttonTextMesh.color.g, buttonTextMesh.color.b, 0.5f);
				}
			}
			else{
				if(buttonSprite != null){
					buttonSprite.color = new Color(buttonSprite.color.r, buttonSprite.color.g, buttonSprite.color.b, 1.0f);
				}
				if(buttonTextMesh != null){
					buttonTextMesh.color = new Color(buttonTextMesh.color.r, buttonTextMesh.color.g, buttonTextMesh.color.b, 1.0f);
				}

				if(calledLoadGame && camFadeComp.alpha >= 1.0f){
					Application.LoadLevel(loadGame_LevelToLoad);
				}
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
		if(buttonType == MainButtonEnum.NewGameButton && !calledNewGame && !calledLoadGame){
			if(buttonSprite != null){
				buttonSprite.sprite = spriteReleased;
			}
			if(buttonPressAudio){
				thisAudioSource.PlayOneShot(buttonPressAudio);
			}
			
			camFadeComp.FadeOut();
			calledNewGame = true;
		}
		else if(buttonType == MainButtonEnum.LoadGame && !calledNewGame && !calledLoadGame && loadGame_LevelToLoad != null){
			if(buttonSprite != null){
				buttonSprite.sprite = spriteReleased;
			}
			if(buttonPressAudio){
				thisAudioSource.PlayOneShot(buttonPressAudio);
			}
			
			camFadeComp.FadeOut();
			calledLoadGame = true;
		}
		else if(buttonType == MainButtonEnum.OpenSettingsButton && !calledNewGame && !calledLoadGame){
			if(buttonSprite != null){
				buttonSprite.sprite = spriteReleased;
			}
			if(buttonPressAudio){
				thisAudioSource.PlayOneShot(buttonPressAudio);
			}

			settingMenu.SetActive(true);
		}
		else if(buttonType == MainButtonEnum.CloseSettingsButton && !calledNewGame && !calledLoadGame){
			if(buttonSprite != null){
				buttonSprite.sprite = spriteReleased;
			}
			if(buttonPressAudio){
				thisAudioSource.PlayOneShot(buttonPressAudio);
			}

			settingMenu.SetActive(false);
		}
	}

	void HandleButtonDown(){
		if(buttonType == MainButtonEnum.NewGameButton && !calledNewGame && !calledLoadGame){
			if(buttonSprite != null){
				buttonSprite.sprite = spritePressed;
			}
		}
		else if(buttonType == MainButtonEnum.LoadGame && !calledNewGame && !calledLoadGame && loadGame_LevelToLoad != null){
			if(buttonSprite != null){
				buttonSprite.sprite = spritePressed;
			}
		}
		else if(buttonType == MainButtonEnum.OpenSettingsButton && !calledNewGame && !calledLoadGame){
			if(buttonSprite != null){
				buttonSprite.sprite = spritePressed;
			}
		}
		else if(buttonType == MainButtonEnum.CloseSettingsButton && !calledNewGame && !calledLoadGame){
			if(buttonSprite != null){
				buttonSprite.sprite = spritePressed;
			}
		}
	}
}
