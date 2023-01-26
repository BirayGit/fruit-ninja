using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void IncreaseScore(int addPoints)
    {
        score += addPoints;
        scoreText.text = score.ToString();
    }

    public void OnBombHit()
    {
        Debug.Log("bomb hit");
    }
}
