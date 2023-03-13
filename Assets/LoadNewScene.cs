using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update

    private void Start()
    {
       
       
    }
    public void play()
    {
        DontDestroyOnLoad(GameObject.Find("startRoom"));
        SceneManager.LoadScene("Jeu");
        
    }

 
}
