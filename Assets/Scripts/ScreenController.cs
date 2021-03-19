using UnityEngine.UI;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    public GameObject StartScreen, InGameScreen, LvlPassedScreen, GOScreen;
    private bool isStart;
    public static bool isGameOver, isLvlPassed;
    public Text coinCount;
    public Animator anim;
   

    private void Update()
    {
        if (PlayerController.isTouch && !isStart)
        {
            isStart = true;
            StartScreen.SetActive(false);
            InGameScreen.SetActive(true);
        }
        if (isGameOver)
        {
            anim.SetTrigger("Loose");
            InGameScreen.SetActive(false);
            GOScreen.SetActive(true);
        }
        if (isLvlPassed)
        {
            InGameScreen.SetActive(false);
            LvlPassedScreen.SetActive(true);
        }
        
        coinCount.text = CoinCount.count.ToString();
    }
}
