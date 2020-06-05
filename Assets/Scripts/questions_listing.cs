using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class questions_listing : MonoBehaviour
{
    //public Text ques;
    public InputField ques;
    public Text idText;

    public void RemoveListing()
    {
        int id = int.Parse(gameObject.name.Substring(0, gameObject.name.IndexOf("_")));
        questions_controller.qc.questions.RemoveAt(id);
        Destroy(gameObject);
    }

    public void EditListing()
    {
        int id = int.Parse(gameObject.name.Substring(0, gameObject.name.IndexOf("_")));
        questions_controller.qc.questions[id] = ques.text;
    }
}
