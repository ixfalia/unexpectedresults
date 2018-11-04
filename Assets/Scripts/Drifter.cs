using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drifter : MonoBehaviour
{
    [SerializeField]
    bool isRepeat = true;

    [SerializeField]
    Vector3 drift_ = new Vector3(0, 0, 0);

    [SerializeField]
    float duration_ = 1.0f, offset_ = 0.0f;

    private float elapsed = 0.0f;
    private Vector3 timeCounters = new Vector3(0, 0, 0);
    private Vector3 StartingPosition;
    private float neg = 1.0f;

		// Use this for initialization
	void Start ()
	{
        StartingPosition = GetComponent<RectTransform>().anchoredPosition3D;
	}
	
		// Update is called once per frame
	void Update ()
	{
        elapsed += Time.deltaTime;
        float delta = neg * Time.deltaTime;

        timeCounters.x += delta;
        timeCounters.y += delta;
        timeCounters.z += delta;

        if (elapsed >= offset_)
        {
            var componentTransform = GetComponent<RectTransform>();

            if(componentTransform != null)
            {
                Vector3 translate = componentTransform.localPosition;

                translate.x = Mathf.Lerp(StartingPosition.x, StartingPosition.x + drift_.x, timeCounters.x);
                translate.y = Mathf.Lerp(StartingPosition.y, StartingPosition.y + drift_.y, timeCounters.y);
                translate.z = Mathf.Lerp(StartingPosition.z, StartingPosition.z + drift_.z, timeCounters.z);

                componentTransform.localPosition = translate;
            }//end if

            checkAndReset(ref timeCounters.x, ref duration_);
            checkAndReset(ref timeCounters.y, ref duration_);
            checkAndReset(ref timeCounters.z, ref duration_);
        }//end if
	}//end Update()

    void checkAndReset(ref float timecounter, ref float duration)
    {
        if(timecounter >= duration || timecounter <= 0.0f)
        {
            //timecounter = 0.0f;
            neg = -neg;
        }
        else
        {
            return;
        }
    }
}
