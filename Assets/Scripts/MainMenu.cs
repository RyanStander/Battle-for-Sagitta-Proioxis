using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject toggleObj;
    [SerializeField] GameObject confirmationObj;
    private int count;
    public void PlayGame()
    {
        EventManager.StartGame();
        //Loads the next scene in the list        
        if (toggleObj.activeSelf)
        {
            toggleObj.SetActive(false);
        }
        if (StaticValues.TutorialCompleted)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
        }
        else
        {
            confirmationObj.SetActive(true);
        }
        
    }
    public void PlayTutorial()
    {
        SceneManager.LoadScene("Tutorial");
        Debug.Log("Scene has been sucesfully loaded ");
    }
    public void QuitGame()
    {
        //exits the game
        Application.Quit();
        Debug.Log("Player has left the game!");
    }
    public void ToggleObj()
    {
        count++;
        if (count % 2 == 1)
        {
            toggleObj.SetActive(true);
        }
        else
        {
            toggleObj.SetActive(false);
        }
    }
}
