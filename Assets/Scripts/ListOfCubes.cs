
using System.Collections.Generic;
using UnityEngine;

public class ListOfCubes : MonoBehaviour
{
    public static List<GameObject> cubes;
    private GameObject lastCube;
    public GameObject firstCube;
    public GameObject player;

  
    private void Start()
    {
        cubes = new List<GameObject>();
        
        cubes.Add(firstCube);
    }

    private void Update()
    {
        if (cubes.Count > 0) {
            if (lastCube != cubes[cubes.Count - 1])
            {
                lastCube = cubes[cubes.Count - 1];
                gameObject.GetComponent<PlayerController>().mainCube = lastCube;
            }

            foreach (GameObject cube in cubes)
            {
                if (cube != lastCube)
                {
                    int index = cubes.IndexOf(cube);
                    int yPos = cubes.Count - 1 - index;
                    cube.transform.position = new Vector3(lastCube.transform.position.x, lastCube.transform.position.y + (2 * yPos), lastCube.transform.position.z);
                    cube.transform.rotation = Quaternion.LookRotation(lastCube.transform.forward);
                    cube.GetComponent<Rigidbody>().velocity = lastCube.GetComponent<Rigidbody>().velocity;
                }
            }

            player.transform.position = new Vector3(lastCube.transform.position.x, cubes[0].transform.position.y + 1f, lastCube.transform.position.z);
            player.transform.rotation = Quaternion.LookRotation(lastCube.transform.forward);
        }


    }

    
}
