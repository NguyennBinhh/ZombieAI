
using UnityEngine;

public class LoadHomeAnimation : MonoBehaviour
{
    [SerializeField] private GameObject[] Button;
    [SerializeField] private GameObject GemText;

    private void Start()
    {
        float a = 0;
        for (int i = 0; i < Button.Length; i++)
        {
            LeanTween.moveLocalX(Button[i], -592f, 1f + a).setEase(LeanTweenType.easeOutCubic);
            a += 0.2f;
        }
        LeanTween.moveLocalX(GemText, 761f, 1f).setEase(LeanTweenType.easeOutCubic);
    }
}
