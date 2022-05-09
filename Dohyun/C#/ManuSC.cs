using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManuSC : MonoBehaviour
{
    public void MainMenuBtn()
    {
        switch (this.gameObject.name)
        {
            case "MainMenuBtn":
                SceneManager.LoadScene("MainMenu");
                break;
        }
    }

}
