using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FormSettingAnimation : MonoBehaviour
{
    [SerializeField] private GameObject BackFrmSetting;
    [SerializeField] private GameObject FrmSetting;
    [SerializeField] private GameObject BackFrmRanking;
    [SerializeField] private GameObject FrmRanking;
    [SerializeField] private AudioManager _AudioManager;

    public void ShowFormSetting()
    {
        BackFrmSetting.SetActive(true);
        LeanTween.moveLocal(FrmSetting, new Vector3(-7.63f, 0, 0), .2f).setDelay(0f).setEase(LeanTweenType.easeOutCubic);
        _AudioManager.PlaySFX(_AudioManager.ClickClip);
    }

    public void HideFormSetting()
    {
        
        LeanTween.moveLocal(FrmSetting, new Vector3(-7.63f, 865f, 0), .2f).setDelay(0f).setEase(LeanTweenType.easeOutCubic);
        BackFrmSetting.SetActive(false);
        _AudioManager.PlaySFX(_AudioManager.ClickClip);
    }

    public void ShowFormRanking()
    {
        BackFrmRanking.SetActive(true);
        LeanTween.moveLocal(FrmRanking, new Vector3(-7.63f, 0, 0), .2f).setDelay(0f).setEase(LeanTweenType.easeOutCubic);
        _AudioManager.PlaySFX(_AudioManager.ClickClip);
    }

    public void HideFormRanking()
    {

        LeanTween.moveLocal(FrmRanking, new Vector3(-7.63f, 865f, 0), .2f).setDelay(0f).setEase(LeanTweenType.easeOutCubic);
        BackFrmRanking.SetActive(false);
        _AudioManager.PlaySFX(_AudioManager.ClickClip);
    }
}
