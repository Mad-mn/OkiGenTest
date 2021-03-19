using UnityEngine;

public class RotationCollition : MonoBehaviour
{
    private float angle;
    private GameObject cube;
   

    private void OnTriggerStay(Collider other)
    {
        
        if (other.CompareTag("RotationRoadRight"))
        {
            if (cube != other.gameObject)
            {
                cube = other.gameObject;
                angle = gameObject.transform.eulerAngles.y;
            }
            rotation(other, -90f);
        }
        if (other.CompareTag("RotationRoadLeft"))
        {
            if (cube != other.gameObject)
            {
                cube = other.gameObject;
                angle = gameObject.transform.eulerAngles.y;
            }
            rotation(other, 90f);
        }

    }

    private void rotation(Collider obj, float angle)
    {
        transform.LookAt(obj.gameObject.transform.GetChild(2).transform.position, transform.up);
        float nowAngle = transform.eulerAngles.y + angle;
        transform.eulerAngles = new Vector3(0, nowAngle, 0);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("RotationRoadRight"))
        {
            transform.eulerAngles = new Vector3(0, angle + 90f, 0);
        }
        if (other.CompareTag("RotationRoadLeft"))
        {
            transform.eulerAngles = new Vector3(0, angle - 90f, 0);
        }

    }
}
