using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfirmationMenu : MonoBehaviour
{
    public GameObject disableObj;
    public void DisableObj()
    {
        disableObj.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Scene has been sucesfully loaded");
    }
}
