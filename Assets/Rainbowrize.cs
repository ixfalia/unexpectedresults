using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rainbowrize : MonoBehaviour
{
    [SerializeField]
    Color changeColor_ = new Color();

    [SerializeField]
    float duration_ = 1.0f;

    [SerializeField]
    bool isRepeat_ = true;

    [SerializeField]
    bool isRainbow_ = true;

    private float elapsed = 0.0f;
    private float counter = 0.0f;
    private float neg = 1.0f;
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
        ColorList.Add(Color.blue);

        if (isRainbow_)
        {
            targetColor = ColorList[colorI];
        }
        else
            targetColor = changeColor_;

        startingColor = GetComponent<Canvas>().color;

        colorIterator = ColorList.GetEnumerator();
	}
	
		// Update is called once per frame
	void Update ()
	{
        elapsed += Time.deltaTime;

        counter += neg * Time.deltaTime;
        float t = counter / duration_;
        var spriteRender = GetComponent<>();
        Color currentColor = spriteRender.color;

        if (currentColor != null)
        {
            Color newColor = Color.Lerp(startingColor, targetColor, t);
            currentColor = newColor;
        }

        if( isRainbow_ && counter > duration_ )
        {
            ++colorI;
            colorI %= ColorList.Count;

            targetColor = ColorList[colorI];

            counter = 0.0f;
        }
        else if (isRepeat_)
            checkAndReset(ref counter, ref duration_, ref neg);
    }

    void checkAndReset(ref float timecounter, ref float duration, ref float neg)
    {
        if (timecounter >= duration ^ timecounter <= 0.0f)
        {
            //timecounter = 0.0f;
            neg = -neg;
            return;
        }
        else
        {
            return;
        }
    }
}
