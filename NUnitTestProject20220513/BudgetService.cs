using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnitTestProject20220513
{
    public class BudgetService
    {
        private IBudgetRepository budgetRepository;
        public BudgetService(IBudgetRepository _budgetRepository)
        {
            budgetRepository = _budgetRepository;
        }
        

        public decimal Query(DateTime start, DateTime end)
        {
            if (end < start)
            {
                return 0;
            }

            var data = budgetRepository.GetAll();

                int daysInMonth = DaysInMonth(start);
                DateTime tempStart = new DateTime(start.Year,start.Month, 1);
                int i = 0;
                decimal total = 0;
            while (true)
            {
                var budget = data.FirstOrDefault(m => m.YearMonth == tempStart.ToString("yyyyMM")) ?? new Budget();

                if (start.ToString("yyyyMM") == end.ToString("yyyyMM"))
                {
                    total = total + budget.Amount / DaysInMonth(tempStart) * (end.Day - start.Day +1);
                }
                else if (tempStart.ToString("yyyyMM") == start.ToString("yyyyMM") )
                {
                    total = total + budget.Amount / DaysInMonth(tempStart) *  (DaysInMonth(tempStart) - start.Day + 1 );
                }
                else if (tempStart.ToString("yyyyMM") == end.ToString("yyyyMM"))
                {
                    total = total +  budget.Amount / DaysInMonth(tempStart) * (end.Day);
                }
                else
                {
                    total = total + budget.Amount;
                }

                if (tempStart.ToString("yyyyMM") == end.ToString("yyyyMM"))
                {
                    break;
                }
                tempStart = tempStart.AddMonths(1);

                }
              
                return total;


        }

        // public int MonthDiff(DateTime start, DateTime end)
        // {
        //
        // }


        private int DaysInMonth(DateTime start)
        {
            return DateTime.DaysInMonth(start.Year, start.Month);
        }
    }

    public class Budget
    {
        public string YearMonth { get; set; }
        public int Amount { get; set; }
    }

    public interface IBudgetRepository
    {
        public List<Budget> GetAll();
    }
}
