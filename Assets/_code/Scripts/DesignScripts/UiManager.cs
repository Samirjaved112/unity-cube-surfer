using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static UiManager instance; 

    [SerializeField]
    private GameObject restartButton;
    [SerializeField]
    private GameObject panelRestart;
    [SerializeField]
    private GameObject startButton;
    [SerializeField]
    private GameObject completePanel;
    public static bool isGameStart= false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
       
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isGameStart = false;
        CollectablesScript.finishLineCrossed = false;
        panelRestart.SetActive(false);
        completePanel.SetActive(false);
    }
    public void StartGame()
    {
        isGameStart = true;
        startButton.SetActive(false);
        
    }
    public IEnumerator onLevelFail()
    {
        yield return new WaitForSeconds(2f);
        panelRestart.SetActive(true);

    }
    public IEnumerator OnlevelComplete()
    {
        yield return new WaitForSeconds(2f);
        completePanel.SetActive(true);
    }
}
