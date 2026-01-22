using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int progressAmount;
    public Slider progressSlider;
   
    void Start()
    {
        progressAmount = 0;
        progressSlider.value = 0;
        Gold.OnGoldCollect += IncreaseProgressAmount;
    }

    void IncreaseProgressAmount(int amount)
    {
        progressAmount += amount;
        progressSlider.value = progressAmount;

        if (progressAmount >= 100)
        {
            //Level Complete
            Debug.Log("Level Complete!");
        }
        Debug.Log("Progress Amount: " + progressAmount);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
