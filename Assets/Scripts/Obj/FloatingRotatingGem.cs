using UnityEngine;

public class FloatingRotatingGem : MonoBehaviour
{
    public int scoreValue = 10; // ค่าคะแนนเมื่อเก็บเพช
    public float floatStrength = 0.5f; // ความแรงของการลอย
    public float rotationSpeed = 50f;  // ความเร็วในการหมุน

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position; // บันทึกตำแหน่งเริ่มต้น
    }

    void Update()
    {
        // ทำให้เพชรลอยขึ้นลง
        transform.position = startPos + new Vector3(0, Mathf.Sin(Time.time) * floatStrength, 0);

        // ทำให้เพชรหมุน
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ตรวจสอบว่าเป็นตัวผู้เล่นหรือไม่
        {
            ScroeManager.instance.AddScore(scoreValue); // เพิ่มคะแนน
            Destroy(gameObject); // ทำลายเพชรเมื่อเก็บได้
        }
    }

    
}
