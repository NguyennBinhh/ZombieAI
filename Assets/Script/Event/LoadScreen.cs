
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScreen : MonoBehaviour
{
    [SerializeField] private AudioManager _AudioManager;
    
    public void ChangeScreen(string Name)
    {
         SceneManager.LoadScene(Name);
        _AudioManager.PlaySFX(_AudioManager.ClickClip);
        Time.timeScale = 1;
    }   
    

}
