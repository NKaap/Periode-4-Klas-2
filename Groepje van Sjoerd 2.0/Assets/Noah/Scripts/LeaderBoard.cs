using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class LeaderBoard : MonoBehaviour
{
    int leaderboardID = 3629;

    public TextMeshProUGUI playerName;
    public TextMeshProUGUI playerScore;

    // Start is called before the first frame update
    void Start()
    {

    }

    public IEnumerator SubmitScoreRoutine(int scoreToUpload)
    {
        bool done = false;
        string playerID = PlayerPrefs.GetString("PLayerID");
        LootLockerSDKManager.SubmitScore(playerID, scoreToUpload, leaderboardID, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Succesfully uploaded score");
                done = true;
            }
            else
            {
                Debug.Log("Failed" + response.Error);
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }

    public IEnumerator FetchTopHighScoreRoutine()
    {
        bool done = false;
        LootLockerSDKManager.GetScoreListMain(leaderboardID, 10, 0, (response) =>
            {
                if (response.success)
                {
                    string tempPlayerNames = "Names\n";
                    string tempPlayerScores = "Scores\n";

                    LootLockerLeaderboardMember[] members = response.items;

                    for(int i = 0; i < members.Length; i++)
                    {
                        tempPlayerNames += members[i].rank + ". ";
                        if(members[i].player.name != "")
                        {
                            tempPlayerNames += members[i].player.name;
                        }
                        else
                        {
                            tempPlayerNames += members[i].player.id;
                        }
                        tempPlayerScores += members[i].score + "\n";
                        tempPlayerNames += "\n";
                    }
                    done = true;
                    playerName.text = tempPlayerNames;
                    playerScore.text = tempPlayerScores;
                }
                else
                {
                    Debug.Log("Failed" + response.Error);
                    done = true;
                }
            });
        yield return new WaitWhile(() => done == false);
    }
    public void LoadHighscoresButton()
    {
        StartCoroutine(FetchTopHighScoreRoutine());
    }
}
