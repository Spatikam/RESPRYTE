using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using Dan.Main;
using UnityEngine.SocialPlatforms.Impl;

using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

namespace LeaderboardCreatorDemo
{
    public class Leaderboard_Controller : MonoBehaviour
    {
        [SerializeField] GameObject Input_menu;
        [SerializeField] GameObject leaderboard;
        public TMP_Text message;
        public TMP_Text P_rank;
        public TMP_Text P_score;
        [SerializeField] private TMP_Text[] _entryTextObjects;

        private string player_name;

        // Start is called before the first frame update
        void Start()
        {

            player_name = PlayerPrefs.GetString("P_Name", " ");
            if (player_name == " ")
            {
                Input_menu.SetActive(true);
                leaderboard.SetActive(false);
            }
            else
            {
                leaderboard_active();
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Menu");
            }

        }

        public void Read_Name(string s)
        {
            player_name = s;
            PlayerPrefs.SetString("P_Name", player_name);
            Debug.Log(player_name);

            leaderboard_active();
        }

        void leaderboard_active()
        {
            Input_menu.SetActive(false);
            message.text = "Welcome " + player_name;
            P_score.text = "Highscore: " + Score_handle.highscore;
            UploadEntry();
            leaderboard.SetActive(true);
        }

        private void LoadEntries()
        {
            // Q: How do I reference my own leaderboard?
            // A: Leaderboards.<NameOfTheLeaderboard>

            Leaderboards.Top_Fraggers.GetEntries(entries =>
            {
                foreach (var t in _entryTextObjects)
                    t.text = "";
                var length = Mathf.Min(_entryTextObjects.Length, entries.Length);
                for (int i = 0; i < length; i++)
                    _entryTextObjects[i].text = $"{entries[i].Rank}. {entries[i].Username} - {entries[i].Score}";
            });
            Leaderboards.Top_Fraggers.GetEntries(entries =>
            {
                for (int i = 0; i < entries.Length; i++)
                {
                    if (entries[i].Username == player_name)
                    {
                        P_rank.text ="Rank: " + entries[i].Rank;
                    }
                }
            });
        }

        public void UploadEntry()
        {
            if (Score_handle.highscore != 0)
            {
                Leaderboards.Top_Fraggers.UploadNewEntry(player_name, Score_handle.highscore, isSuccessful =>
                {
                    if (isSuccessful)
                        LoadEntries();
                });
            }
        }

        public void EditEntry()
        {

        }
    }
}
