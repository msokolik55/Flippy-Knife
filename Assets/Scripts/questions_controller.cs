using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class questions_controller : MonoBehaviour
{
    public static questions_controller qc;

    public List<string> questions;
    int len;

    public Transform ScrollContent;
    public GameObject PrefabQues;

    public InputField input;

    void Start()
    {
        questions = new List<string>();
        _LoadQuestions();
    }

    private void OnEnable()
    {
        if(qc == null) { qc = this; }
        else
        {
            if(qc != this)
            {
                Destroy(gameObject);
            }
        }
    }

    private void _AddListing(int id, string text)
    {
        GameObject tempListing = Instantiate(PrefabQues, ScrollContent);
        tempListing.name = (id - 1).ToString() + "_listing";

        questions_listing ql = tempListing.GetComponent<questions_listing>();
        ql.idText.text = id.ToString() + ".";
        ql.ques.text = text;

        //questions_listing ql = tempListing.GetComponent<questions_listing>();
        //ql.ques.text = text;
    }
    
    public void AddQuestion()
    {
        if (input.text != "")
        {
            questions.Add(input.text);
            _AddListing(questions.Count, input.text);
        }

        input.text = "";
    }

    #region PlayerPrefs
    private void _LoadQuestions()
    {
        len = Mathf.Max(questions.Count, PlayerPrefs.GetInt("count"));

        for (int i = 0; i < len; i++)
        {
            questions.Add(PlayerPrefs.GetString("ques_" + i));
            _AddListing(i + 1, questions[i]);
        }
    }

    public void SaveQuestions()
    {
        PlayerPrefs.SetInt("count", questions.Count);
        for(int i = 0; i < questions.Count; i++) { PlayerPrefs.SetString("ques_" + i, questions[i]); }
    }
    #endregion

}
