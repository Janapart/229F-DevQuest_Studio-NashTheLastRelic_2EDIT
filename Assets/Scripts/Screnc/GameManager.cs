using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float playTime; // เก็บเวลาเล่น
    public int collectedGems; // เก็บจำนวนเพชรที่เก็บได้
    public Text timeText; // UI แสดงเวลา
    public Text gemText;  // UI แสดงจำนวนเพชร
    public Text summaryText; // UI แสดงสรุปเมื่อโหลดซีนใหม่

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // ให้ GameManager ไม่ถูกลบเมื่อโหลดซีนใหม่
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // เก็บเวลาที่เล่น
        playTime += Time.deltaTime;
    }

    public void AddGem()
    {
        collectedGems++; // เพิ่มจำนวนเพชรที่เก็บ
    }

    // ฟังก์ชันที่เรียกเมื่อเข้าประตู
    public void EnterDoor()
    {
        // บันทึกเวลาที่เล่นเป็นนาที
        string minutes = ((int)(playTime / 60)).ToString();
        string seconds = ((int)(playTime % 60)).ToString("00");

        // โหลดซีนใหม่
        SceneManager.LoadScene("Score");

        // ส่งข้อมูลไปยังซีนสรุป
        PlayerPrefs.SetInt("CollectedGems", collectedGems);
        PlayerPrefs.SetString("PlayTime", minutes + ":" + seconds); // เก็บเวลาในรูปแบบนาที:วินาที
    }
}
