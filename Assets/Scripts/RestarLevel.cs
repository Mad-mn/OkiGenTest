using UnityEngine.SceneManagement;
using UnityEngine;

public class RestarLevel : MonoBehaviour
{
    public void restart()
    {
        ScreenController.isGameOver = false;
        ScreenController.isLvlPassed = false;
        PlayerController.isTouch = false;
        PlayerController.isOnOC = false;
       
        CoinCount.count = 0;
        
        SceneManager.LoadScene(0);
    }
}
