using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public static string previousLevel;

	public void LoadLevel(string name){
		
		previousLevel = SceneManager.GetActiveScene ().name;
		SceneManager.LoadScene (name);
	}
		
	public void LoadNextLevel(){
		
		previousLevel = SceneManager.GetActiveScene ().name;
		int nextLevel = SceneManager.GetActiveScene ().buildIndex + 1;
		SceneManager.LoadScene (nextLevel);
	}

	public void LoadPreviousLevel(){

		SceneManager.LoadScene (previousLevel);
	}

	public void QuitRequest(){

		Application.Quit ();
	}

}

