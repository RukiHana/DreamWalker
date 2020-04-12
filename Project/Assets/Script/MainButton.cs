using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainButton : MonoBehaviour {

	public void newGame()
    {
        SceneManager.LoadScene("scenario1");
    }
}
