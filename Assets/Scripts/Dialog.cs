using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [SerializeField] private GameObject _dialogScreen;

    public void EnableDialog()
    {
        _dialogScreen.SetActive(true);
    }
    public void DisableDialog()
    {
        _dialogScreen.SetActive(false);
    }


}
