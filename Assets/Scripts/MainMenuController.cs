using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button _startGame;
    [SerializeField] private Image _loader;
    [SerializeField] private CanvasGroup _canvasGroup;

    private AsyncOperation _asyncOperation;

    void Start()
    {
        _loader.fillAmount = 0;
        _canvasGroup.alpha = 0;
    }

    public void StartGame()
    {
        //SceneManager.LoadScene(0, LoadSceneMode.Single);

        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(1);
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            _canvasGroup.alpha += Time.deltaTime;
            _loader.fillAmount = asyncOperation.progress * 100;

            asyncOperation.allowSceneActivation = _loader.fillAmount >= 1;
            yield return null;
        }

    }
}
