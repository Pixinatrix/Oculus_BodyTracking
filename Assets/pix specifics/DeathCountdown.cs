using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(AudioSource))]
public class DeathCountdown : MonoBehaviour
{

    [SerializeField] private TMP_Text countdownText;
    [SerializeField] private int countdownDuration;

    public UnityEvent OnCountdownFinished;

    private AudioSource audioSource;
    private float secondsLeft;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    public void StartCountDown()
    {
        StartCoroutine(CountdownRoutine(countdownDuration));
    }

    private IEnumerator CountdownRoutine(int countDownDuration)
    {
        secondsLeft = countDownDuration;
        float minutesLeft;

        while (secondsLeft > 0)
        {
            audioSource.Play();

            secondsLeft--;
            minutesLeft = Mathf.FloorToInt(secondsLeft / 60);

            countdownText.text = string.Format("{0:00}:{1:00}", minutesLeft, secondsLeft % 60);

            yield return new WaitForSeconds(1);

        }

        OnCountdownFinished.Invoke();

    }



}