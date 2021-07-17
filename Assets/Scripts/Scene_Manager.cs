using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Scene_Manager : MonoBehaviour {
    public void ChangeScene(){
        //index=0
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void Exit(){
        Application.Quit();
    }
}






