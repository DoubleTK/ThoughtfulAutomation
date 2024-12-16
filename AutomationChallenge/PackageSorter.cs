using CommunityToolkit.Diagnostics;

namespace AutomationChallenge;

public class PackageSorter
{
    public string Sort(int width, int height, int length, int mass)
    {
        Guard.IsGreaterThan(width, 0);
        Guard.IsGreaterThan(height, 0);
        Guard.IsGreaterThan(length, 0);
        Guard.IsGreaterThan(mass, 0);
        return PackageConstants.Standard;
    }
}