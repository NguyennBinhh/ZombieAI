using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadRanking : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] TxtRank;

    private void Awake()
    {
        ResetText();
        LoadTimeRanking();
    }
    private void ResetText()
    {
        for (int i = 0; i < 5; i++)
        {
            TxtRank[i].text = "";
        }  
    }

    private void LoadTimeRanking()
    {
        int minutes = 0;
        int second = 0;
        for (int i = 0; i < 5; i++)
        {
            if(PlayerPrefs.HasKey("Time_" + i))
            {
                minutes = Mathf.FloorToInt(PlayerPrefs.GetFloat("Time_" + i) / 60);
                second = Mathf.FloorToInt(PlayerPrefs.GetFloat("Time_" + i) % 60);
                TxtRank[i].text = minutes + "min" + second + "sec";
            }    
        }
    }    
    
}
