using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public Text pointsLabel;
    

    public void RefreshUI(Score score)
    {
        // Здесь должен быть код, который выведет цифры в окно UI
    }


    public void StopGame()
    {
        pointsLabel.text = "lost";
    }
}
