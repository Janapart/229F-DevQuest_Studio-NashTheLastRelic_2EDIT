using UnityEngine;
using UnityEngine.UI;

public class SummaryScene : MonoBehaviour
{
   public Text gemText;  // UI แสดงจำนวนเพชร
    public Text timeText; // UI แสดงเวลา

    void Start()
    {
        // โหลดข้อมูลจาก PlayerPrefs
        int collectedGems = PlayerPrefs.GetInt("CollectedGems", 0);
        string playTime = PlayerPrefs.GetString("PlayTime", "00:00");

        // แสดงข้อมูลบน UI
        gemText.text = "เพชรที่เก็บได้: " + collectedGems;
        timeText.text = "เวลาเล่น: " + playTime;
    }
}
