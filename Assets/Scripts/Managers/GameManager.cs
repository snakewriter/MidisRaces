using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uiManager;
    public Player player;


    Score score = new Score();


    public void HandleCollision(GameObject gameObject)
    {
        if (gameObject.tag == "Bonus") TakeBonus(gameObject);
        else if (gameObject.tag == "Obstacle") StopGame();
    }


    
    void Update()
    {
        
    }

    void TakeBonus(GameObject gameObject)
    {
        var bonus = gameObject.GetComponent<Bonus>(); // Получили контейнер с "ценником"
        score.points += bonus.points; // подсчитали число с "ценника" в счетчик

        Destroy(gameObject);
    }

    void StopGame()
    {
        uiManager.StopGame();
        player.gameover = true;
    }
}
