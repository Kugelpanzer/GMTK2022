using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Linq.Expressions;
using GMTK2020;
public class point
{
    public point(int x, int y, int value = 0)
    {
        this.x = x;
        this.y = y;
        this.value = value;

    }
    public int x, y;
    public int value;

}

public static class PathfindingScript
{
    static void PrintBoard(int[,] board)
    {
        string str = "";
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[i, j] > 9)
                {
                    str += " - ";
                }
                else if (board[i, j] == -1)
                {
                    str += " * ";
                }
                else
                {
                    str += " " + board[i, j].ToString() + " ";
                }

            }
            str += "\n";
        }
        Debug.Log(str);
    }
    public static int[,] GetPath(CritterType[,] board, point a, point b)
    {

        int[,] filtered = CreateBoard(board, new List<CritterType>() { CritterType.wall, CritterType.enemy, CritterType.player }, a);
        //PrintBoard(filtered);
        List<point> checkList = new List<point>();
        List<point> nextCheckList = new List<point>();
        checkList.Add(b);
        while (checkList.Count != 0)
        {
            foreach (point p in checkList)
            {
                List<point> newPoints = GetNeighbours(filtered, p);
                if (newPoints.Count != 0)
                    foreach (point np in newPoints)
                    {
                        nextCheckList.Add(np);
                    }
            }
            checkList = nextCheckList;
            nextCheckList = new List<point>();
        }
        //PrintBoard(filtered);
        return filtered;
    }

    static int[,] CreateBoard(CritterType[,] board, List<CritterType> obstacles, point selfPoint)
    {
        int[,] filtered = new int[board.GetLength(0), board.GetLength(1)];
        for (int i = 0; i < board.GetLength(0); i++)
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (obstacles.Contains(board[i, j]) && !(i == selfPoint.y && j == selfPoint.x))
                {
                    filtered[i, j] = -1;
                }
                else
                {
                    filtered[i, j] = -2;
                }
            }

        return filtered;
    }

    public static point MinPoint(List<point> listOfPoints)
    {
        point min = listOfPoints[0];

        for (int i = 1; i < listOfPoints.Count; i++)
        {
            if (listOfPoints[i].value < min.value)
            {
                min = listOfPoints[i];
            }
        }

        return min;
    }


    //----------------------------------------------------------------------------------------------------------------------------
    static List<point> GetNeighbours(int[,] board, point self)
    {
        List<point> pointList = new List<point>();
        if (CheckPoint(board, self.x, self.y + 1))
        {
            pointList.Add(new point(self.x, self.y + 1));
            board[self.y + 1, self.x] = board[self.y, self.x] + 1;
        }
        if (CheckPoint(board, self.x + 1, self.y))
        {
            pointList.Add(new point(self.x + 1, self.y));
            board[self.y, self.x + 1] = board[self.y, self.x] + 1;
        }
        if (CheckPoint(board, self.x, self.y - 1))
        {
            pointList.Add(new point(self.x, self.y - 1));
            board[self.y - 1, self.x] = board[self.y, self.x] + 1;
        }
        if (CheckPoint(board, self.x - 1, self.y))
        {
            pointList.Add(new point(self.x - 1, self.y));
            board[self.y, self.x - 1] = board[self.y, self.x] + 1;
        }
        return pointList;
    }
    static bool PossibleCheck(int[,] board, int x, int y)
    {
        if (
            y < board.GetLength(0) &&
            x < board.GetLength(1) &&
            y >= 0 &&
            x >= 0 &&
            board[y, x] > -1
            )
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    static bool CheckPoint(int[,] board, int x, int y)
    {
        if (
            y < board.GetLength(0) &&
            x < board.GetLength(1) &&
            y >= 0 &&
            x >= 0 &&

            board[y, x] < -1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static List<point> NeighbourList(int[,] board, int x, int y)
    {
        List<point> pointList = new List<point>();

        pointList.Add(new point(x, y, board[y, x]));

        if (PossibleCheck(board, x + 1, y))
        {
            pointList.Add(new point(x + 1, y, board[y, x + 1]));
        }
        if (PossibleCheck(board, x - 1, y))
        {
            pointList.Add(new point(x - 1, y, board[y, x - 1]));
        }
        if (PossibleCheck(board, x, y + 1))
        {
            pointList.Add(new point(x, y + 1, board[y + 1, x]));
        }
        if (PossibleCheck(board, x, y - 1))
        {
            pointList.Add(new point(x, y - 1, board[y - 1, x]));
        }
        /*foreach( point p in pointList)
        {
            Debug.Log(p.x + " " + p.y + " " + p.value);
        }*/
        return pointList;
    }
}

