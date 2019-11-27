using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeController : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject prefabWall;
    public GameObject prefabExitWallUpperVariant;
    public GameObject prefabExitWallSideVariant;
    public GameObject prefabExit;
    public GameObject prefabZombieEnemy;
    public GameObject piso;

    private GameObject zombie;
    private GameObject exitLeftSide;
    private GameObject exitRightSide;
    private GameObject exitUppperSide;

    public Material bricks1;
    public Material bricks2;
    public Material bricks3;
    public Material hedge;
    public Material rocks;

    public Material exteriorGround1;
    public Material exteriorGround2;
    public Material interiorGround;

    public int cellsPerSide;
    public int minZombiesPerCellCount;
    public int maxZombiesPerCellCount;

    private int length;
    private int halfLength;
    //private int specialLength;
    private MazeGenerator mazeGenerator;

    // Start is called before the first frame update
    void Start()
    {
        if (GameParameters.completeFlow)
        {
            cellsPerSide = GameParameters.cellsPerSide;
            minZombiesPerCellCount = GameParameters.minZombiesPerCellCount;
            maxZombiesPerCellCount = GameParameters.maxZombiesPerCellCount;

            switch (GameParameters.level)
            {
                case 1:
                    prefabWall.GetComponent<MeshRenderer>().material = bricks1;
                    prefabExitWallSideVariant.GetComponent<MeshRenderer>().material = bricks2;
                    prefabExitWallUpperVariant.GetComponent<MeshRenderer>().material = bricks3;
                    piso.GetComponent<MeshRenderer>().material = interiorGround;
                    break;
                case 2:
                    prefabWall.GetComponent<MeshRenderer>().material = hedge;
                    prefabExitWallUpperVariant.GetComponent<MeshRenderer>().material = hedge;
                    prefabExitWallSideVariant.GetComponent<MeshRenderer>().material = hedge;
                    piso.GetComponent<MeshRenderer>().material = exteriorGround1;
                    break;
                case 3:
                    prefabWall.GetComponent<MeshRenderer>().material = rocks;
                    prefabExitWallUpperVariant.GetComponent<MeshRenderer>().material = rocks;
                    prefabExitWallSideVariant.GetComponent<MeshRenderer>().material = rocks;
                    piso.GetComponent<MeshRenderer>().material = exteriorGround2;
                    break;
            }
        }
        else
        {
            HealthGlobal.CurrentHealth = 100;
        }

        mazeGenerator = new MazeGenerator(cellsPerSide);
        mazeGenerator.run();

        // Instantiate at position (0, 0, 0) and zero rotation.
        //Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);

        //Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        //Quaternion rot = Quaternion.Euler(0, 90, 0);
        //Instantiate(prefab, new Vector3(0 - halfLength, 0, 0 + halfLength), rot);
        //Instantiate(prefab, new Vector3(0, 0, 10), Quaternion.identity);
        //Instantiate(prefab, new Vector3(0 + halfLength, 0, 0 + halfLength), rot);

        length = (int)prefabWall.transform.localScale.x;
        halfLength = length / 2;
        //specialLength = halfLength / 2;

        int rowInd, colInd;
        float xCoord = 0, zCoord = 0;
        float xShift = halfLength, zShift = halfLength;
        Quaternion rot = Quaternion.Euler(0, 90, 0);

        // Instantiate upper walls for cuadrants
        for (colInd = 0; colInd < cellsPerSide; colInd++)
        {
            xCoord = (colInd * length);
            zCoord = 0;
            Instantiate(prefabWall, new Vector3(xCoord, 0, zCoord), Quaternion.identity);
        }

        for (rowInd = 0; rowInd < cellsPerSide; rowInd++)
        {
            // Instantiate left wall for cuadrant
            xCoord = -halfLength + 0.5f;
            zCoord = (rowInd + 1) * length - halfLength;
            Instantiate(prefabWall, new Vector3(xCoord, 0, zCoord), rot);

            for (colInd = 0; colInd < cellsPerSide; colInd++)
            {
                if (rowInd != 0)
                {
                    // Zombies for this quadrant
                    int cantZombies = Random.Range(minZombiesPerCellCount, maxZombiesPerCellCount + 1);
                    for (int i = 0; i < cantZombies; i++)
                    {
                        xCoord = colInd * length;
                        zCoord = ((rowInd + 1) * length) - halfLength;

                        Vector2 tempPosition = (new Vector2(xCoord, zCoord)) + (Vector2)(Random.insideUnitCircle * (halfLength - 1));
                        Vector3 position = new Vector3(tempPosition.x, (float)1.4, tempPosition.y);
                        Instantiate(prefabZombieEnemy, position, Quaternion.identity);
                    }
                }

                // Instantiate right wall for cuadrant
                zCoord = (rowInd + 1) * length - halfLength;
                if (colInd == cellsPerSide - 1)
                {
                    xCoord = (colInd * length) + halfLength - 0.5f;
                    Instantiate(prefabWall, new Vector3(xCoord, 0, zCoord), rot);
                }
                else
                {
                    if (mazeGenerator.cellHasRightWall(rowInd, colInd))
                    {
                        xCoord = (colInd * length) + halfLength;
                        Instantiate(prefabWall, new Vector3(xCoord, 0, zCoord), rot);
                    }
                }

                // Instantiate lower wall for cuadrant
                xCoord = (colInd * length);
                zCoord = (rowInd + 1) * length;
                if (rowInd == cellsPerSide - 1)
                {
                    if (colInd == cellsPerSide - 1)
                    {
                        // Exit components

                        // Upper cube
                        exitUppperSide = Instantiate(prefabExitWallUpperVariant, new Vector3(xCoord, 8, zCoord), Quaternion.identity);

                        // Lower cube
                        Instantiate(prefabExit, new Vector3(xCoord, 3.5f, zCoord), Quaternion.identity);

                        // Left side cube
                        xCoord = (colInd * length) - (float)3.5;
                        Instantiate(prefabExitWallSideVariant, new Vector3(xCoord, 0, zCoord), Quaternion.identity);

                        // Right side cube
                        xCoord = (colInd * length) + (float)3.5;
                        Instantiate(prefabExitWallSideVariant, new Vector3(xCoord, 0, zCoord), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(prefabWall, new Vector3(xCoord, 0, zCoord), Quaternion.identity);
                    }
                }
                else
                {
                    if (mazeGenerator.cellHasLowerWall(rowInd, colInd))
                    {
                        Instantiate(prefabWall, new Vector3(xCoord, 0, zCoord), Quaternion.identity);
                    }
                }
            }

        }
    }
}
