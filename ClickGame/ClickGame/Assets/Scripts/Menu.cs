using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor; 


[DefaultExecutionOrder(1000)]
public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartNew() 
    {
        SceneManager.LoadScene(1); 
    }

    public void BackMenu() 
    {
        SceneManager.LoadScene(0); 
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Exit() 
    {
      //Application.Quit;
    }
}