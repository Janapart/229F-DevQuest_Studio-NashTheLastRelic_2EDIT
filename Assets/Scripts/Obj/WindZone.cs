using UnityEngine;

public class WindZone : MonoBehaviour
{
    public Vector3 windDirection = new Vector3(1, 0, 0); // ทิศทางลม (ขวา)
    public float windStrength = 2000f; // ความแรงของลม

    void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Debug.Log("ลมกระทบ: " + other.name);
            rb.AddForce(windDirection.normalized * windStrength, ForceMode.Force);
        }
    }
}
