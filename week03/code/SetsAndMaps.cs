using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// Problem 1: Find symmetric pairs of 2-letter words in O(n) time using a HashSet.
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        var result = new List<string>();
        var seen = new HashSet<string>();

        foreach (var word in words)
        {
            // Create the reversed version of the word
            string reversed = $"{word[1]}{word[0]}";

            // If the reverse is already seen, we found a pair (and skip identical-char words like "aa")
            if (seen.Contains(reversed) && word != reversed)
            {
                result.Add($"{word} & {reversed}");
            }
            else
            {
                seen.Add(word);
            }
        }

        return result.ToArray();
    }

    /// <summary>
    /// Problem 2: Summarize degrees from census data in a dictionary.
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            if (fields.Length >= 4)
            {
                string degree = fields[3].Trim(); // Column 4 is index 3

                if (degrees.ContainsKey(degree))
                {
                    degrees[degree]++;
                }
                else
                {
                    degrees[degree] = 1;
                }
            }
        }

        return degrees;
    }

    /// <summary>
    /// Problem 3: Determine if two words are anagrams in O(n) time using a Dictionary.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // Lowercase and strip spaces out efficiently
        var chars1 = word1.ToLower().Where(c => c != ' ').ToArray();
        var chars2 = word2.ToLower().Where(c => c != ' ').ToArray();

        if (chars1.Length != chars2.Length)
        {
            return false;
        }

        var letterCounts = new Dictionary<char, int>();

        // Count letters in the first word
        foreach (char c in chars1)
        {
            if (letterCounts.TryGetValue(c, out int count))
            {
                letterCounts[c] = count + 1;
            }
            else
            {
                letterCounts[c] = 1;
            }
        }

        // Subtract letters using the second word
        foreach (char c in chars2)
        {
            if (!letterCounts.TryGetValue(c, out int count) || count == 0)
            {
                return false;
            }
            letterCounts[c] = count - 1;
        }

        return true;
    }

    /// <summary>
    /// Problem 5: Deserialize live USGS Earthquake GeoJSON stream and summarize.
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

        if (featureCollection?.Features == null)
        {
            return [];
        }

        var summary = new List<string>();
        foreach (var feature in featureCollection.Features)
        {
            if (feature.Properties != null)
            {
                summary.Add($"{feature.Properties.Place} - Mag {feature.Properties.Mag}");
            }
        }

        return summary.ToArray();
    }
}