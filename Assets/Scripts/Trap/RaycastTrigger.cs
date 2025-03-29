using UnityEngine;

public class RaycastTrigger : MonoBehaviour
{
    public GameObject effectPrefab; // เอฟเฟคที่จะสร้างเมื่อชน
    public float effectDuration = 2f; // เวลาที่เอฟเฟคคงอยู่
    public float damageAmount = 10f; // ค่าดาเมจที่สร้าง
    public LayerMask targetLayer; // เลเยอร์ของเป้าหมายที่ต้องการตรวจจับ

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1f, targetLayer))
        {
            TriggerEffect(hit.point, hit.collider);
        }
    }

    void TriggerEffect(Vector3 position, Collider target)
    {
        if (effectPrefab != null)
        {
            GameObject effect = Instantiate(effectPrefab, position, Quaternion.identity);
            Destroy(effect, effectDuration);
        }

        IDamageable damageable = target.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(damageAmount);
        }
    }
}

public interface IDamageable
{
    void TakeDamage(float amount);
}
