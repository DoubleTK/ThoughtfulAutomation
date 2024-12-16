using AutomationChallenge;

namespace AutomationChallengeTests;

public class PackageSorterTests
{
    public class SortShould
    {
        [Fact]
        public void SortStandardPackageNormally()
        {
            var sorter = new PackageSorter();
            int width = 5;
            int height = 10;
            int length = 20;
            int mass = 10;
            string result = sorter.Sort(width, height, length, mass);
            
            Assert.Equal(PackageConstants.Standard, result);
        }

        [Theory]
        [InlineData(0, 1, 1, 1)]
        [InlineData(1, 0, 1, 1)]
        [InlineData(1, 1, 0, 1)]
        [InlineData(1, 1, 1, 0)]
        public void NonPositiveInputsShouldThrow(int width, int height, int length, int mass)
        {
            var sorter = new PackageSorter();
            
            Assert.Throws<ArgumentOutOfRangeException>(() => sorter.Sort(width, height, length, mass));
        }
    }
}