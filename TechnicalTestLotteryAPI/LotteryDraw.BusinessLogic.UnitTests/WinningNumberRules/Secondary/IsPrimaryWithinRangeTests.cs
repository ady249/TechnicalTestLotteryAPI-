using System.Linq;
using LotteryDraw.BusinessLogic.Interfaces;
using LotteryDraw.BusinessLogic.WinningNumberRules.Secondary;
using LotteryDraw.Models.Interfaces.Models;
using NSubstitute;
using NUnit.Framework;

namespace LotteryDraw.BusinessLogic.UnitTests.WinningNumberRules.Secondary
{
    [TestFixture]
    public class IsPrimaryWithinRangeTests
    {
        private IWinningNumbersRule _rule;

        [SetUp]
        public void Setup()
        {
            _rule = new IsSecondaryWithinRange();
        }

        [Test]
        public void CheckDefaultState()
        {
            Assert.That(_rule.Sequence, Is.EqualTo(5));
            Assert.That(_rule.HasError, Is.False);
            Assert.That(_rule.ErrorMessage, Does.StartWith("Secondary winning numbers mismatch. Expected "));
        }

        [Test]
        public void Check_Execute_WorksAsExpected_WithNullData()
        {
            _rule.Execute(null, null);

            Assert.That(_rule.HasError);
        }

        [Test]
        public void Check_Execute_WorksAsExpected_WithWinningDataNull()
        {
            _rule.Execute(Substitute.For<ILotteryDrawWithResults>(), null);
            Assert.That(_rule.HasError);
        }

        [Test]
        public void Check_Execute_WorksAsExpected_WithNoData()
        {
            _rule.Execute(Substitute.For<ILotteryDrawWithResults>(), Substitute.For<IWinningNumbers>());
        }

        [TestCase(0, 1, ExpectedResult = true)]
        [TestCase(0, 0, ExpectedResult = false)]
        [TestCase(9, 10, ExpectedResult = true)]
        [TestCase(5, 5, ExpectedResult = false)]
        public bool Check_Execute_WorksAsExpected_WithData(int totalPrimaryNumbers, int winningPrimaryNumbers)
        {
            var data = Substitute.For<ILotteryDrawWithResults>();
            data.TotalSecondaryNumbers.Returns(totalPrimaryNumbers);

            var winningNumbers = Substitute.For<IWinningNumbers>();
            winningNumbers.WinningSecondaryNumbers.Returns(Enumerable.Repeat(1, winningPrimaryNumbers));

            _rule.Execute(data, winningNumbers);

            return _rule.HasError;
        }
    }
}
