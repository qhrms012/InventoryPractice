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

        // 예: 데이터 로딩 시뮬레이션
        while (progress < 1f)
        {
            progress += Time.deltaTime * 0.5f;  // 2초 동안 로딩
            fillImage.fillAmount = progress;
            progressText.text = $"{(progress * 100f):F0}%";
            yield return null;
        }

        // 로딩 완료 후 딜레이 또는 연출
        yield return new WaitForSeconds(0.5f);
        loadingCanvas.SetActive(false);
    }
}

