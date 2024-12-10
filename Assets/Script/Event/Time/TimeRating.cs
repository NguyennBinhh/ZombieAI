using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class TimeRating : MonoBehaviour
{
    private float TimeComple;
    private List<float> ListTime = new List<float>();
    public static TimeRating Ins;

    private void Awake()
    {
        Ins = this;
        LoadRanking();
    }

    public void RakingTime(float Time)
    {
        ListTime.Add(Time);
        ListTime.Sort((a,b) => a.CompareTo(b));
        if (ListTime.Count > 5)
            ListTime.RemoveAt(ListTime.Count - 1);
        SaveRanking();
        
    }
    private void SaveRanking()
    {
        for (int i = 0; i < ListTime.Count; i++)
        {
            PlayerPrefs.SetFloat("Time_" + i, ListTime[i]);
        }
        PlayerPrefs.SetInt("TimeCount", ListTime.Count);
        LoadRanking();
        PlayerPrefs.Save();
    }

    private void LoadRanking()
    {
        ListTime.Clear(); 
        int count = PlayerPrefs.GetInt("TimeCount");

        for (int i = 0; i < count; i++)
        {
            float time = PlayerPrefs.GetFloat("Time_" + i);
            ListTime.Add(time);
        }

        
    }
}
