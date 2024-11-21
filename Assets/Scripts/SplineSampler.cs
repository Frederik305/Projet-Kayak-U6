using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using Unity.Mathematics;
using UnityEditor;
using System.Security.Cryptography;

[ExecuteInEditMode()]
public class SplineSampler : MonoBehaviour
{
    [SerializeField] private SplineContainer splineContainer;
    [SerializeField] private int splineIndex;
    [SerializeField] [Range(0f,1f)] private float time;

    [SerializeField] private float widthLeft = 1;
    [SerializeField] private float widthRight = 1;

    float3 position;
    float3 tangent;
    float3 upVector;

    float3 p1;
    float3 p2;

    private void Update()
    {
        splineContainer.Evaluate(splineIndex, time, out position, out tangent, out upVector);

        float3 right = Vector3.Cross(tangent, upVector).normalized;
        p1 = position + (right * widthLeft);
        p2 = position + (-right * widthRight);

        float curvature = CalculateCurvature(time);
        //Debug.Log($"t: {time}, position: {position}, tangent: {tangent}, upVector: {upVector}");
        //Debug.Log($"Curvature at time {time}: {curvature}");
    }

    public void SampleSpline(float t, out Vector3 outP1, out Vector3 outP2)
    {
        // Sample spline at the given t value
        splineContainer.Evaluate(splineIndex, t, out position, out tangent, out upVector);

        

        // Calculate right vector
        float3 right = Vector3.Cross(tangent, upVector).normalized;

        outP1 = position + (right * widthLeft);
        outP2 = position + (-right * widthRight);
    }

    private float CalculateCurvature(float t)
    {
        // Small delta for numerical differentiation
        float delta = 0.01f;

        // First derivative (tangent)
        splineContainer.Evaluate(splineIndex, t, out float3 position1, out float3 tangent1, out _);

        // Second derivative
        splineContainer.Evaluate(splineIndex, t + delta, out float3 position2, out float3 tangent2, out _);

        // Calculate curvature using the formula
        float3 deltaTangent = tangent2 - tangent1;
        float curvature = math.length(deltaTangent) / delta;

        return curvature;
    }

    private void OnDrawGizmos()
    {
        // Draw spheres at the central position, p1, and p2
        Handles.color = Color.red;
        Handles.SphereHandleCap(0, position, Quaternion.identity, 0.5f, EventType.Repaint);

        Handles.color = Color.blue;
        Handles.SphereHandleCap(0, p1, Quaternion.identity, 0.5f, EventType.Repaint);
        Handles.SphereHandleCap(0, p2, Quaternion.identity, 0.5f, EventType.Repaint);

        Handles.color = Color.green;
        // Draw a line between p1 and p2 to represent the width
        Handles.DrawLine(p1, p2);
    }
}
