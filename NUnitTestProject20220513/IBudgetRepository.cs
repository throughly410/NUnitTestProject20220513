using System.Collections.Generic;

namespace NUnitTestProject20220513
{
    public interface IBudgetRepository
    {
        public List<Budget> GetAll();
    }
}