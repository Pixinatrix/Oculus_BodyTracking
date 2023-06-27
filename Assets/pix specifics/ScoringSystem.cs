using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoringSystem : MonoBehaviour
{

    [SerializeField] private TMP_Text text;

    private bool isGameOn = false;

    public bool IsGameOn { get => isGameOn; set => isGameOn = value; }

    private int totalScore = 0;

    private BallPoints ballPoint;


    public void AddScore(int value)
    {
        Debug.Log(" The total score is " + totalScore);



        totalScore += value;
        text.text = totalScore.ToString();
    }



    public void ResetScore()
    {
        totalScore = 0;
        text.text = totalScore.ToString();
    }



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("object has hit");
        if (!isGameOn)
            return;
        ballPoint = other.GetComponent<BallPoints>();
        if (ballPoint != null)
        {
            Debug.Log(" The ball " + ballPoint.name + " has hit");
            AddScore(ballPoint.BallHitPoints);
        }
    }

}
