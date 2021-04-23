using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodes : MonoBehaviour
{
    public static Transform[] nodes;

    private Transform node;

    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserTurret;

    private BuildManager buildManager;

    private bool build;
    void Awake()
    {
        nodes = new Transform[transform.childCount];
        for (int i = 0; i < nodes.Length; i++)
        {
            nodes[i] = transform.GetChild(i);
        }

        build = false;
    }

    private void Start()
    {
        buildManager = BuildManager.instance;
        //buildManager.SelectTurretToBuild(standardTurret);
        buildManager.SelectTurretToBuild(missileLauncher);
        //buildManager.SelectTurretToBuild(laserTurret);
    }
    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("v") && !build)
        {
            build = true;
            Debug.Log("BuildAll");
            BuildAll();
        }
        if (Input.GetKeyDown("x") && build)
        {
            build = false;
            Debug.Log("DestroyAll");
        }
    }

    private void BuildAll()
    {
        for (int i = 0; i < nodes.Length; i++)
        {
            node = nodes[i].transform;
            buildManager.BuildTurretOn(node.GetComponent<Node>());
        }
        
    }

    private void DestroyAll()
    {
        for (int i = 0; i < nodes.Length; i++)
        {
            node = nodes[i].transform;
            if (node.GetComponent<Node>().turret = null)
            {
                return;
            }
            buildManager.BuildTurretOn(node.GetComponent<Node>());
        }

    }
}
