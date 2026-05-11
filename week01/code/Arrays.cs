public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'. 
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}. Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // --- PLAN ---
        // 1. Initialize a new array of doubles called 'multiples'.
        //    The size of this array should be determined by the 'length' parameter.
        // 2. Create a loop that starts at index 0 and runs until it reaches 'length'.
        // 3. For each index 'i', calculate the value by multiplying 'number' by (i + 1).
        //    Example: if number is 3, index 0 becomes 3 * 1 = 3, index 1 becomes 3 * 2 = 6, etc.
        // 4. Store each calculated value into the corresponding index of the 'multiples' array.
        // 5. Return the finished array to the caller.

        // --- IMPLEMENTATION ---
        double[] multiples = new double[length];

        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // --- PLAN ---
        // 1. Check if the amount is equal to the list count or if the list is empty. 
        //    In these cases, no rotation is needed, so we can exit early.
        // 2. Identify the "slice" of numbers at the end of the list that needs to move to the front.
        //    The starting index for this slice is: (data.Count - amount).
        // 3. Use GetRange to extract those last 'amount' elements into a temporary list.
        // 4. Use RemoveRange to delete those same elements from their original position at 
        //    the end of the data list.
        // 5. Use InsertRange to take the temporary list and place it at index 0 (the front) 
        //    of the data list.
        // 6. This modifies the list "in-place," meaning the original list object is updated.

        // --- IMPLEMENTATION ---
        
        // Edge case: If amount is the same as Count, the list stays the same.
        if (amount == data.Count || data.Count == 0) return;

        // Step 2 & 3: Capture the elements that are "falling off" the right side
        int splitIndex = data.Count - amount;
        List<int> movingPart = data.GetRange(splitIndex, amount);

        // Step 4: Remove them from the end
        data.RemoveRange(splitIndex, amount);

        // Step 5: Put them at the beginning
        data.InsertRange(0, movingPart);
    }
}