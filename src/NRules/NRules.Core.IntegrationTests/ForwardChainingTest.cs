﻿using NRules.Core.IntegrationTests.TestAssets;
using NRules.Core.IntegrationTests.TestRules;
using NUnit.Framework;

namespace NRules.Core.IntegrationTests
{
    [TestFixture]
    public class ForwardChainingTest : BaseRuleTestFixture
    {
        [Test]
        public void ForwardChaining_OneMatchingFact_FiresFirstRuleAndChainsSecond()
        {
            //Arrange
            var fact1 = new FactType1() {TestProperty = "Valid Value"};
            Session.Insert(fact1);

            //Act
            Session.Fire();

            //Assert
            AssertFiredOnce<ForwardChainingFirstRule>();
            AssertFiredOnce<ForwardChainingSecondRule>();
        }

        [Test]
        public void ForwardChaining_OneMatchingFactOfOneKindAndOneOfAnotherKind_FiresSecondRuleDirectlyAndChained()
        {
            //Arrange
            var fact1 = new FactType1() {TestProperty = "Valid Value"};
            var fact2 = new FactType2() {TestProperty = "Valid Value"};

            Session.Insert(fact1);
            Session.Insert(fact2);

            //Act
            Session.Fire();

            //Assert
            AssertFiredOnce<ForwardChainingFirstRule>();
            AssertFiredTwice<ForwardChainingSecondRule>();
        }

        protected override void SetUpRules()
        {
            SetUpRule<ForwardChainingFirstRule>();
            SetUpRule<ForwardChainingSecondRule>();
        }
    }
}