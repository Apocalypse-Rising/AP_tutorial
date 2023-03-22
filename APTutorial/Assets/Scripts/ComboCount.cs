using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboCount : MonoBehaviour
{
    public int comboNum;
    public Text combo;
    public float startTime;
    public float currentTime;
    private int lastNum;
    private bool check;
    // Start is called before the first frame update
    void Start()
    {
        combo.text = "";
        startTime = Time.time;
        currentTime = Time.time;
        lastNum = comboNum;
        check = true;
    }

    // Update is called once per frame
    void Update()
    {
        int bigCombo = PlayerPrefs.GetInt("Combo");
        if (bigCombo < comboNum)
        {
            PlayerPrefs.SetInt("Combo", comboNum);
            PlayerPrefs.Save();
        }
        if ((comboNum > 0 && (currentTime - startTime) < 3 && comboNum > lastNum) || (check == true && comboNum == 1))
        {
            combo.text = "Combo: " + comboNum + "x";
            startTime = Time.time;
            check = false;
        } else if (comboNum > 1 && (currentTime - startTime) > 3)
        {
            comboNum = 0;
            combo.text = "";
            startTime = Time.time;
        }
        lastNum = comboNum;
        currentTime = Time.time;
        
    }
}
