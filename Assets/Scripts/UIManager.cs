using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject GameOverCanvas;
    public Button RestartButton;
    public Button QuitButton;

    // Start is called before the first frame update
    void Start()
    {
        GameOverCanvas.SetActive(false);

        Button btn;

        btn = RestartButton.GetComponent<Button>();
        btn.onClick.AddListener(newGame);

        btn = QuitButton.GetComponent<Button>();
        btn.onClick.AddListener(quitGame);

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GameOver )
        {
            GameOverCanvas.SetActive(true);
        }
           
    }

    void newGame()
    {
        GameManager.NewGame();
        SceneManager.LoadScene("VR_Scene", LoadSceneMode.Single);
    }

    void quitGame()
    {
        Application.Quit();
    }

}
