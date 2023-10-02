using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Quiz Question", fileName ="New Question")]      //this lets us create a new thing in unity like we would with anything else


public class QuestionSO : ScriptableObject                                  //change mono to scriptable
{
    [TextArea(2,6)]                                                         //makes the text box in unity expand from 2 lines up to 6 lines
    [SerializeField] string strQuestion = "Enter new question text here";
    [SerializeField] string[] strAnswers = new string[4];                                    //arrays store multiple values of same type. string[4] means create the array with 4 elements 
    [SerializeField] int intCorrectAnswerIndex;

    public string GetQuestion()                                             //void was the spot where the function would return a value. in this case, the function will return a string
    {
        return strQuestion;
    }

    public int GetCorrectAnswerIndex()
    {
        return intCorrectAnswerIndex;
    }
    
    public string GetAnswer(int index)
    {
        return strAnswers[index];
    }

}

