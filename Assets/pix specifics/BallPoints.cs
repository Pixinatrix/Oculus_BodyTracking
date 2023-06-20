using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPoints : MonoBehaviour
{

     [SerializeField] private int _ballPoints;



    public int BallHitPoints { get => _ballPoints; set => _ballPoints = value; }



    private void Start()

    {

        this.BallHitPoints = _ballPoints;

    }
}
