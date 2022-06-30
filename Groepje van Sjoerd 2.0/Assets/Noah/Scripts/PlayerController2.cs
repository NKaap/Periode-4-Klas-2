using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public LeaderBoard leaderboard;

    public GameObject sprayGun;

    public int score;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SubmitScoreRoutine()
    {
        //Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(1f);
        yield return leaderboard.SubmitScoreRoutine(score);
    }

    public void SumbitScore()
    {
        sprayGun.GetComponent<Spray>().score = score;
        StartCoroutine(SubmitScoreRoutine());
    }
}
