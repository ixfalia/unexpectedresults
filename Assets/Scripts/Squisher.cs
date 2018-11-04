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
        float neg = -1.0f;
        
        var componentTransform = GetComponent<RectTransform>();

        if ( componentTransform )
        {
            Vector3 currentScale = componentTransform.localScale;

            if (timeSince >= timeoffset_.x)
            {
                if (isWobble && timeState.x >= timeRate_.x)
                {
                    squishRate_.x = -squishRate_.x;
                }

                scalerate(ref currentScale.x, ref squishRate_.x);
            }

            componentTransform.localScale = currentScale;
        }//endif
	}// end Update()

    void scalerate(ref float transform, ref float modifier)
    {
        transform *= modifier;
    }
}// end class Squisher
