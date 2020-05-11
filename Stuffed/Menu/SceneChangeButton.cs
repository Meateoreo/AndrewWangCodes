using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeButton : MonoBehaviour
{
	 public void LoadSceneOnClick(string level)
     {
    	SceneManager.LoadScene(level);
	 }
		
}
