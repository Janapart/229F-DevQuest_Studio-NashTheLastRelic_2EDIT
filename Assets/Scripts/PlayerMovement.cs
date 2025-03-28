using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   public float speed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;
    public CharacterController controller;

    private Vector3 velocity;
    private bool isGrounded;
    private Vector3 moveDirection;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // รับค่าการกดปุ่ม
        float moveX = Input.GetAxisRaw("Horizontal");  
        float moveZ = Input.GetAxisRaw("Vertical");

        if (moveX != 0 || moveZ != 0)
        {
            moveDirection = Camera.main.transform.right * moveX + Camera.main.transform.forward * moveZ;
            moveDirection.y = 0; // ป้องกันการเคลื่อนที่ขึ้นลง
        }
        else
        {
            moveDirection = Vector3.zero; // หยุดทันทีเมื่อไม่มีการกดปุ่ม
        }
        // กระโดด
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 10f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 5f;       
        }
        controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
