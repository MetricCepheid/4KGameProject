using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;

    public bool startPlaying;

    public BeatScroller theBS;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public Text scoreText;
    public Text multiText;

    private float totalNotes;
    private float normalHits;
    private float goodHits;
    private float perfectHits;
    private float missedHits;

    public GameObject resultsScreen;
    public Text percentHitText, normalsText, goodsText, perfectsText, missesText, rankText, finalScoreText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        var ScoreH = Lean.Localization.LeanLocalization.GetTranslationText("Score");

        scoreText.text = ScoreH + " 0";
        currentMultiplier = 1;

        totalNotes = FindObjectsOfType<NoteObject>().Length;

        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 120;
    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying)
		{
            if(Input.anyKeyDown)
			{
                startPlaying = true;
                theBS.hasStarted = true;

                theMusic.Play();
			}
		} else
		{
            if(!theMusic.isPlaying && !resultsScreen.activeInHierarchy)
			{
                resultsScreen.SetActive(true);

                normalsText.text = "" + normalHits;
                goodsText.text = goodHits.ToString();
                perfectsText.text = perfectHits.ToString();
                missesText.text = "" + missedHits;

                float totalHit = normalHits + goodHits + perfectHits;
                float percentHit = (totalHit / totalNotes) * 100f;

                percentHitText.text = percentHit.ToString("F1") + "%";

                string rankVal = "F";

                if(percentHit > 40)
				{
                    rankVal = "D";
                    if(percentHit > 55)
					{
                        rankVal = "C";
                        if(percentHit > 70)
						{
                            rankVal = "B";
                            if(percentHit > 85)
							{
                                rankVal = "A";
                                if(percentHit > 95)
								{
                                    rankVal = "S";
								}
							}
						}
					}
				}

                rankText.text = rankVal;

                finalScoreText.text = currentScore.ToString();
			}
		}
    }

    public void NoteHit()
	{
        Debug.Log("Hit On Time");

        var ScoreH = Lean.Localization.LeanLocalization.GetTranslationText("Score");
        var MultiH = Lean.Localization.LeanLocalization.GetTranslationText("Multiplier");

        if(currentMultiplier - 1 < multiplierThresholds.Length)
		{
            multiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        multiText.text = MultiH + currentMultiplier;

        //currentScore += scorePerNote * currentMultiplier;
        scoreText.text = ScoreH + currentScore;
	}

    public void NormalHit()
	{
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();

        normalHits++;
	}

    public void GoodHit()
	{
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();

        goodHits++;
    }

    public void PerfectHit()
	{
        currentScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();

        perfectHits++;
    }

    public void NoteMissed()
	{
        Debug.Log("Missed Note");

        currentMultiplier = 1;
        multiplierTracker = 0;

        multiText.text = "Multiplier: x" + currentMultiplier;

        missedHits++;
    }
}
