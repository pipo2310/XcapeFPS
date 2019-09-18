using System;
using System.Collections.Generic;

public class Matrix
{
    private int dimension;
    private int[][] matrix;
    private Tuple<int, int>[][] mirrorMatrix;

    public Matrix(int dimension)
    {
        this.dimension = dimension;
        this.matrix = new int[dimension][];
        this.mirrorMatrix = new Tuple<int, int>[dimension][];
        int row, col;
        for (row = 0; row < dimension; row++)
        {
            this.matrix[row] = new int[dimension];
            this.mirrorMatrix[row] = new Tuple<int, int>[dimension];
        }

        for (row = 0; row < dimension; row++)
        {
            for (col = 0; col < dimension; col++)
            {
                this.mirrorMatrix[row][col] = new Tuple<int, int>(1, 1);
            }
        }
    }

    public bool cellHasRightWall(int row, int col)
    {
        if (mirrorMatrix[row][col].Item1 == 1)
        {
            return true;
        } else
        {
            return false;
        }
    }

    public bool cellHasLowerWall(int row, int col)
    {
        if (mirrorMatrix[row][col].Item2 == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void setCellPathNumber(int cellNumber, int pathNumber)
    {
        int row = cellNumber / dimension;
        int col = cellNumber % dimension;
        matrix[row][col] = pathNumber;
    }

    public int getCellPathNumber(int cellNumber)
    {
        int row = cellNumber / dimension;
        int col = cellNumber % dimension;
        return matrix[row][col];
    }

    public List<int> getNeighborCells(int cellNumber)
    {
        List<int> neighborCells = new List<int>();

        int row = cellNumber / dimension;
        int col = cellNumber % dimension;
        int neighborCellNumber;
        if (row - 1 >= 0)
        {
            neighborCellNumber = (row - 1) * dimension + col;
            neighborCells.Add(neighborCellNumber);
        }

        if (col - 1 >= 0)
        {
            neighborCellNumber = row * dimension + (col - 1);
            neighborCells.Add(neighborCellNumber);
        }

        if (col + 1 < dimension)
        {
            neighborCellNumber = row * dimension + (col + 1);
            neighborCells.Add(neighborCellNumber);
        }

        if (row + 1 < dimension)
        {
            neighborCellNumber = (row + 1) * dimension + col;
            neighborCells.Add(neighborCellNumber);
        }

        return neighborCells;
    }

    public void deleteDivisionBetweenCells(int lowerCell, int higherCell)
    {
        int row = lowerCell / dimension;
        int col = lowerCell % dimension;
        Tuple<int, int> currentState = mirrorMatrix[row][col];
        if (higherCell - lowerCell == 1)
        {
            mirrorMatrix[row][col] = new Tuple<int, int>(0, currentState.Item2);
        }
        else
        {
            mirrorMatrix[row][col] = new Tuple<int, int>(currentState.Item1, 0);
        }
    }
}
