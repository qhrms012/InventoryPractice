using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LocalLoader : MonoBehaviour
{
    public GameObject loadingCanvas;
    public Image fillImage;
    public Text progressText;

    public void StartLoading()
    {
        StartCoroutine(LoadDataCoroutine());
    }

    IEnumerator LoadDataCoroutine()
    {
        loadingCanvas.SetActive(true);

        float progress = 0f;

        // ��: ������ �ε� �ùķ��̼�
        while (progress < 1f)
        {
            progress += Time.deltaTime * 0.5f;  // 2�� ���� �ε�
            fillImage.fillAmount = progress;
            progressText.text = $"{(progress * 100f):F0}%";
            yield return null;
        }

        // �ε� �Ϸ� �� ������ �Ǵ� ����
        yield return new WaitForSeconds(0.5f);
        loadingCanvas.SetActive(false);
    }
}

