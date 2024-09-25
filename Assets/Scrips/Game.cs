using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
   public void Menu()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
       Application.Quit(); 
    }
}
