using System;
using System.Collections.Generic;

public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    /// <summary>
    /// Problem 4: Implement directional checks and coordinate adjustments.
    /// </summary>
    public void MoveLeft()
    {
        var currentPosition = (_currX, _currY);
        // Index 0 represents 'left'
        if (!_mazeMap.ContainsKey(currentPosition) || !_mazeMap[currentPosition][0])
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        _currX--;
    }

    public void MoveRight()
    {
        var currentPosition = (_currX, _currY);
        // Index 1 represents 'right'
        if (!_mazeMap.ContainsKey(currentPosition) || !_mazeMap[currentPosition][1])
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        _currX++;
    }

    public void MoveUp()
    {
        var currentPosition = (_currX, _currY);
        // Index 2 represents 'up'
        if (!_mazeMap.ContainsKey(currentPosition) || !_mazeMap[currentPosition][2])
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        _currY--;
    }

    public void MoveDown()
    {
        var currentPosition = (_currX, _currY);
        // Index 3 represents 'down'
        if (!_mazeMap.ContainsKey(currentPosition) || !_mazeMap[currentPosition][3])
        {
            throw new InvalidOperationException("Can't go that way!");
        }
        _currY++;
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}