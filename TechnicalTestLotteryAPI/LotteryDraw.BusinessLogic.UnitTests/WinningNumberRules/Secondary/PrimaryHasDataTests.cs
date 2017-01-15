using System.Linq;
using LotteryDraw.BusinessLogic.Interfaces;
using LotteryDraw.BusinessLogic.WinningNumberRules.Secondary;
using LotteryDraw.Models.Interfaces.Models;
using NSubstitute;
using NUnit.Framework;

namespace LotteryDraw.BusinessLogic.UnitTests.WinningNumberRules.Secondary
{
    [TestFixture]
    public class PrimaryHasDataTests
    {
        private IWinningNumbersRule _rule;

        [SetUp]
        public void Setup()
        {
            _rule = new SecondaryHasData();
        }

        [Test]
        public void CheckDefaultState()
        {
            Assert.That(_rule.Sequence, Is.EqualTo(4));
            Assert.That(_rule.HasError, Is.False);
            Assert.That(_rule.ErrorMessage, Does.StartWith("Secondary winning data has not been provided."));
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

        [TestCase("1")]
        [TestCase("1,2,3")]
        [TestCase("1,2,3,4,5,6,7,8,9")]
        public void Check_Execute_WorksAsExpected_WithData(string value)
        {
            var winningNumbers = Substitute.For<IWinningNumbers>();
            winningNumbers.WinningSecondaryNumbers.Returns(value.Split(',').Select(int.Parse).ToList());

            _rule.Execute(Substitute.For<ILotteryDrawWithResults>(), winningNumbers);

            Assert.That(_rule.HasError, Is.False);
        }
    }
}
