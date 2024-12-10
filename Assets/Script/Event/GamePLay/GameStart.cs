using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameStart : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI TxtNotification;
    [SerializeField] private GameObject TxtNotificationGameObj;
    [SerializeField] private AudioManager _AudioManager;
    [SerializeField] private GameObject[] ListPostion;
    [SerializeField] private FormNotificationAnim _FormNotificationAnim;
    [SerializeField] private SpawnEnemy _SpawnEnemy;
    [SerializeField] private TextMeshProUGUI TextCountEnemy;
    [SerializeField] private TextMeshProUGUI txtTime;
    [SerializeField] private TimeManager _TimeManager;
    [SerializeField] private TextMeshProUGUI Txt_Round;

    private bool IsRound1Complete;
    private bool IsRound2Complete;
    private bool IsRound3Complete;
    private bool StartNewRound;


    private void Start()
    {
        IsRound1Complete = false;
        IsRound2Complete = false;
        IsRound3Complete  = false;
        StartNewRound = false;
        StartCoroutine(Game_Start());
        

    }
    private void Update()
    {
        TextCountEnemy.text = "ENEMY: " + _SpawnEnemy.CountEnemy.ToString();
        Invoke("Round2Start",9f);
        Invoke("Round3Start", 9f);
        GameComplete();
    }

    IEnumerator Game_Start()
    {
        Txt_Round.text = "ROUND: 1";
        TxtNotificationGameObj.SetActive(true);
        TxtNotification.text = "Round 1";
        yield return new WaitForSeconds(4f);
        TxtNotification.text = "3";
        _AudioManager.PlaySFX(_AudioManager.CountdownClip);
        yield return new WaitForSeconds(1f);
        TxtNotification.text = "2";
        yield return new WaitForSeconds(1f);
        TxtNotification.text = "1";
        yield return new WaitForSeconds(1f);
        TxtNotification.text = "FIGHT";
        yield return new WaitForSeconds(0.5f);
        TxtNotificationGameObj.SetActive(false);
        for (int i = 0; i < 5; i++)
        {
            _SpawnEnemy.Spawn(ListPostion[1].transform.position, 5);
            _SpawnEnemy.Spawn(ListPostion[2].transform.position, 5);
            _SpawnEnemy.Spawn(ListPostion[3].transform.position, 5);
            Debug.Log(_SpawnEnemy.CountEnemy.ToString());
            yield return new WaitForSeconds(1f);
        }
        IsRound1Complete = true;
        StartNewRound = true;

    }

    private void Round2Start()
    {
        if(_SpawnEnemy.CountEnemy == 0 && IsRound1Complete && !IsRound2Complete && StartNewRound)
        {
            IsRound2Complete = true;
            StartNewRound = false;
            StartCoroutine(Round2());
        }
    }

    IEnumerator Round2()
    {
        Txt_Round.text = "ROUND: 2";
        TxtNotificationGameObj.SetActive(true);
        TxtNotification.text = "Round 2";
        yield return new WaitForSeconds(4f);
        TxtNotification.text = "3";
        _AudioManager.PlaySFX(_AudioManager.CountdownClip);
        yield return new WaitForSeconds(1f);
        TxtNotification.text = "2";
        yield return new WaitForSeconds(1f);
        TxtNotification.text = "1";
        yield return new WaitForSeconds(1f);
        TxtNotification.text = "FIGHT";
        yield return new WaitForSeconds(0.5f);
        TxtNotificationGameObj.SetActive(false);
        for (int i = 0; i < 6; i++)
        {
            _SpawnEnemy.Spawn(ListPostion[1].transform.position, 6);
            _SpawnEnemy.Spawn(ListPostion[2].transform.position, 6);
            _SpawnEnemy.Spawn(ListPostion[3].transform.position, 6);
            _SpawnEnemy.Spawn(ListPostion[4].transform.position, 6);
            
            yield return new WaitForSeconds(1f);
        }
        StartNewRound = true;

    }

    private void Round3Start()
    {
        if (_SpawnEnemy.CountEnemy == 0 && IsRound2Complete && IsRound1Complete && !IsRound3Complete && StartNewRound)
        {
            IsRound3Complete = true;
            StartNewRound = false;
            StartCoroutine(Round3());
        }
    }

    IEnumerator Round3()
    {
        Txt_Round.text = "ROUND: 3";
        TxtNotificationGameObj.SetActive(true);
        TxtNotification.text = "Round 3";
        yield return new WaitForSeconds(4f);
        TxtNotification.text = "3";
        _AudioManager.PlaySFX(_AudioManager.CountdownClip);
        yield return new WaitForSeconds(1f);
        TxtNotification.text = "2";
        yield return new WaitForSeconds(1f);
        TxtNotification.text = "1";
        yield return new WaitForSeconds(1f);
        TxtNotification.text = "FIGHT";
        yield return new WaitForSeconds(0.5f);
        TxtNotificationGameObj.SetActive(false);
        for (int i = 0; i < 7; i++)
        {
            _SpawnEnemy.Spawn(ListPostion[1].transform.position, 7);
            _SpawnEnemy.Spawn(ListPostion[2].transform.position, 7);
            _SpawnEnemy.Spawn(ListPostion[3].transform.position, 7);
            _SpawnEnemy.Spawn(ListPostion[4].transform.position, 7);
            _SpawnEnemy.Spawn(ListPostion[0].transform.position, 7);
            
            yield return new WaitForSeconds(1f);
        }
        StartNewRound = true;


    }
    private void GameComplete()
    {
        if (_SpawnEnemy.CountEnemy == 0 && IsRound2Complete && IsRound1Complete && IsRound3Complete && StartNewRound)
        {
            
            StartCoroutine(Victory());
            StartNewRound = false;

        }
    }
    IEnumerator Victory()
    {
        _FormNotificationAnim.ShowNotification("VICTORY", txtTime.text, _SpawnEnemy.CountEnemyKilled.ToString());
        _AudioManager.PlaySFX(_AudioManager.GameCompleClip);
        float timecompl = _TimeManager.Elsetime;
        TimeRating.Ins.RakingTime(timecompl);
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0;

    }

}
