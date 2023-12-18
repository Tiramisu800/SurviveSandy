using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    [SerializeField] private CharController _CharController;
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _pauseScreen;

    //��� ������������ ��������
    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }
    public void FadeToLevel()
    {
        _anim.SetTrigger("Fade");
    }

    //������� ������
    private void OnEnable()
    {
        _CharController.OnKilled += CharControllerOnKilled;
    }

    private void OnDisable()
    {
        _CharController.OnKilled -= CharControllerOnKilled;
    }

    private void CharControllerOnKilled()
    {
        _endScreen.SetActive(true);
    }

   //��� ����� ������
    public void LevelComplete()
    {
        _winScreen.SetActive(true);
        _CharController.enabled = false;
    }

    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    //��� ����� � ������
    public void Pause()
    {
        _pauseScreen.SetActive(true);
    }
    public void Continue()
    {
        _pauseScreen.SetActive(false);
    }


}
