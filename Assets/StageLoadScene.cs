using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StageLoadScene : MonoBehaviour
{
    public void Stage1LoadSceneBtn()
    {
        SceneManager.LoadScene("SampleScene"); 
    }
}
