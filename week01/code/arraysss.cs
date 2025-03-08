var numbers = new int[] { 1, 2, 3, 4, 5 };

foreach (var number in numbers)
{
    Console.WriteLine(number);
}

var numbers2 = new int[] { 1, 2, 3, 4, 5 };

// For Loop with index and length, and no initializer
for (var i = 0; i < numbers2.Length; i++)
{
    Console.WriteLine(numbers2[i]);
}