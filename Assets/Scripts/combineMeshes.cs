using UnityEngine;
using System.Collections;
using UnityEditor;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class combineMeshes : MonoBehaviour
{

    GameObject highlight;

    void Start()
    {
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];

        Mesh finalMesh = new Mesh();

        int i = 0;
        while (i < meshFilters.Length)
        {
            Debug.Log(meshFilters[i].gameObject.transform.name);
            combine[i].subMeshIndex = 0;
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            //meshFilters[i].gameObject.active = false;
            i++;
        }

        finalMesh.CombineMeshes(combine);
        GetComponent<MeshFilter>().sharedMesh = finalMesh;

        /*
        transform.GetComponent<MeshFilter>().mesh = new Mesh();
        transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
        transform.gameObject.SetActive(true);
        */

        saveMesh();
    }

    void saveMesh()
    {
        Debug.Log("Saving Mesh?");
        //Mesh m1 = GetComponent<MeshFilter>().sharedMesh;
        //AssetDatabase.CreateAsset(m1, "Assets/MeshPieces/" + transform.name + ".asset"); // saves to "assets/"
        //AssetDatabase.SaveAssets();
    }
}
