using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;
    public Button nextButton;
    

    private List<string> tutorialMessages = new List<string>()
    {
        "�̵��� WASD Ű�� �� �� �־��!",
        "���콺�� �������� ������ �ٲ㺸����.",
        "���� Ŭ������ ������ �� �־��!",
        "���� Ʃ�丮���� �������. ������ �����غ����?"
    };

    private int currentIndex = 0;

    void Start()
    {
        nextButton.onClick.AddListener(ShowNextMessage);
        ShowNextMessage(); // ù �޽��� ǥ��
    }

    void ShowNextMessage()
    {
        if (currentIndex < tutorialMessages.Count)
        {
            tutorialText.text = tutorialMessages[currentIndex];
            currentIndex++;
        }
        else
        {
            gameObject.SetActive(false); // Ʃ�丮�� ���� �� ����
            
            
        }
    }
}

