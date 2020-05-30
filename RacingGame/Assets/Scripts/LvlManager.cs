using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlManager : MonoBehaviour
{
    
    public void MainMenu () {
        SceneManager.LoadScene(0);
    }
    public void Instructions () {
       SceneManager.LoadScene(1);
    }
    public void Maps () {
        SceneManager.LoadScene (2);
    }
    public void Quit () {
        Application.Quit();
    }
    

    // loading the tracks story.
    public void Track1Story () {
        UIStory.Story = 1;
        SceneManager.LoadScene (3);
    }
    public void Track2Story () {
        UIStory.Story = 2;
        SceneManager.LoadScene (3);
    }
    public void Track3Story () {
        UIStory.Story = 3;
        SceneManager.LoadScene (3);
    }
    public void Track4Story () {
        UIStory.Story = 4;
        SceneManager.LoadScene (3);
    }

    // loading the tracks.
    public void Track1 () {
        SceneManager.LoadScene (4);
    }
    public void Track2 () {
        SceneManager.LoadScene (5);
    }
    public void Track3 () {
        SceneManager.LoadScene (6);
    }
    public void Track4 () {
        SceneManager.LoadScene (7);
    }
}
