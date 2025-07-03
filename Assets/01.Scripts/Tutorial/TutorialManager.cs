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
        "이동은 WASD 키로 할 수 있어요!",
        "마우스를 움직여서 방향을 바꿔보세요.",
        "왼쪽 클릭으로 공격할 수 있어요!",
        "이제 튜토리얼이 끝났어요. 게임을 시작해볼까요?"
    };

    private int currentIndex = 0;

    void Start()
    {
        nextButton.onClick.AddListener(ShowNextMessage);
        ShowNextMessage(); // 첫 메시지 표시
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
            gameObject.SetActive(false); // 튜토리얼 종료 시 숨김
            
            
        }
    }
}

