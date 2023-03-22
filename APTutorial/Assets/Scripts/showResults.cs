using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showResults : MonoBehaviour
{
    public Text time;
    public Text combo;
    public Text kills;
    // Start is called before the first frame update
    void Start()
    {
        time.text += PlayerPrefs.GetFloat("Time").ToString();
        int com = PlayerPrefs.GetInt("Combo");
        combo.text += com.ToString();
        kills.text += PlayerPrefs.GetInt("Kills").ToString();
    }

}
