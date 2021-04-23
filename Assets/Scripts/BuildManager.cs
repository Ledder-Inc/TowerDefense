using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            //Debug.LogError("Mehr als ein BuildManager!");
            return;
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;

    public GameObject missileLauncherPrefab;

    public GameObject laserTurretPrefab;

    public GameObject buildEffect;

    private Node selectedNode;

    public NodeUI nodeUI;

    /*
    private void Start()
    {
        turretToBuild = standardTurretPrefab;
    }
    */
    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;

        DeselectNode();
    }

    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
            return;

        PlayerStats.Money -= turretToBuild.cost;

        Debug.Log("Erstelle Geschütz");
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 2f);

        Debug.Log("Money left: " + PlayerStats.Money);
    }

    public void DestroyTurretOn(Node node)
    {
        if (node.turret = null)
            return;
        
        Debug.Log("Zerstöre Geschütz");
        //Turret turret = node.turret.GetComponent<Turret>();
        Destroy(node.turret);

    }
}
