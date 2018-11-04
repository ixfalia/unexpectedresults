using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drifter : MonoBehaviour
{
    [SerializeField]
    bool isRepeat = true;

    [SerializeField]
    Vector3 drift_ = new Vector3(0, 0, 0), durations_ = new Vector3(1.0f, 1.0f, 1.0f);

    [SerializeField]
    float offset_ = 0.0f;

    private float elapsed = 0.0f;
    private Vector3 timeCounters = new Vector3(0, 0, 0);
    private float timeCounter = 0.0f;
    private Vector3 StartingPosition;
    private Vector3 negs = new Vector3(1.0f,1.0f,1.0f);
    //private float neg = 1.0f;

		// Use this for initialization
	void Start ()
	{
        StartingPosition = GetComponent<RectTransform>().anchoredPosition;
	}
	
		// Update is called once per frame
	void Update ()
	{
        //if (!isRepeat && (elapsed > durations_.x || elapsed > durations_.y || elapsed > durations_.z))
        //    return;

        elapsed += Time.deltaTime;
        float delta = Time.deltaTime;

        timeCounters.x += negs.x * delta;
        timeCounters.y += negs.y * delta;
        timeCounters.z += negs.z * delta;

        if (elapsed >= offset_)
        {
            var componentTransform = GetComponent<RectTransform>();

            if (componentTransform != null)
            {
                Vector3 translate = new Vector3();

                translate.x = Mathf.Lerp(StartingPosition.x, StartingPosition.x + drift_.x, timeCounters.x / durations_.x);
                translate.y = Mathf.Lerp(StartingPosition.y, StartingPosition.y + drift_.y, timeCounters.y / durations_.y);
                translate.z = Mathf.Lerp(StartingPosition.z, StartingPosition.z + drift_.z, timeCounters.z / durations_.z);

                componentTransform.anchoredPosition = translate;
            }//end if

            checkAndReset(ref timeCounters.x, ref durations_.x, ref negs.x);
            checkAndReset(ref timeCounters.y, ref durations_.y, ref negs.y);
            checkAndReset(ref timeCounters.z, ref durations_.z, ref negs.z);
        }//end if
        else
        {
            int flower = 0;
        }
	}//end Update()

    void checkAndReset(ref float timecounter, ref float duration, ref float neg)
    {
        if(timecounter >= duration ^ timecounter <= 0.0f)
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
