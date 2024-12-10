using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerDie : MonoBehaviour
{
    [SerializeField] private Player_Animation _Player_Animation;
    [SerializeField] private HeathBar HeathPlayer;
    [SerializeField] private AudioManager _AudioManager;
    [SerializeField] private Camera CameraLookUp;
    [SerializeField] private Camera MainCamera;
    [SerializeField] private Canvas _Canvas;
    [SerializeField] private Player_Movement _Player_Movement;
    [SerializeField] private Player_ShotGunAR _Player_ShotGunAR;


    [SerializeField] private FormNotificationAnim _FormNotificationAnim;
    [SerializeField] private TextMeshProUGUI txtTime;
    [SerializeField] private SpawnEnemy _SpawnEnemy;

    private bool IsDie = false;
    private void Update()
    {
        Invoke("Player_Die", 4f);
    }

    private void Player_Die()
    {
        if (HeathPlayer == null)
            return;
        if(HeathPlayer.GetHealth() <= 0)
        {
            _Player_Movement.enabled = false;
            _Player_ShotGunAR.enabled = false;
            MainCamera.gameObject.SetActive(false);
            CameraLookUp.gameObject.SetActive(true);
            _Player_Animation.PlayerDie();
            _Canvas.worldCamera = CameraLookUp;
            gameObject.tag = "Die";
            if (!IsDie)
            {
                _AudioManager.PlaySFX(_AudioManager.PlayerDieClip);
                IsDie = true;
                StartCoroutine(GameEndWhenPlayerDie());
            }
            
        }
    }
    IEnumerator GameEndWhenPlayerDie()
    {
        yield return new WaitForSeconds(2f);
        _FormNotificationAnim.ShowNotification("GAME OVER", txtTime.text, _SpawnEnemy.CountEnemyKilled.ToString());
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0;
    }    
}
