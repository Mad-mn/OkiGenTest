using System.Collections;

using UnityEngine;

public class WallCube : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            
            ListOfCubes.cubes.Remove(other.gameObject);
            if (ListOfCubes.cubes.Count == 0)
            {
                ScreenController.isGameOver = true;
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                StopAllCoroutines();
            }
            else
            {
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                StartCoroutine(destroyCube(other.gameObject));
            }
        }
    }

    IEnumerator destroyCube(GameObject cube)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(cube);
    }
}
