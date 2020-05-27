using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sound : MonoBehaviour
{
    private static Sound instance = null;
    public static Sound Instance{
        get{ return instance;}
    }

    void Awake(){
        if (instance != null && instance != this){

            Destroy(this.gameObject);
            return;

        } else{

            instance = this;

        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Update(){
        Scene currentScene = SceneManager.GetActiveScene ();
 
        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName == "Track1"){
            Destroy(this.gameObject);
        }
        if (sceneName == "Track2"){
            Destroy(this.gameObject);
        }
        if (sceneName == "Track3"){
            Destroy(this.gameObject);
        }
    }
    
}
