using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatScript : MonoBehaviour
{

    // NIET IN GEBRUIK!

    [SerializeField]
    private float airDrag = 1;
    [SerializeField]
    private float waterDrag = 10;
    [SerializeField]
    private Transform[] floatPoints;
    [SerializeField]
    private bool attachToSurface = false;
    private bool affectDirection = true;

    protected Rigidbody rb;
    protected Waves waves;

    protected float waterLine;
    protected Vector3[] waterLinePoints;

    protected Vector3 centerOffset;
    protected Vector3 smoothVectorRotation;
    protected Vector3 targetUp;
    [SerializeField]
    private float speed;
    private Quaternion targetRot;
    public Vector3 center { get { return transform.position + centerOffset; } }
    // Start is called before the first frame update
    void Awake()
    {
        waves = FindObjectOfType<Waves>();
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

        waterLinePoints = new Vector3[floatPoints.Length];
        for (int i = 0; i <floatPoints.Length; i++)
        {
            waterLinePoints[i] = floatPoints[i].position;
            centerOffset = PhysicsHelper.GetCenter(waterLinePoints) - transform.position;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float newWaterLine = 0f;
        bool pointUnderWater = false;
        

        for (int i = 0; i < floatPoints.Length; i++)
        {
            waterLinePoints[i] = floatPoints[i].position;
            waterLinePoints[i].y = waves.GetHeight(floatPoints[i].position);
            newWaterLine += waterLinePoints[i].y / floatPoints.Length;
            if (waterLinePoints[i].y > floatPoints[i].position.y)
            {
                pointUnderWater = true;
            }
            var waterLineDelta = newWaterLine - waterLine;
            waterLine = newWaterLine;

            var gravity = Physics.gravity;
            rb.drag = airDrag;

            if (waterLine > center.y)
            {
                rb.drag = waterDrag;

                if (attachToSurface)
                {
                    rb.position = new Vector3(rb.position.x, waterLine - centerOffset.y, rb.position.z);
                }

                else
                {
                    gravity = affectDirection ? targetUp * -Physics.gravity.y : -Physics.gravity;
                    transform.Translate(Vector3.up * waterLineDelta * 0.9f);
                }
            }
            rb.AddForce(gravity * Mathf.Clamp(Mathf.Abs(waterLine - center.y), 0, 1));
            targetUp = PhysicsHelper.GetNormal(waterLinePoints);
            rb.rotation = Quaternion.RotateTowards(rb.rotation, targetRot, speed * Time.deltaTime);

            if (pointUnderWater)
            {
                targetUp = Vector3.SmoothDamp(transform.up, targetUp, ref smoothVectorRotation, 0.2f);
                targetRot =  Quaternion.FromToRotation(transform.up, targetUp) * rb.rotation;
                rb.rotation = Quaternion.RotateTowards(rb.rotation, targetRot, speed * Time.deltaTime);
              //  rb.rotation = Quaternion.Lerp(rb.rotation, targetRot, Time.deltaTime * speed);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if (floatPoints == null)
        {
            return;
        }

        for (int i = 0; i < floatPoints.Length; i++)
        {
            if (floatPoints[i] == null)
            {
                continue;
            }
            if (waves != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawCube(waterLinePoints[i], Vector3.one * 0.3f);
            }

            Gizmos.color = Color.green;
            Gizmos.DrawSphere(floatPoints[i].position, 0.1f);
        }

        if (Application.isPlaying)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(new Vector3(center.x, waterLine, center.z), Vector3.one * 1f);
        }
    }
}
