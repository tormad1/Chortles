using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.Networking;
using System.Text.RegularExpressions;
using System; // Make sure to include this for TextMeshPro


public class LeaderboardDisplay : MonoBehaviour
{

    private string getLeaderboardUrl = "https://gamejam24-6c087-default-rtdb.europe-west1.firebasedatabase.app/leaderboard.json";

    public TMP_Text leaderboardText;

    void Start()
    {
        StartCoroutine(GetLeaderboardCoroutine());
    }

    private IEnumerator GetLeaderboardCoroutine()
    {
        UnityWebRequest www = UnityWebRequest.Get(getLeaderboardUrl);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error getting leaderboard: " + www.error);
        }
        else
        {
            DisplayLeaderboard(www.downloadHandler.text);
        }
    }

public void DisplayLeaderboard(string json)
{
    List<LeaderboardEntry> entries = new List<LeaderboardEntry>();

    // Extract individual entries from the JSON string
    string pattern = "\"(\\-\\w+)\":\\{(.*?)\\}";
    MatchCollection matches = Regex.Matches(json, pattern, RegexOptions.Singleline);

    foreach (Match match in matches)
    {
        string entryJson = "{" + match.Groups[2].Value + "}";
        LeaderboardEntry entry = JsonUtility.FromJson<LeaderboardEntry>(entryJson);
        entries.Add(entry);
    }

    // Sort the entries by score
    entries.Sort();

    // Update the leaderboard text
    leaderboardText.text = "Leaderboard:\n";
    int displayCount = Math.Min(entries.Count, 10); // Limit to top 10 entries
    for (int i = 0; i < displayCount; i++)
    {
        var entry = entries[i];
        // Format the date
        DateTime parsedDate;
        if (DateTime.TryParse(entry.date, out parsedDate))
        {
            string formattedDate = parsedDate.ToString("dd/MM/yyyy");
            leaderboardText.text += $"{i + 1}. {entry.userName}: {entry.score} - {formattedDate}\n";
        }
        else
        {
            // Handle the case where the date could not be parsed
            leaderboardText.text += $"{i + 1}. {entry.userName}: {entry.score} - Date Error\n";
        }
    }
}
}
[System.Serializable]
public class LeaderboardEntry : IComparable<LeaderboardEntry>
    {
        public string userName;
        public int score;
        public string date;

        public int CompareTo(LeaderboardEntry other)
        {
            // Compare scores in descending order
            return other.score.CompareTo(this.score);
        }
    }
