using System;
using UnityEditor.SearchService;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ChoiceDialog : MonoBehaviour
{
      public GameObject dialogPanel;
    public Text messageText;
    public Button YesButton;
    public Button NoButton;
    public string sceneToLoad;
    public int doorKeyID; // กุญแจที่ต้องใช้เปิดประตู
    private bool isPlayer = false;
    private PlayerInventory playerInventory;

    void Start()
    {
        dialogPanel.SetActive(false);
        YesButton.onClick.AddListener(OnYesClicked);
        NoButton.onClick.AddListener(OnNoClicked);
    }

    void Update()
    {
        if (isPlayer && Input.GetKeyDown(KeyCode.F))
        {
            ShowDialog();
        }
    }

    private void ShowDialog()
    {
        dialogPanel.SetActive(true);
        messageText.text = "ประตูนี้จะข้ามด่านไปเลยแน่ใจมั้ยที่จะเข้าประตูนี้ คิดว่าเกินความสามารถตัวเองมั้ย";
    }

    private void OnYesClicked()
    {
        if (playerInventory != null)
        {
            if (playerInventory.HasKey(doorKeyID))
            {
                
                Debug.Log("ไป");
                //SceneManager.LoadScene(sceneToLoad);
            }
            else if (playerInventory.HasAnyKey()) 
            {
                
                messageText.text = "ฮั่นแน่ ผิดดอกนะจ๊ะ";
            }
            else
            {
                
                messageText.text = "อยากเข้าไปก็ไปหากุญแจมา";
            }
        }
    }

    private void OnNoClicked()
    {
        dialogPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayer = true;
            playerInventory = other.GetComponent<PlayerInventory>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayer = false;
            playerInventory = null;
        }
    }
}
