using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // Base case: If n is 0 or negative, sum is 0
        if (n <= 0)
            return 0;

        // Recursive case: n^2 + sum of squares up to (n-1)
        return (n * n) + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // Base case: If the current word has reached the targeted size, save it
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Recursive case: Loop through available letters to build permutations
        for (int i = 0; i < letters.Length; i++)
        {
            char currentLetter = letters[i];
            
            // Remove the selected letter from the remaining pool to ensure no reuse in the same branch
            string remainingLetters = letters.Remove(i, 1);
            
            // Recurse with the updated string pool and the built word fragment
            PermutationsChoose(results, remainingLetters, size, word + currentLetter);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Counts how many ways there are to climb the stairs using memoization.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Initialize memoization dictionary on the first run
        if (remember == null)
        {
            remember = new Dictionary<int, decimal>();
        }

        // Base Cases
        if (s == 0) return 0;
        if (s == 1) return 1;
        if (s == 2) return 2;
        if (s == 3) return 4;

        // Check if the result was calculated previously
        if (remember.ContainsKey(s))
        {
            return remember[s];
        }

        // Solve using recursion and pass down the memoization cache
        decimal ways = CountWaysToClimb(s - 1, remember) + 
                       CountWaysToClimb(s - 2, remember) + 
                       CountWaysToClimb(s - 3, remember);

        // Store the result in our dictionary cache before returning
        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// Using recursion, insert all possible binary strings for a given pattern 
    /// containing wildcards (*) into the results list.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // Find the index of the first wildcard instance
        int wildcardIndex = pattern.IndexOf('*');

        // Base case: No wildcards left, meaning the binary string configuration is complete
        if (wildcardIndex == -1)
        {
            results.Add(pattern);
            return;
        }

        // Split string into segments around the targeted wildcard index
        string prefix = pattern[..wildcardIndex];
        string suffix = pattern[(wildcardIndex + 1)..];

        // Recursive path A: Swap wildcard with a '0'
        WildcardBinary(prefix + "0" + suffix, results);

        // Recursive path B: Swap wildcard with a '1'
        WildcardBinary(prefix + "1" + suffix, results);
    }

    /// <summary>
    /// #############
    /// # Problem 5 #
    /// #############
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // Initialize the tracking container on initial launch
        if (currPath == null) 
        {
            currPath = new List<ValueTuple<int, int>>();
        }

        // 1. Guard check: Is this step out-of-bounds, a wall, or already visited?
        if (!maze.IsValidMove(currPath, x, y))
        {
            return;
        }

        // 2. Action step: Append the current valid grid position to our route tracking history
        currPath.Add((x, y));

        // 3. Win check base case: Did we reach the target end coordinate block?
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
        }
        else
        {
            // 4. Recursive search: Advance outward across 4 coordinate directions
            SolveMaze(results, maze, x + 1, y, currPath); // Right
            SolveMaze(results, maze, x - 1, y, currPath); // Left
            SolveMaze(results, maze, x, y + 1, currPath); // Down
            SolveMaze(results, maze, x, y - 1, currPath); // Up
        }

        // 5. Backtrack pattern step: Remove current coordinates on the way back up 
        // to free it for exploration of alternate path combinations
        currPath.RemoveAt(currPath.Count - 1);
    }
}