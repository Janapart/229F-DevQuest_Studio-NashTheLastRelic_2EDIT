using System.Collections;
using UnityEngine;

public class FallTrap : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ตรวจสอบว่าผู้เล่นตกลงไป
        {
            HealthManager.instance.LoseLife(); // ลดจำนวนชีวิต
        }
    }
}
