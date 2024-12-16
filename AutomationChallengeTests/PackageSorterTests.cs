using AutomationChallenge;

namespace AutomationChallengeTests;

public class PackageSorterTests
{
    public class SortShould
    {
        [Fact]
        public void SortStandardPackageNormally()
        {
            const int width = 5;
            const int height = 10;
            const int length = 20;
            const int mass = 10;
            
            string result = PackageSorter.Sort(width, height, length, mass);
            
            Assert.Equal(PackageConstants.Standard, result);
        }

        [Theory]
        [InlineData(0, 1, 1, 1)]
        [InlineData(1, 0, 1, 1)]
        [InlineData(1, 1, 0, 1)]
        [InlineData(1, 1, 1, 0)]
        public void ThrowOnNonPositiveInput(int width, int height, int length, int mass)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => PackageSorter.Sort(width, height, length, mass));
        }

        [Theory]
        [InlineData(100, 100, 100, 10)] // Too much volume
        [InlineData(150, 10, 10, 10)] // width too long
        [InlineData(10, 150, 10, 10)] // height too long
        [InlineData(10, 10, 150, 10)] // length too long
        [InlineData(10, 10, 10, 20)] // package too heavy
        public void SortBulkyItemsAsSpecial(int width, int height, int length, int mass)
        {
            string result = PackageSorter.Sort(width, height, length, mass);
            
            Assert.Equal(PackageConstants.Special, result);
        }

        [Fact]
        public void RejectHeavyBulkyItems()
        {
            string result = PackageSorter.Sort(100, 100, 100, 100);
            
            Assert.Equal(PackageConstants.Rejected, result);
        }
    }
}