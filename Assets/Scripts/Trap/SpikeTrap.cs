using System.Collections;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
   public Rigidbody rb; // Rigidbody ของหนาม
    public float forceAmount = 10f; // แรงดีดขึ้น
    public float resetTime = 1.5f; // เวลาที่หนามค้างข้างบนก่อนกลับลง
    public float cooldownTime = 3f; // เวลาคูลดาวน์ก่อนทำงานใหม่
    public float resetSpeed = 2f; // ความเร็วในการกลับตำแหน่งเดิม

    private bool isTriggered = false; // เช็คว่ากับดักกำลังทำงานอยู่หรือไม่
    private Vector3 initialPosition; // ตำแหน่งเริ่มต้นของหนาม

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // ดึง Rigidbody มาใช้
        rb.isKinematic = true; // ปิด Physics เริ่มต้น
        initialPosition = transform.position; // บันทึกตำแหน่งเริ่มต้น
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTriggered)
        {
            StartCoroutine(ActivateTrap()); // ทำงานกับดัก
        }
    }

    IEnumerator ActivateTrap()
    {
        isTriggered = true; // ป้องกันการทำงานซ้ำ

        // เปิด Physics เพื่อดีดขึ้น
        rb.isKinematic = false;
        rb.AddForce(Vector3.up * forceAmount, ForceMode.Impulse);

        yield return new WaitForSeconds(resetTime); // หนามค้างข้างบน

        // กลับตำแหน่งเดิมอย่างราบรื่น
        StartCoroutine(ResetPosition());

        yield return new WaitForSeconds(cooldownTime); // รอคูลดาวน์

        isTriggered = false; // พร้อมทำงานใหม่
    }

    IEnumerator ResetPosition()
    {
        // ปิด Physics ก่อนจะเคลื่อนที่กลับเอง
        rb.isKinematic = true;

        float elapsedTime = 0f;
        Vector3 startPosition = transform.position;

        while (elapsedTime < 1f) // ใช้เวลา 1 วินาทีในการกลับลงมา
        {
            transform.position = Vector3.Lerp(startPosition, initialPosition, elapsedTime * resetSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // ให้แน่ใจว่าหนามอยู่ที่ตำแหน่งเริ่มต้นเป๊ะ ๆ
        transform.position = initialPosition;
    }
}
