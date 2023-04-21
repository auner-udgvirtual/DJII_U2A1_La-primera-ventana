using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Firestore;
using Firebase.Extensions;
using System;


public class ScoreScript : MonoBehaviour
{
    private int score;
    private int scoreLevel;
    public GameObject Coin;
    public Text scoreText;
    public Text scoreLevelText;


    // Start is called before the first frame update
    void Start()
    {
        ReadData();
        scoreLevel = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreLevelText.text = "Score = " + score;
        if ( scoreLevel == 4)
        {
            scoreText.text = "Nivel Completado!";
            AddData();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Coin)
        {
            
            scoreLevel++;
            scoreText.text = "Score = " + scoreLevel;
        }
    }

    private void AddData()
    {
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
        DocumentReference docRef = db.Collection("puntajes").Document("aunermedina");
        Dictionary<string, object> user = new Dictionary<string, object>
        {
                { "score", score + scoreLevel },
        };
        docRef.SetAsync(user).ContinueWithOnMainThread(task => {
            Debug.Log("Score Saved!");
        });
    }

    private void ReadData()
    {
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
        CollectionReference usersRef = db.Collection("puntajes");
        usersRef.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            QuerySnapshot snapshot = task.Result;
            
            foreach (DocumentSnapshot document in snapshot.Documents)
            {
                Dictionary<string, object> documentDictionary = document.ToDictionary();
                if ( document.Id == "aunermedina")
                {
                    score = Convert.ToInt32(documentDictionary["score"]);
                    Debug.Log(score);
                }
            }

            Debug.Log("Read all data from the puntajes collection.");
        });
    }
}
