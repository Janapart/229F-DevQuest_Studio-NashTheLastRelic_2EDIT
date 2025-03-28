using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager1 : MonoBehaviour
{
    public void RestartGame()
    {
        HealthManager.instance.ResetLives(); // รีเซ็ตจำนวนชีวิต
        SceneManager.LoadScene("DemoMAP_version1");
        Debug.Log("awdawd"); // โหลดซีนหลักใหม่
    }
}
