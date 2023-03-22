using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public void setPref()
    {
        PlayerPrefs.SetInt("Level", 1);
        PlayerPrefs.SetInt("Kills", 0);
        PlayerPrefs.SetInt("Combo", 0);
    }
}
