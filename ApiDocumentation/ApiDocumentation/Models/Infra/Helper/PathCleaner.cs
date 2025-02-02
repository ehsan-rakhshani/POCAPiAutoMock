public class PathCleaner
{
    // Method to clean the path string from 'paths[...]' format to the desired format
    public static string CleanPath(string rawPath)
    {
        if (string.IsNullOrEmpty(rawPath))
            throw new ArgumentException("Raw path cannot be null or empty", nameof(rawPath));

        // Remove the unnecessary part and return the clean path
        return rawPath.Replace("paths['", "").Replace("']", "");
    }
}
