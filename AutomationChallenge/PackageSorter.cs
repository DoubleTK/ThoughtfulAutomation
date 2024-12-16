using CommunityToolkit.Diagnostics;

namespace AutomationChallenge;

public static class PackageSorter
{
    /// <summary>
    /// Sorts a package based on its dimensions and mass. A package is considered "Bulky" when its volume exceeds
    /// <see cref="PackageConstants.MaxVolume"/> or when one of its dimensions is greater than
    /// <see cref="PackageConstants.MaxSideLength"/>.
    ///
    /// A package is considered "Heavy" when its mass in greater or equal to <see cref="PackageConstants.MaxMass"/>.
    ///
    /// A package can be both "Bulky" and "Heavy".
    /// </summary>
    /// <param name="width">The width of the package, in centimeters.</param>
    /// <param name="height">The height of the package, in centimeters.</param>
    /// <param name="length">The length of the package, in centimeters.</param>
    /// <param name="mass">The mass of the package, in kilograms.</param>
    /// <returns>
    /// A string representing the stack in which the package should be placed. The available options are:
    /// <see cref="PackageConstants.Rejected"/> when the package is both "Bulky" and "Heavy";
    /// <see cref="PackageConstants.Special"/> when the package is either "Bulky" or "Heavy", but not both; and
    /// <see cref="PackageConstants.Standard"/> when the package is neither "Bulky" nor "Heavy".
    /// </returns>
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