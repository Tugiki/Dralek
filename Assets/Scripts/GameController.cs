using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int progressAmount;
    public Slider progressSlider;

    public GameObject player;
    public GameObject LoadCanvas;
    public List<GameObject> levels;
    private int currentLevelIndex = 0;



    void Start()
    {
        progressAmount = 0;
        progressSlider.value = 0;
        Gold.OnGoldCollect += IncreaseProgressAmount;

        HoldToLoadLevel.OnHoldComplete += LoadNextLevel;
        LoadCanvas.SetActive(false);
    }

    void IncreaseProgressAmount(int amount)
    {
        progressAmount += amount;
        progressSlider.value = progressAmount;

        if (progressAmount >= 100)
        {
                                                                //Level Complete
            LoadCanvas.SetActive(true);
            Debug.Log("Level Complete!");
        }
        Debug.Log("Progress Amount: " + progressAmount);
    }
    

    void LoadNextLevel()
    {
        int nextLevelIndex = (currentLevelIndex == levels.Count - 1) ? 0 : currentLevelIndex + 1;
        LoadCanvas.SetActive(false);

        levels[currentLevelIndex].SetActive(false);
        levels[nextLevelIndex].SetActive(true);

        player.transform.position = new Vector3(0,0,0);
        
        currentLevelIndex = nextLevelIndex;
        progressAmount = 0;
        progressSlider.value = 0;
    }
    
}
