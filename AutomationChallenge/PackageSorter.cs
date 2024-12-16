using CommunityToolkit.Diagnostics;

namespace AutomationChallenge;

public class PackageSorter
{
    public static string Sort(int width, int height, int length, int mass)
    {
        Guard.IsGreaterThan(width, 0);
        Guard.IsGreaterThan(height, 0);
        Guard.IsGreaterThan(length, 0);
        Guard.IsGreaterThan(mass, 0);

        return (width, height, length, mass) switch
        {
            _ when width * height * length >= PackageConstants.MaxVolume &&
                   mass >= PackageConstants.MaxMass => PackageConstants.Rejected,
            _ when width * height * length >= PackageConstants.MaxVolume => PackageConstants.Special,
            _ when width >= PackageConstants.MaxSideLength => PackageConstants.Special,
            _ when height >= PackageConstants.MaxSideLength => PackageConstants.Special,
            _ when length >= PackageConstants.MaxSideLength => PackageConstants.Special,
            _ when mass >= PackageConstants.MaxMass => PackageConstants.Special,
            _ => PackageConstants.Standard
        };
    }
}