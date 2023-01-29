using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static Menu instance;
    [SerializeField] private Button pauseButton;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button resetButton;

    void Start()
    {
        pausePanel.SetActive(false);
        pauseButton.onClick.AddListener(Pause);
        resumeButton.onClick.AddListener(Resume);
        resetButton.onClick.AddListener(Reset);
    }
    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;  // 時間停止
        pausePanel.SetActive(true);
        DragonManager.instance.Moveimp();
        SlimeManager.instance.Moveimp();
    }

    private void Resume()
    {
        Time.timeScale = 1;  // 再開
        pausePanel.SetActive(false);
        DragonManager.instance.MoveEnable();
        SlimeManager.instance.MoveEnable();
    }

    private void Reset(){
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        pausePanel.SetActive(false);
    }
}