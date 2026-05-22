using System.Collections.Generic;

public class FeatureCollection
{
    public List<Feature> Features { get; set; } = new();
}

public class Feature
{
    public EarthquakeProperties Properties { get; set; } = new();
}

public class EarthquakeProperties
{
    public string Place { get; set; } = string.Empty;
    public double? Mag { get; set; } // Uses nullable double to safely handle missing data or null payloads
}