using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FormNotificationAnim : MonoBehaviour
{
    [SerializeField] private GameObject FrmNotification;
    [SerializeField] private TextMeshProUGUI txtNotification;
    [SerializeField] private TextMeshProUGUI txtTime;
    [SerializeField] private TextMeshProUGUI txtKill;

    public void ShowNotification(string Notification, string time, string kill)
    {
        FrmNotification.SetActive(true);
        txtNotification.text = Notification;
        txtTime.text = time;
        txtKill.text = kill;
        LeanTween.scale(FrmNotification, new Vector3(1f, 1f, 1f), 0.5f).setDelay(0f).setEase(LeanTweenType.easeOutCubic);
    } 
    
    public void HideNotification()
    {
        FrmNotification.SetActive(false);
    }    
}
