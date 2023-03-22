using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetPrefs : MonoBehaviour
{
    // Start is called before the first frame update
    public void resetPreferences()
    {
        PlayerPrefs.SetInt("Kills", 0);
        PlayerPrefs.SetInt("Combo", 0);
    }
}
