using System;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator
{
    private int dimension;
    private int totalCells;
    private Matrix matrix;
    private List<int> activeSet;
    private int pathCount;

    public MazeGenerator(int dimension)
	{
        this.dimension = dimension;
        this.totalCells = dimension * dimension;
        this.matrix = new Matrix(dimension);
        this.activeSet = new List<int>();
        this.pathCount = 1;
    }

    public bool cellHasRightWall(int row, int col)
    {
        return matrix.cellHasRightWall(row, col);
    }

    public bool cellHasLowerWall(int row, int col)
    {
        return matrix.cellHasLowerWall(row, col);
    }

    public void run()
    {
        int currentCellNumber, neighborCellNumber;
        currentCellNumber = UnityEngine.Random.Range(0, totalCells);

        // TODO: Borrar
        Debug.Log("first cell: " + currentCellNumber);

        addCellToActiveSet(currentCellNumber);
        while (activeSet.Count != 0)
        {
            currentCellNumber = getCellFromActiveSet();
            List<int> neighborCells = matrix.getNeighborCells(currentCellNumber);
            Shuffle(neighborCells);            
            bool found = false;
            while (neighborCells.Count != 0 && !found)
            {
                neighborCellNumber = neighborCells[0];
                if (matrix.getCellPathNumber(neighborCellNumber) == 0)
                {
                    found = true;
                    if (currentCellNumber < neighborCellNumber)
                    {
                        matrix.deleteDivisionBetweenCells(currentCellNumber, neighborCellNumber);
                    }
                    else
                    {
                        matrix.deleteDivisionBetweenCells(neighborCellNumber, currentCellNumber);
                    }
                    addCellToActiveSet(neighborCellNumber);
                }
                else
                {
                    neighborCells.Remove(neighborCellNumber);
                }
            }

            if (neighborCells.Count == 0)
            {
                removeCellFromActiveSet();
            }
        }
    }

    private void addCellToActiveSet(int cellNumber)
    {
        activeSet.Add(cellNumber);
        matrix.setCellPathNumber(cellNumber, pathCount);
        pathCount++;
    }

    private int getCellFromActiveSet()
    {
        return activeSet[activeSet.Count - 1];
    }

    private void removeCellFromActiveSet()
    {
        activeSet.RemoveAt(activeSet.Count - 1);
    }

    public void Shuffle(List<int> list)
    {
        int count = list.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = list[i];
            list[i] = list[r];
            list[r] = tmp;
        }
    }
}
