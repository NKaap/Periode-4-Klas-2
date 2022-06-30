using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public LeaderBoard leaderboard;

    public TMP_InputField playerNameInputField;
    public TMP_InputField scoreInputField;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetupRoutine());
    }

    public void SetPlayerName()
    {
        LootLockerSDKManager.SetPlayerName(playerNameInputField.text, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Succesfully set playername!");
            }
            else
            {
                Debug.Log("Could not set playername" + response.Error);
            }
        });
    }
    public void SetPlayerScore()
    {

        this.gameObject.GetComponent<PlayerController2>().score = int.Parse(scoreInputField.text);
    }

    IEnumerator SetupRoutine()
    {
        yield return LoginRoutine();
        yield return leaderboard.FetchTopHighScoreRoutine();
    }
    IEnumerator LoginRoutine()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("Player was Logged in!");
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                done = true;
            }
            else
            {
                Debug.Log("Could not start session!");
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }
}
