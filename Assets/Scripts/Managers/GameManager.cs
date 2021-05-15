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
        if (gameObject.tag == "Obstacle") StopGameWithAccident();
        else if (gameObject.tag == "Bonus") TakeBonus(gameObject);
    }

    


    // Update is called once per frame
    void Update()
    {
        
    }


    void StopGameWithAccident()
    {
            
    }

    void TakeBonus(GameObject gameObject)
    {
        var bonus = gameObject.GetComponent<Bonus>();
        score.points += bonus.points;

        uiManager.RefreshUI(score);
        Destroy(gameObject);
    }
}
