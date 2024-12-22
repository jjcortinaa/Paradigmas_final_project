using UnityEngine;

public class WM : MonoBehaviour
{
    public WheelCollider wheel;
    public MeshRenderer parentMeshRenderer; // Change type to MeshRenderer
    public bool wheelTurn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Transform parent = parentMeshRenderer.transform; // Get the Transform component

        if (wheelTurn == true)
        {
            parent.localEulerAngles = new Vector3(
                parent.localEulerAngles.x,
                wheel.steerAngle - parent.localEulerAngles.z,
                parent.localEulerAngles.z
            );
        }

        parent.Rotate(wheel.rpm / 60 * 360 * Time.deltaTime, 0, 0);
    }
}
