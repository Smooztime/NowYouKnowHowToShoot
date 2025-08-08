using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ChargingHandle : MonoBehaviour
{
    Vector3 startPos;
    [SerializeField] Transform pulledPos;
    [SerializeField] Transform chargingHandleTransform;
    public float lerpState;
    bool isGrabbed;
    [SerializeField] float resetSpeed;

    Transform controllerTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = chargingHandleTransform.position;
    }
    public void PullBackLerp()
    {
chargingHandleTransform.position = Vector3.Lerp(startPos,pulledPos.position,lerpState);
    }
    public void ReleasedChargingHandle()
    {
        lerpState -= Time.deltaTime * resetSpeed;
    }
    public void GrabStart(SelectEnterEventArgs args)
    {
        controllerTransform = args.interactorObject.transform;
    }
    // Update is called once per frame
    void Update()
    {
        PullBackLerp();
        if(!isGrabbed)
        {
            ReleasedChargingHandle();
        }
    }
}
