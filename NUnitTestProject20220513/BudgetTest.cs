using System;
using System.Collections.Generic;
using System.Text;
using NSubstitute;
using NUnit.Framework;

namespace NUnitTestProject20220513
{
    public class BudgetTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        
        public void TestBudgetQuery_InvalidDateTime()
        {
            var repo = Substitute.For<IBudgetRepository>();
            var budgetService = new BudgetService(repo);
            Assert.AreEqual(0, budgetService.Query(DateTime.Now, DateTime.Now.AddDays(-2)));
        }


        [Test]
        
        public void TestBudgetQuery_SingleMonth()
        {
            var repo = Substitute.For<IBudgetRepository>();
            repo.GetAll().Returns(new List<Budget>()
            {
                new Budget(){ YearMonth = "202205", Amount = 310}

            });

            DateTime start = new DateTime(2022, 5, 1);
            DateTime end = new DateTime(2022, 5, 10);

            var budgetService = new BudgetService(repo);
            Assert.AreEqual(100, budgetService.Query(start, end));
        }


        [Test]
        
        public void TestBudgetQuery_MultiMonth()
        {
            var repo = Substitute.For<IBudgetRepository>();
            repo.GetAll().Returns(new List<Budget>()
            {
                new Budget(){ YearMonth = "202204", Amount = 180},
                new Budget(){ YearMonth = "202205", Amount = 310}

            });

            DateTime start = new DateTime(2022, 4, 30);
            DateTime end = new DateTime(2022, 5, 10);

            var budgetService = new BudgetService(repo);
            Assert.AreEqual(106, budgetService.Query(start, end));
        }        
        [Test]
        
        public void TestBudgetQuery_MultiMonth2()
        {
            var repo = Substitute.For<IBudgetRepository>();
            repo.GetAll().Returns(new List<Budget>()
            {
                new Budget(){ YearMonth = "202204", Amount = 180},
                new Budget(){ YearMonth = "202206", Amount = 310}

            });

            DateTime start = new DateTime(2022, 4, 30);
            DateTime end = new DateTime(2022, 5, 10);

            var budgetService = new BudgetService(repo);
            Assert.AreEqual(6, budgetService.Query(start, end));
        }

    }

  
}