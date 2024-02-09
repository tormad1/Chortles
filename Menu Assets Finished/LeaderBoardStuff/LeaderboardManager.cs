using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
public class LeaderboardManager : MonoBehaviour
{
    public string userName;
    public int score;

    public TMP_InputField userNameInput;



    private string submitScoreUrl = "https://gamejam24-6c087-default-rtdb.europe-west1.firebasedatabase.app/leaderboard.json";
    public void SubmitScore()
    {
        if (userNameInput != null)
        {
            userName = userNameInput.text; 
        }
        else
        {
            Debug.LogError("UserName Input Field is not assigned in the Inspector.");
            return;
        }

        StartCoroutine(SubmitScoreCoroutine(userName, score));
    }

    private IEnumerator SubmitScoreCoroutine(string userName, int score)
    {
        string jsonData = $"{{\"userName\": \"{userName}\", \"score\": {score}, \"date\": \"{System.DateTime.UtcNow.ToString("o")}\"}}";
        UnityWebRequest www = UnityWebRequest.Put(submitScoreUrl, jsonData);
        www.method = "POST";
        www.SetRequestHeader("Content-Type", "application/json");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error submitting score: " + www.error);
        }
        else
        {
            Debug.Log("Score submitted successfully");
        }
    }
}