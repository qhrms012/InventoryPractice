using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LoadingSceneController : MonoBehaviour
{
    public Image fillImage;   // �����̴� ������ �ε���
    public Text progressText;    // ����� �ؽ�Ʈ

    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("GameScene");
        asyncOperation.allowSceneActivation = false;  // �ε��� �Ϸ�Ǿ �ڵ� ��ȯ���� �ʵ��� ����

        while (!asyncOperation.isDone)
        {
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);  // ���� progress�� 0~0.9���� ����
            fillImage.fillAmount = progress;
            progressText.text = $"{(progress * 100f):F0}%";

            // 90% �̻� �ε��� �Ϸ�Ǿ��� �� �ڵ� ��ȯ (��: 1�� ��)
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
