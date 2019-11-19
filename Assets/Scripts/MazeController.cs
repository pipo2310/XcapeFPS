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
    private int specialLength;
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
                    prefabExitWallUpperVariant.GetComponent<MeshRenderer>().material = bricks2;
                    prefabExitWallSideVariant.GetComponent<MeshRenderer>().material = bricks3;
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

        mazeGenerator = new MazeGenerator(cellsPerSide);
        mazeGenerator.run();

        // Instantiate at position (0, 0, 0) and zero rotation.
        //Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);

        //Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        //Quaternion rot = Quaternion.Euler(0, 90, 0);
        //Instantiate(prefab, new Vector3(0 - halfLength, 0, 0 + halfLength), rot);
        //Instantiate(prefab, new Vector3(0, 0, 10), Quaternion.identity);
        //Instantiate(prefab, new Vector3(0 + halfLength, 0, 0 + halfLength), rot);

        length =(int) prefabWall.transform.localScale.x;
        halfLength = length / 2;
        specialLength = halfLength / 2;

        int rowInd, colInd;
        float xCoord = 0, zCoord = 0;
        float xShift = halfLength, zShift = halfLength;
        //int colZombieInstantiation = 0;
        Quaternion rot = Quaternion.Euler(0, 90, 0);

        //for (rowInd = 0; rowInd < cellsPerSide; rowInd++)
        //{
        //    xCoord = (colInd * length) + halfLength;
        //    zCoord = (rowInd + 1) * length - halfLength;
        //    // Instantiate right wall for cuadrant
        //    Instantiate(prefab, new Vector3(xCoord, 0, zCoord), rot);

        //    xCoord = (colInd * length);
        //    zCoord = (rowInd + 1) * length;
        //    // Instantiate inferior wall for cuadrant
        //    Instantiate(prefab, new Vector3(xCoord, 0, zCoord), Quaternion.identity);
        //}

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
            xCoord = -halfLength;
            zCoord = (rowInd + 1) * length - halfLength;
            Instantiate(prefabWall, new Vector3(xCoord, 0, zCoord), rot);

            for (colInd = 0; colInd < cellsPerSide; colInd++)
            {
                if (rowInd != 0)
                {
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

                //Debug.Log("Coords (" + colInd + ", " + rowInd + ") -> " + cantZombies + "zombies");
                //if (colInd == colZombieInstantiation)
                //{
                //    xCoord = colInd * length;
                //    zCoord = ((rowInd + 1) * length) - halfLength;

                //    Vector2 tempPosition = (new Vector2(xCoord, zCoord)) + (Vector2) (Random.insideUnitCircle * (halfLength - 1));
                //    Vector3 position = new Vector3(tempPosition.x, (float)1.4, tempPosition.y);
                //    Debug.Log("Coords (" + colInd + ", " + rowInd + ") -> (" + xCoord + ", " + zCoord + ")");
                //    Debug.Log("pos: " + position);
                //    Instantiate(zombieEnemyPrefab, position, Quaternion.identity);
                //}

                if (rowInd == cellsPerSide - 1 && colInd == cellsPerSide - 1)
                {
                    xCoord = (colInd * length) + halfLength;
                    zCoord = (rowInd + 1) * length - halfLength;
                    // Instantiate right wall for cuadrant
                    Instantiate(prefabWall, new Vector3(xCoord, 0, zCoord), rot);

                    // Instantiate lower wall for cuadrant
                    xCoord = (colInd * length);
                    zCoord = (rowInd + 1) * length;
                    // Upper cube
                    exitUppperSide = Instantiate(prefabExitWallUpperVariant, new Vector3(xCoord, 8, zCoord), Quaternion.identity);
                    // Lower cube
                    Instantiate(prefabExit, new Vector3(xCoord, 3.5f, zCoord), Quaternion.identity);
                    xCoord = (colInd * length) - (float) 3.5;
                    // Left side cube
                    exitLeftSide = Instantiate(prefabExitWallSideVariant, new Vector3(xCoord, 0, zCoord), Quaternion.identity);
                    xCoord = (colInd * length) + (float) 3.5;
                    // Right side cube
                    exitRightSide = Instantiate(prefabExitWallSideVariant, new Vector3(xCoord, 0, zCoord), Quaternion.identity);
                }
                else
                {
                    if (mazeGenerator.cellHasRightWall(rowInd, colInd))
                    {
                        xCoord = (colInd * length) + halfLength;
                        zCoord = (rowInd + 1) * length - halfLength;
                        // Instantiate right wall for cuadrant
                        Instantiate(prefabWall, new Vector3(xCoord, 0, zCoord), rot);
                    }

                    if (mazeGenerator.cellHasLowerWall(rowInd, colInd))
                    {
                        xCoord = (colInd * length);
                        zCoord = (rowInd + 1) * length;
                        // Instantiate lower wall for cuadrant
                        Instantiate(prefabWall, new Vector3(xCoord, 0, zCoord), Quaternion.identity);
                    }
                }                
            }
            
        }
    }
}
