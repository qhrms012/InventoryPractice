using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LoadingSceneController : MonoBehaviour
{
    public Image fillImage;   // 슬라이더 형태의 로딩바
    public Text progressText;    // 진행률 텍스트

    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("GameScene");
        asyncOperation.allowSceneActivation = false;  // 로딩이 완료되어도 자동 전환하지 않도록 설정

        while (!asyncOperation.isDone)
        {
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);  // 실제 progress는 0~0.9까지 도달
            fillImage.fillAmount = progress;
            progressText.text = $"{(progress * 100f):F0}%";

            // 90% 이상 로딩이 완료되었을 때 자동 전환 (예: 1초 후)
            if (asyncOperation.progress >= 0.9f)
            {
                progressText.text = "Press any key to continue...";
                if (Input.anyKeyDown)
                {
                    asyncOperation.allowSceneActivation = true;
                }
            }

            yield return null;
        }
    }
}
