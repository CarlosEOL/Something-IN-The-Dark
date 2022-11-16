using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using TMPro;
using UnityEditor.Playables;
using UnityEngine;

public class QuestLists : Interactable
{
    private TextMeshProUGUI texts;
    [SerializeField] private FirstPersonController plr;

    private string listOfQuests = "";
    private string lastQuests = "0";

    private Dictionary<string, string> mainQuest = new Dictionary<string, string>();
    private Dictionary<int, string> quests = new Dictionary<int, string>();
    private Dictionary<int, bool> questsDone = new Dictionary<int, bool>();

    [SerializeField] TextMeshProUGUI mainQuestBoard;

    private bool hasFlashLightQuest;
    private bool hasDoorQuest;

    void Start()
    {
        texts = GetComponent<TextMeshProUGUI>();
        
        mainQuest.Add("Main Quest", "Objective: What's that noise?");
        mainQuestBoard.text = mainQuest["Main Quest"];
        
        quests.Add(0, "\n - Get Your Flashlight -");
        questsDone.Add(0, false);
    }

    // Update is called once per frame
    void Update()
    {
        lastQuests = texts.text;
        
        for (int i = 0; i < quests.Count; i++)
        {
            if (questsDone[i])
            {
                listOfQuests = "";
                quests.Remove(i);
            }
        }
        
        for (int i = 0; i < quests.Count; i++)
        {
            if (lastQuests != listOfQuests)
            {
               listOfQuests += quests[i]; 
            }
        }
        
        texts.text = listOfQuests;
        
        if (plr.hasFlashlight)
        {
            if (questsDone[0] == false)
            {
                Debug.Log("MAKINGPIE");
                questsDone[0] = true;
                lastQuests = "";
                quests[0] = "";
            }
        }
    }
}
