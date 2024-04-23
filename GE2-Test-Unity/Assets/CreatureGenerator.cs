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
    public float baseSize;
    public float multiplier;
    private GameObject bodyPart;
    public List<GameObject> segments;
    public float offset;

    private void OnDrawGizmos()
    {
        _spineAnimator = GetComponent<SpineAnimator>();
        bodyPart = Resources.Load<GameObject>("Prefabs/BodyBone");
        segments = new List<GameObject>();
        
        Gizmos.DrawCube(transform.position, transform.localScale);
        foreach (GameObject go in segments)
        {
            Gizmos.DrawCube(go.transform.localPosition, go.transform.localScale);
        }

        for (int i = 0; i < length; i++)
        {
            var bodySegment = Instantiate(bodyPart, new Vector3(transform.position.x, transform.position.y, transform.position.z - offset), Quaternion.identity, transform);
            segments.Add(bodySegment);
        }
        
    }

    void Start()
    {
       
    }


    void Update()
    {

    }
}
