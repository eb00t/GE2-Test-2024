using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CreatureGenerator : MonoBehaviour
{
    private SpineAnimator _spineAnimator;
    public float length;
    public float frequency;
    public Quaternion startAngle;
    public Vector3 baseSize;
    public float multiplier;
    private GameObject bodyPart;
    public List<GameObject> segments;

    private void OnDrawGizmos()
    {
        _spineAnimator = GetComponent<SpineAnimator>();
        transform.localScale = baseSize;
        transform.rotation = startAngle;
        
        for (int i = 0; i < length + 1; i++)
        {
            Vector3 scaleSize = baseSize * frequency * i;
            Vector3 segPos = new Vector3(transform.localPosition.x, transform.localPosition.y,
                transform.localPosition.z - (scaleSize.z * i));
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireCube(segPos, scaleSize);
        }
        
    }

    void Start()
    {
        segments = new List<GameObject>();
        bodyPart = Resources.Load<GameObject>("Prefabs/BodyBone");
        for (int i = 0; i < length + 1; i++)
        {
            Vector3 scaleSize = baseSize * frequency * i;
            Vector3 segPos = new Vector3(transform.localPosition.x, transform.localPosition.y,
                (transform.localPosition.z - (scaleSize.z * i)));
            var bodySegment = Instantiate(bodyPart, segPos, startAngle);
            bodySegment.transform.localScale = scaleSize;
            segments.Add(bodySegment);
        }
    }
}
