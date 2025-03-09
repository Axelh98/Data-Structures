public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // create an array of doubles with the length of the parameter 'length'
        double[] result = new double[length];

        // for each element in the array, multiply the element by the parameter 'number' and add it to the array
        for (int i = 0; i < length; i++) {
            result[i] = number * (i + 1);
        }
        // return the array
        return result; 
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
        // TODO Problem 2 Start
        // validate the parameter amount
        if (amount < 1 || amount > data.Count)
        {
            throw new ArgumentOutOfRangeException("amount", "amount must be between 1 and the length of the list");
        }
        // Calculate the position of the last element in the list
        int rotateIndex = data.Count - amount;

        // divde the list into two parts
        List<int> part1 = data.GetRange(rotateIndex, amount);
        List<int> part2 = data.GetRange(0, rotateIndex);

        // concatenate the two parts
        data.Clear();
        data.AddRange(part1);
        data.AddRange(part2);
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
    }
}
