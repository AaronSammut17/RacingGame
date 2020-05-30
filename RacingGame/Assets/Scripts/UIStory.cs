using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIStory : MonoBehaviour
{
    // variable
    public static int Story = 0;
    public GameObject girl1;
    public GameObject girl2;
    public GameObject girl3;
    public GameObject girl4;
    

    // Update is called once per frame
    void Update()
    {
        if(Story == 1){
            girl1.SetActive(true);
            if(Input.GetKeyDown("space")){
                SceneManager.LoadScene (4);
            }
        }
        if(Story == 2){
            girl2.SetActive(true);
            if(Input.GetKeyDown("space")){
                SceneManager.LoadScene (5);
            }
        }
        if(Story == 3){
            girl3.SetActive(true);
            if(Input.GetKeyDown("space")){
                SceneManager.LoadScene (6);
            }
        }
        if(Story == 4){
            girl4.SetActive(true);
            if(Input.GetKeyDown("space")){
                SceneManager.LoadScene (7);
            }
        }
    }
}
