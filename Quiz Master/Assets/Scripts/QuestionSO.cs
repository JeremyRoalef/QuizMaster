using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Quiz Question", fileName ="New Question")] //this lets us create a new thing in unity like we would with anything else


public class QuestionSO : ScriptableObject //change mono to scriptable
{
    [TextArea(2,6)] //makes the text box in unity expand from 2 lines up to 6 lines
    [SerializeField] string question = "Enter new question text here";


}
