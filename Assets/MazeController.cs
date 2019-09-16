using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeController : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject prefab;
    public int cellsPerSide;
    public int length; // TIENE QUE COINCIDIR CON LA LONGITUD DE WALL (PREFAB)
    private int halfLength;
    private MazeGenerator mazeGenerator;

    // Start is called before the first frame update
    void Start()
    {
        mazeGenerator = new MazeGenerator(cellsPerSide);
        mazeGenerator.run();

        // Instantiate at position (0, 0, 0) and zero rotation.
        //Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);

        //Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        //Quaternion rot = Quaternion.Euler(0, 90, 0);
        //Instantiate(prefab, new Vector3(0 - halfLength, 0, 0 + halfLength), rot);
        //Instantiate(prefab, new Vector3(0, 0, 10), Quaternion.identity);
        //Instantiate(prefab, new Vector3(0 + halfLength, 0, 0 + halfLength), rot);

        halfLength = length / 2;
        int rowInd, colInd, xCoord, zCoord;
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
            Instantiate(prefab, new Vector3(xCoord, 0, zCoord), Quaternion.identity);
        }

        for (rowInd = 0; rowInd < cellsPerSide; rowInd++)
        {
            // Instantiate left wall for cuadrant
            xCoord = -halfLength;
            zCoord = (rowInd + 1) * length - halfLength;
            Instantiate(prefab, new Vector3(xCoord, 0, zCoord), rot);

            for (colInd = 0; colInd < cellsPerSide; colInd++)
            {
                if (mazeGenerator.cellHasRightWall(rowInd, colInd))
                {
                    xCoord = (colInd * length) + halfLength;
                    zCoord = (rowInd + 1) * length - halfLength;
                    // Instantiate right wall for cuadrant
                    Instantiate(prefab, new Vector3(xCoord, 0, zCoord), rot);
                }

                if (mazeGenerator.cellHasLowerWall(rowInd, colInd))
                {
                    xCoord = (colInd * length);
                    zCoord = (rowInd + 1) * length;
                    // Instantiate lower wall for cuadrant
                    Instantiate(prefab, new Vector3(xCoord, 0, zCoord), Quaternion.identity);
                }
            }
            
        }
    }
}
