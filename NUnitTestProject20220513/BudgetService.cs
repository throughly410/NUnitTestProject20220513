using System;
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
            if (InvalidQueryDate(start, end))
            {
                return 0;
            }

            var data = budgetRepository.GetAll();

                DateTime current = new DateTime(start.Year,start.Month, 1);
                decimal total = 0;
                while (true)
                {
                    var budget = data.FirstOrDefault(m => m.YearMonth == current.ToString("yyyyMM")) ?? new Budget();

                    if (start.ToString("yyyyMM") == end.ToString("yyyyMM"))
                    {
                        total +=  budget.Amount / DaysInMonth(current) * (end.Day - start.Day + 1);
                    }
                    else if (current.ToString("yyyyMM") == start.ToString("yyyyMM"))
                    {
                        total += budget.Amount / DaysInMonth(current) *
                            (DaysInMonth(current) - start.Day + 1);
                    }
                    else if (current.ToString("yyyyMM") == end.ToString("yyyyMM"))
                    {
                        total +=  budget.Amount / DaysInMonth(current) * (end.Day);
                    }
                    else
                    {
                        total += budget.Amount;
                    }

                    if (current.ToString("yyyyMM") == end.ToString("yyyyMM"))
                    {
                        break;
                    }

                    current = current.AddMonths(1);

                }

                return total;


        }

        private bool InvalidQueryDate(DateTime start, DateTime end)
        {
            return end < start;
        }

        private int DaysInMonth(DateTime start)
        {
            return DateTime.DaysInMonth(start.Year, start.Month);
        }
    }
}
