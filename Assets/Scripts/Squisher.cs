using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Squisher : MonoBehaviour
{
    [SerializeField]
    bool isWobble = false;

    [SerializeField]
    Vector3 squishRate_ = new Vector3(1, 1, 1), squishAbsolute_ = new Vector3(1, 1, 1);

    //[SerializeField]
    //Vector2 squishAbsolute_;

    [SerializeField]
    bool useAbsolute_ = false;

    [SerializeField]
    Vector3 timeRate_ = new Vector3(0, 0, 0), timeoffset_ = new Vector3(0, 0, 0);

    private float timeSince;
    private Vector3 timeState = new Vector3(0, 0, 0);
    private Vector3 currentTimeState;

        // Use this for initialization
    void Start()
    {
        timeSince = 0.0f;
        timeState.Set(0.0f, 0.0f, 0.0f);
    }

		// Update is called once per frame
	void Update ()
	{
        timeSince += Time.deltaTime;
        currentTimeState.Set(timeSince, timeSince, timeSince);
        
        var componentTransform = GetComponent<RectTransform>();

        if ( componentTransform )
        {
            Vector3 currentScale = componentTransform.localScale;

            if (timeSince >= timeoffset_.x)
            {
                scalerate(ref currentScale.x, ref squishRate_.x, timeState.x, ref timeRate_.x);
            }

            componentTransform.localScale = currentScale;
        }//endif
	}// end Update()

    void scalerate(ref float transform, ref float modifier, float timeState, ref float timeRate)
    {
        if (isWobble && timeState >= timeRate)
        {
            modifier = -modifier;
            timeRate = 0.0f;
        }

        transform *= modifier;
    }
}// end class Squisher
