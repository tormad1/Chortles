using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class HecklerData
{
    public string name; 
    public GameObject sprite; 
    public Vector4 comedyWeights; 
    public int deckSize; 
}

public class HecklerManager : MonoBehaviour
{
    // Allow setting heckler data in the Unity Editor, but enforce fixed amount and names through code structure
    [SerializeField] public List<HecklerData> hecklerDatasnon;
    public static List<HecklerData> hecklerDatas;
    static private Dictionary<string, List<Tuple<int, GameObject, int, int, string>>> hecklerDecks = new Dictionary<string, List<Tuple<int, GameObject, int, int, string>>>();

    void Start()
    {
        hecklerDatas = hecklerDatasnon;
        InitializeHecklerDecks();
    }

    private static int currentHecklerIndex = 0;

    public static void PlayHecklerCard()
    {
        if (hecklerDecks.Count == 0 || !hecklerDecks.ContainsKey(hecklerDatas[currentHecklerIndex].name))
        {
            Debug.LogError("Heckler deck not initialized or current heckler index out of range.");
            return;
        }
        var currentHecklerDeck = hecklerDecks[hecklerDatas[currentHecklerIndex].name];
        if (currentHecklerDeck.Count > 0)
        {
            int cardIndex = UnityEngine.Random.Range(0, currentHecklerDeck.Count);
            var playedCard = currentHecklerDeck[cardIndex];
            currentHecklerDeck.RemoveAt(cardIndex);

            int matchingCardIndex = HekleData.Cards.FindIndex(card => card.Item1 == playedCard.Item1 && card.Item2 == playedCard.Item2 && card.Item3 == playedCard.Item3 && card.Item4 == playedCard.Item4 && card.Item5 == playedCard.Item5);

            if (matchingCardIndex != -1)
            {
                HekleData.setDeck(matchingCardIndex); 
                HekleData.UpdateDeck();
            }
            else
            {
                Debug.LogError("Matching card not found in HekleData.Cards.");
            }
        }
        else
        {
            Debug.Log("Heckler's deck is empty.");
        }
    }

    void InitializeHecklerDecks()
    {
        foreach (HecklerData hecklerData in hecklerDatas)
        {
            List<Tuple<int, GameObject, int, int, string>> hecklerDeck = CreateHecklerDeck(hecklerData);
            hecklerDecks[hecklerData.name] = hecklerDeck;
        }
    }

    List<Tuple<int, GameObject, int, int, string>> CreateHecklerDeck(HecklerData hecklerData)
    {
        List<Tuple<int, GameObject, int, int, string>> deck = new List<Tuple<int, GameObject, int, int, string>>();
        
        int totalCards = hecklerData.deckSize;
        int darkCount = Mathf.FloorToInt(totalCards * hecklerData.comedyWeights.x);
        int sarcasmCount = Mathf.FloorToInt(totalCards * hecklerData.comedyWeights.y);
        int dryCount = Mathf.FloorToInt(totalCards * hecklerData.comedyWeights.z);
        int slapstickCount = Mathf.FloorToInt(totalCards * hecklerData.comedyWeights.w);
        int assignedCards = darkCount + sarcasmCount + dryCount + slapstickCount;
        while (assignedCards < totalCards)
        {
            if (darkCount < totalCards * hecklerData.comedyWeights.x) {
                darkCount++;
            } else if (sarcasmCount < totalCards * hecklerData.comedyWeights.y) {
                sarcasmCount++;
            } else if (dryCount < totalCards * hecklerData.comedyWeights.z) {
                dryCount++;
            } else if (slapstickCount < totalCards * hecklerData.comedyWeights.w) {
                slapstickCount++;
            }
            assignedCards = darkCount + sarcasmCount + dryCount + slapstickCount;
        }

        deck.AddRange(SelectCardsByWeight(HekleData.darkCards, darkCount));
        deck.AddRange(SelectCardsByWeight(HekleData.sarcasmCards, sarcasmCount));
        deck.AddRange(SelectCardsByWeight(HekleData.dryCards, dryCount));
        deck.AddRange(SelectCardsByWeight(HekleData.slapstickCards, slapstickCount));

        return deck;
    }

    IEnumerable<Tuple<int, GameObject, int, int, string>> SelectCardsByWeight(List<Tuple<int, GameObject, int, int, string>> sourceList, int count)
    {
        return sourceList.OrderBy(x => UnityEngine.Random.value).Take(count);
    }
}
