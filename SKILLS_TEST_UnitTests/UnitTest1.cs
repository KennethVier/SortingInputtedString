using SKILLS__TEST;

namespace SKILLS_TEST_UnitTests
{
    [TestFixture]
    public class SortingStrategyTests
    {
        private BubbleSortStrategy bubbleSortStrategy;
        private MergeSortStrategy mergeSortStrategy;

        [SetUp]
        public void Setup()
        {
            bubbleSortStrategy = new BubbleSortStrategy();
            mergeSortStrategy = new MergeSortStrategy();
        }

        [Test]
        public void BubbleSortStrategy_SortsCharactersCorrectly()
        {
            // Arrange
            var input = new List<char> { 'd', 'a', 'c', 'b' };
            var expected = new List<char> { 'a', 'b', 'c', 'd' };

            // Act
            bubbleSortStrategy.Sort(input);

            // Assert
            Assert.That(input, Is.EqualTo(expected));
        }

        [Test]
        public void MergeSortStrategy_SortsCharactersCorrectly()
        {
            // Arrange
            var input = new List<char> { 'd', 'a', 'c', 'b' };
            var expected = new List<char> { 'a', 'b', 'c', 'd' };

            // Act
            mergeSortStrategy.Sort(input);

            // Assert
            Assert.That(input, Is.EqualTo(expected));
        }

        [Test]
        public void BubbleSortStrategy_SortsSingleCharacterList()
        {
            // Arrange
            var input = new List<char> { 'a' };
            var expected = new List<char> { 'a' };

            // Act
            bubbleSortStrategy.Sort(input);

            // Assert
            Assert.That(input, Is.EqualTo(expected));
        }

        [Test]
        public void MergeSortStrategy_SortsSingleCharacterList()
        {
            // Arrange
            var input = new List<char> { 'a' };
            var expected = new List<char> { 'a' };

            // Act
            mergeSortStrategy.Sort(input);

            // Assert
            Assert.That(input, Is.EqualTo(expected));
        }

        [Test]
        public void BubbleSortStrategy_SortsAlreadySortedList()
        {
            // Arrange
            var input = new List<char> { 'a', 'b', 'c', 'd' };
            var expected = new List<char> { 'a', 'b', 'c', 'd' };

            // Act
            bubbleSortStrategy.Sort(input);

            // Assert
            Assert.That(input, Is.EqualTo(expected));
        }

        [Test]
        public void MergeSortStrategy_SortsAlreadySortedList()
        {
            // Arrange
            var input = new List<char> { 'a', 'b', 'c', 'd' };
            var expected = new List<char> { 'a', 'b', 'c', 'd' };

            // Act
            mergeSortStrategy.Sort(input);

            // Assert
            Assert.That(input, Is.EqualTo(expected));
        }
    }
}