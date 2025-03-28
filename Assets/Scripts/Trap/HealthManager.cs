using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
 public static HealthManager instance;

    public int maxLives = 3; // จำนวนชีวิตสูงสุด
    private int currentLives;

    public Text livesText; // UI แสดงจำนวนชีวิต

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // ป้องกันการรีเซ็ต HealthManager เมื่อโหลดซีนใหม่
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        if (PlayerPrefs.HasKey("CurrentLives"))
        {
            currentLives = PlayerPrefs.GetInt("CurrentLives"); // โหลดค่าชีวิตที่เหลือจาก PlayerPrefs
            
        }
        else
        {
            currentLives = maxLives; // ตั้งค่าชีวิตเริ่มต้น
        }
    }

    void Start()
    {
        UpdateLivesUI();
    }

    public void LoseLife()
    {
        currentLives--; // ลดชีวิตลง 1
        PlayerPrefs.SetInt("CurrentLives", currentLives); // บันทึกค่าชีวิตไว้
        PlayerPrefs.Save();

        UpdateLivesUI();

        if (currentLives <= 0)
        {
            PlayerPrefs.DeleteKey("CurrentLives"); // ลบค่าชีวิตเมื่อเกมโอเวอร์
            SceneManager.LoadScene("GameOver"); // ไปที่ซีน "Game Over"
        }
        else
        {
            RestartLevel(); // โหลดซีนใหม่แต่ไม่รีเซ็ตชีวิต
        }
    }

    void UpdateLivesUI()
    {
        if (livesText != null)
            livesText.text = "" + currentLives;
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ResetLives()
    {
        currentLives = maxLives;
        PlayerPrefs.SetInt("CurrentLives", currentLives); // รีเซ็ตค่าชีวิตใน PlayerPrefs
        PlayerPrefs.Save();
        UpdateLivesUI();
    }
    public void RestartGame()
    {
    HealthManager.instance.ResetLives(); // รีเซ็ตชีวิต
    SceneManager.LoadScene("DemoMAP_version1");
    }
}
