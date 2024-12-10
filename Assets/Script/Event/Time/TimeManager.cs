using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float Elsetime;
    [SerializeField] private TextMeshProUGUI text;
    private void Update()
    {
        Elapsed_Time();
    }
    public void Elapsed_Time()
    {
        Elsetime += Time.deltaTime;
        text.text = Elsetime.ToString();
        int minutes = Mathf.FloorToInt(Elsetime / 60);
        int second = Mathf.FloorToInt(Elsetime % 60);
        text.text = string.Format("{0:00}:{1:00}", minutes, second);
    }
}
