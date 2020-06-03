using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARHumanBodyTracker : MonoBehaviour
{

    public GameObject skeletonPrefab;
    public ARHumanBodyManager humanBodyManager;

    private Dictionary<TrackableId, HumanBoneController> skeletonTracker = new Dictionary<TrackableId, HumanBoneController>();
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnHumanBodiesChanged(ARHumanBodiesChangedEventArgs eventArgs)
    {
        HumanBoneController humanBoneController;

        foreach(var bodyPart in eventArgs.added)
        {
            if (!skeletonTracker.TryGetValue(bodyPart.trackableId, out humanBoneController))
            {
                var newSkeletonGameObject = Instantiate(skeletonPrefab, bodyPart.transform);
                humanBoneController = newSkeletonGameObject.GetComponent<HumanBoneController>();
                skeletonTracker.Add(bodyPart.trackableId, humanBoneController);
            }

            humanBoneController.InitializeSkeletonJoints();
            humanBoneController.ApplyBodyPose(bodyPart, Vector3.zero);
        }

        foreach(var bodyPart in eventArgs.updated)
        {
            if (skeletonTracker.TryGetValue(bodyPart.trackableId, out humanBoneController))
            {
                humanBoneController.ApplyBodyPose(bodyPart, Vector3.zero);
            }
        }

        foreach(var bodyPart in eventArgs.removed)
        {
            if (skeletonTracker.TryGetValue(bodyPart.trackableId, out humanBoneController))
            {
                Destroy(humanBoneController.gameObject);
                skeletonTracker.Remove(bodyPart.trackableId);
            }

        }


    }

    private void OnEnable()
    {
        humanBodyManager.humanBodiesChanged += OnHumanBodiesChanged;
    }

    private void OnDisable()
    {
        humanBodyManager.humanBodiesChanged -= OnHumanBodiesChanged;
    }
}
