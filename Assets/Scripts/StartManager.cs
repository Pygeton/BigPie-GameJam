using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartManager : MonoBehaviour
{
    public Button startBtn;
    public Button quitBtn;
    // Start is called before the first frame update
    void Start()
    {
        startBtn.onClick.AddListener(StartGame);
        quitBtn.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartGame()//开始游戏
    {
        SceneManager.LoadSceneAsync("MainScene");
    }
    void QuitGame()//退出游戏
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
