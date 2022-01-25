using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject[] tutorials;
    private int _tutorialIndex;

    [SerializeField] GameObject _enemy;
    private bool _enemySpawned = false;

    private float _waitTime = 1f;
    private float _spawnDelay = 5f;
    
    void Update()
    {
        //Debug.Log("Index size: " + tutorials.Length + " CurrentIndex: " + _tutorialIndex);
        TutorialCompleted();
        CurrentTutorial();
    }

    private void TutorialCompleted()
    {
        //when the index has reached the end it changed back to the main menu
        if (tutorials.Length == _tutorialIndex)
        {
            StaticValues.TutorialCompleted = true;
            SceneManager.LoadScene("Menu");

        }
    }
    public void CurrentTutorial()
    {
        //used to keep track of what the current part of the tutorial is
        for (int i = 0; i < tutorials.Length; i++)
        {
            tutorials[i].SetActive(i == _tutorialIndex);
        }
        switch (_tutorialIndex)
        {
            case 0:
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
                {
                    _tutorialIndex++;
                }
                break;
            case 1:
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
                {
                    _tutorialIndex++;
                }
                break;
            case 2:
                if (Input.GetAxis("Mouse Y") > 0 || Input.GetAxis("Mouse Y") < 0)
                {
                    NextTutTimer();
                }
                break;
            case 3:
                if (Input.GetAxis("Mouse X") > 0 || Input.GetAxis("Mouse X") < 0)
                {
                    NextTutTimer();
                }
                break;
            case 4:
                if (Input.GetButton("Fire1"))
                {
                    _tutorialIndex++;
                }
                break;
            case 5:
                if (_spawnDelay <= 0)
                {
                    if (_enemy == null)
                    {
                        _tutorialIndex++;
                    }

                }
                else
                {
                    _spawnDelay -= Time.deltaTime;
                }
                if (!_enemySpawned)
                {
                    _enemy = Instantiate(_enemy, transform.position, Quaternion.Euler(0, 180, 0));
                    _enemySpawned = true;
                }
                break;
            case 6:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    _tutorialIndex++;
                }
                break;
        }
    }
    public void NextTutTimer()
    {
        //this is to make it so that the next part of the tutorial wont instantly be skipped
        if (_waitTime <= 0)
        {
            _tutorialIndex++;
            _waitTime = 1;
        }
        else
        {
            _waitTime -= Time.deltaTime;
        }
    }

}
