using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleWeapon : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f, ~(1 << 2)))
        {
            //var angle = AngleTrejoktory(hit.point);
            var angle2 = CalculateProjectileFiringSolution(transform.position, hit.point, 18.5f);

            Debug.Log(angle2);
            transform.localRotation = Quaternion.Euler(angle2 -90, -180, 90);
        }
    }

    float AngleTrejoktory(Vector3 target)
    {
        float actualDistance = Vector3.Distance(transform.position, target);

        float v = 18.5f;
        float g = Physics.gravity.y;
        float x = actualDistance;
        float y = 0;

        float v2 = v * v;
        float v4 = v * v * v * v;

        float gx2 = g * x * x;
        float yv2 = 2 * y * v * v;
        float gx = g * x;

        float res = Mathf.Sqrt(v4 - g * (gx2 + yv2));
        float res1 = v2 + res;
        float res2 = res1 / gx;

        float trajectoryAngle = Mathf.Atan(res2) * 180 / Mathf.PI;

        //Debug.Log(trajectoryAngle);

        if (float.IsNaN(trajectoryAngle))
        {
            trajectoryAngle = 0;
        }
        return trajectoryAngle;
    }

    float CalculateProjectileFiringSolution(Vector3 from, Vector3 target, float speed)
    {
        float y = from.y - target.y;
        target.y = from.y = 0;

        float x = (target - from).magnitude;
        float v = speed;
        float g = Physics.gravity.y;
        //Debug.Log(g);
        float sqrt = (v * v * v * v) - (g * (g * (x * x) + 2 * y * (v * v)));
        // Not enough range
        if (sqrt == 0)
            return 0.0f;

        var angle = Mathf.Atan(((v * v) - Mathf.Sqrt(sqrt)) / (g * x));

        if (float.IsNaN(angle))
            return 0f;
        else
            return angle;
    }


}
