using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlManager : MonoBehaviour
{
    public void Play () {
        SceneManager.LoadScene (1);
    }
    public void MainMenu () {
        SceneManager.LoadScene(0);
    }

    // loading the tracks.
    public void Track1 () {
        SceneManager.LoadScene (2);
    }
    public void Track2 () {
        SceneManager.LoadScene (3);
    }
    public void Track3 () {
        SceneManager.LoadScene (4);
    }

}
