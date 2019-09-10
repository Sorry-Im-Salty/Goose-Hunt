using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*-------------------------------------------------------------------*
|  SCORE
|
|  Author:			Thomas Maltezos
| 
|  Description:		Handles the score.
|
|  Example:			The score.
*-------------------------------------------------------------------*/

public class Score : MonoBehaviour
{
	public static int scoreNum = 0;
	Text scoreText;

	void Start()
	{
		scoreText = GetComponent<Text>();
	}

	// Update is called once per frame
	void Update()
    {
		scoreText.text = "Score: " + scoreNum;
    }
}
