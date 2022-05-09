using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TebP : MonoBehaviour
{
    public List<TebBtn> tabBtn;
    public List<GameObject> contentsP;

    public void ClickTeb (int id)
    {
        for(int i = 0; i< contentsP.Count; i++)
        {
            if(i == id)
            {
                contentsP[i].SetActive(true);
            }
            else
            {
                contentsP[i].SetActive(false);
            }
        }
    }
}
