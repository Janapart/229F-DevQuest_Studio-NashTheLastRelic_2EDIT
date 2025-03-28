using UnityEngine;
using UnityEngine.UI;

public class KeyPickup : MonoBehaviour
{
    public GameObject messagePanel; 
    public Text messageText; 
    public int keyID;
    private bool isNearKey = false;
     private GameObject player;

    void Start()
    {
        messagePanel.SetActive(false); 
    }

    private void Update()
    {
        if (isNearKey && Input.GetKeyDown(KeyCode.F))
        {
            PickupKey();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNearKey = true;
             player = other.gameObject;
            messagePanel.SetActive(true);
            messageText.text = "กด F นะเพื่อเก็บ";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNearKey = false;
            player = null;
            messagePanel.SetActive(false);
        }
    }

    private void PickupKey()
    {
        PlayerInventory inventory = player.GetComponent<PlayerInventory>();
        if (inventory != null)
        {
            inventory.AddKey(keyID); 
        }

        messagePanel.SetActive(false);
        Destroy(gameObject);
    }
}
