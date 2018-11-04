using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rainbowrize : MonoBehaviour
{
    [SerializeField]
    Color changeColor_ = new Color(0, 0, 0, 1);

    [SerializeField]
    float duration_ = 1.0f;

    [SerializeField]
    bool isRepeat_ = true;

    [SerializeField]
    bool isRainbow_ = true;

    private float elapsed = 0.0f;
    private float counter = 0.0f;
    private float neg = 1.0f;
    private Color baseColor;
    private Color startingColor;
    private Color targetColor;
    private Dictionary<string, Color> ColorsDict;
    private List<Color> ColorList;
    private IEnumerator colorIterator;
    private int colorI = 0;

		// Use this for initialization
	void Start ()
	{
        ColorsDict = new Dictionary<string, Color>();
        ColorList = new List<Color>();


        ColorsDict.Add("red", Color.red);
        ColorsDict.Add("yellow", Color.yellow);
        ColorsDict.Add("green", Color.green);
        ColorsDict.Add("blue", Color.blue);

        ColorList.Add(Color.red);
        ColorList.Add(Color.yellow);
        ColorList.Add(Color.green);
        ColorList.Add(Color.cyan);
        ColorList.Add(Color.blue);
        ColorList.Add(Color.magenta);

        if (isRainbow_)
        {
            targetColor = ColorList[colorI];
        }
        else
            targetColor = changeColor_;

        startingColor = GetComponent<Image>().color;
        baseColor = startingColor;

        colorIterator = ColorList.GetEnumerator();
	}
	
		// Update is called once per frame
	void Update ()
	{
        elapsed += Time.deltaTime;

        counter += neg * Time.deltaTime;
        float t = counter / duration_;
        var spriteRender = GetComponent<Image>();

        if (spriteRender != null)
        {
            Color newColor = Color.Lerp(startingColor, targetColor, t);

            spriteRender.color = newColor;
        }

        if( isRainbow_ && counter > duration_ )
        {
            ++colorI;
            colorI %= ColorList.Count;

            startingColor = targetColor;
            targetColor = ColorList[colorI];

            counter = 0.0f;
        }
        else if (isRepeat_)
            checkAndReset(ref counter, ref duration_, ref neg);
    }

    void checkAndReset(ref float timecounter, ref float duration, ref float neg)
    {
        if (timecounter <= 0.0f)
        {
            neg = -neg;
            timecounter = 0.0f;
        }
        if (timecounter >= duration)
        {
            timecounter = duration;
            neg = -neg;
            return;
        }
        else
        {
            return;
        }
    }

    public void changeColor(Color nuColor, float nuDuration = -1.0f)
    {
        if (nuDuration >= 0.0f)
            duration_ = nuDuration;

        startingColor = GetComponent<Image>().color;
        targetColor = nuColor;
        counter = 0.0f;
    }

    public void resetColor(float nuDuration = -1.0f)
    {
        if (nuDuration >= 0.0f)
            duration_ = nuDuration;

        startingColor = GetComponent<Image>().color;
        targetColor = baseColor;
    }
}
