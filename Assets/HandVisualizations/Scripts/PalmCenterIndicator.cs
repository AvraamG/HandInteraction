using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalmCenterIndicator : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FollowPalmCenter();
    }

    void FollowPalmCenter()
    {
        //Get the X n Y positional info from the palm Center.
        Vector2 palmCenter2DPosition = ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info.palm_center;

        //Get the Z position of the entire hand. This is a value of of min=0 and max=1. **If your content is spread around X units multiply the depth by this value.
        float entireHandDepthEstimation = ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info.depth_estimation;

        Vector3 palm3DPosition = ManoUtils.Instance.CalculateWorldPosition(palmCenter2DPosition, entireHandDepthEstimation);

        //Interpolate towards that position
        this.transform.position = Vector3.Lerp(this.transform.position, palm3DPosition, 0.9f);
    }

    void DetectInteractables()
    {
        Vector3 origin;
        Vector3 direction;
    }
}
