
using UnityEngine;

public class DetectCubeCollider : MonoBehaviour
{
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Cube") && !collision.transform.GetComponent<isOnStack>().isOn && gameObject.GetComponent<isOnStack>().isOn)
        {

            collision.transform.GetComponent<isOnStack>().isOn = true;
            collision.gameObject.transform.GetComponent<Rigidbody>().isKinematic = false;
            
            ListOfCubes.cubes.Insert(0, collision.gameObject);
        }
        if (collision.transform.CompareTag("ObstacleCube") || collision.transform.CompareTag("Cube"))
        {
            PlayerController.isOnOC = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("ObstacleCube") || collision.transform.CompareTag("Cube"))
        {
            PlayerController.isOnOC = false;
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            CoinCount.count++;
            
            Destroy(other.gameObject);
        }
        if (other.CompareTag("FinishLine"))
        {
            ScreenController.isLvlPassed = true;
        }
    }

}
