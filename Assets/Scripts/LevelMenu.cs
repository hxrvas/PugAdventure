using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    // Properties
    // Fields
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _winMenu;
    [SerializeField] private GameObject _loseMenu;
    [SerializeField] private Image[] _stars;
    [SerializeField] private Sprite _fullStarSprite;
    [SerializeField] private int _starPoints1;
    [SerializeField] private int _starPoints2;
    [SerializeField] private int _starPoints3;

    bool _gamePaused;
    GameManager _gameManager;
    private Player _player;

    // Unity Methods
    void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _player = FindObjectOfType<Player>();
        _gamePaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !_winMenu.activeSelf)
        {
            TogglePauseMenu();
        }
    }
    // Other Methods
    public void TogglePauseMenu()
    {
        _gamePaused = !_gamePaused;

        if (_gamePaused)
        {
            _gameManager.SetLowLevel();
            _player.enabled = false;
            _pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            _gameManager.SetHighLevel();
            _player.enabled = true;
            _pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void ActivateWinMenu()
    {
        _gameManager.SetLowLevel();
        Time.timeScale = 0;
        _player.enabled = false;
        _winMenu.SetActive(true);

        if (_player.Cookies >= _starPoints1)
        {
            _stars[2].sprite = _fullStarSprite;
        }

        if (_player.Cookies >= _starPoints2)
        {
            _stars[1].sprite = _fullStarSprite;
        }

        if (_player.Cookies >= _starPoints3)
        {
            _stars[0].sprite = _fullStarSprite;
        }
    }

    public void ActivateLoseMenu()
    {
        _gameManager.SetLowLevel();
        _loseMenu.SetActive(true);
    }

    public void NextLevel()
    {
        _gameManager.StopMusic();
        _gameManager.SetHighLevel();
        Time.timeScale = 1;
        Invoke("LoadNextLevel", 1f);
    }

    public void Restart()
    {
        _gameManager.StopMusic();
        _gameManager.SetHighLevel();
        LoadCurrentLevel();
    }

    public void MainMenu()
    {
        _gameManager.StopMusic();
        _gameManager.SetHighLevel();
        LoadMainMenu();
    }

    public void LoadMainMenu() 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        _gameManager.MenuMusic();
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        _gameManager.LevelMusic();
    }

    public void LoadCurrentLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        _gameManager.LevelMusic();
    }
}
