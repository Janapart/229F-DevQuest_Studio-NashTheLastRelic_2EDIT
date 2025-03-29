using UnityEngine;

public class Gem : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // เรียกฟังก์ชันเพิ่มเพชร
            
        }
    }
}
