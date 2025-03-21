using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)

    // TODO Problem 1 - ADD YOUR CODE HERE
    {

        // CREATING SETS FOR O(1) PERFORMANCE
        HashSet<string> seenWords = new();
        HashSet<string> symmetricPairs = new();


        // LOOPING THROUGH THE WORDS
        // IF THE LENGTH OF THE WORD IS 2, WE WILL CHECK IF THE REVERSED VERSION IS ALREADY IN THE SET
        foreach (var word in words)
        {
            if (word.Length == 2)
            {
                string reversed = new string(new char[] { word[1], word[0] }); // REVERSE THE WORD

                // Si la versión invertida ya está en seenWords, encontramos un par simétrico
                if (seenWords.Contains(reversed)) // IF THE REVERSED VERSION IS ALREADY IN THE SET
                {
                    // FORMATE THE PAIR
                    string formattedPair = $"{word} & {reversed}";
                    // TO AVOID DUPLICATES, WE WILL ADD THE PAIR TO THE SET ONLY IF IT IS NOT ALREADY IN THE SET
                    string normalizedPair = word.CompareTo(reversed) < 0 ? formattedPair : $"{reversed} & {word}";

                    symmetricPairs.Add(normalizedPair);
                }

                seenWords.Add(word);
            }
        }

        return symmetricPairs.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {


        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // TODO Problem 2 - ADD YOUR CODE HERE


            // IF THE LINE HAS FOUR FIELDS, WE WILL PROCESS IT BECAUSE IT IS NOT A HEADER
            if (fields.Length == 4) continue;

            // DEGREE IS THE 4TH FIELD
            var degree = fields[3].Trim();

            // IF THE DEGREE IS NOT IN THE DICTIONARY, WE WILL ADD IT
            if (!degrees.ContainsKey(degree))
            {
                degrees[degree] = 0;
            }

            // INCREMENT THE COUNT FOR THE DEGREE
            degrees[degree]++;

        }

        // PRINT THE RESULTS IN THE CONSOLE
        Console.WriteLine("\nDegrees procesados:");
        foreach (var entry in degrees)
        {
            Console.WriteLine($"{entry.Key} - {entry.Value}");
        }

        return degrees;

    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE

        // IGNORING SPACES AND CASE
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        // IF THE LENGTHS ARE NOT EQUAL, THE WORDS ARE NOT ANAGRAMS
        if (word1.Length != word2.Length)
            return false;

        // CREATING DICTIONARIES TO STORE THE COUNTS OF EACH LETTER
        var count1 = new Dictionary<char, int>();
        var count2 = new Dictionary<char, int>();

        // COUNTING THE LETTERS IN EACH WORD
        foreach (var c in word1)
        {
            if (count1.ContainsKey(c))
                count1[c]++;
            else
                count1[c] = 1;
        }
        // COUNTING THE LETTERS IN EACH WORD
        foreach (var c in word2)
        {
            if (count2.ContainsKey(c))
                count2[c]++;
            else
                count2[c] = 1;
        }

        // COMPARING THE COUNTS OF EACH LETTER
        foreach (var key in count1.Keys)
        {
            if (!count2.ContainsKey(key) || count1[key] != count2[key])
                return false;
        }

        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        return [];
    }
}