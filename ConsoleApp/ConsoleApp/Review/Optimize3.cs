using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Data;

namespace EmployeeManager
{
    public class SalaryController 
    {
        /*
        [System.Web.Mvc.HttpGet("api/salary/ChangeSalary")] //method
        [RetryFilter(typeof(DataException), attempts: 3)]
        public IActionResult ChangeSalary(string userId, int delta)
        {
            try
            {
                if ((new[] { 0, 6 }).Contains((int)DateTime.Now.DayOfWeek) {
                    return BadRequest("Can't change salaries on weekend");
                }

                var da = new DataAccess("localhost:3336;password=123;catalog=production");
                var addQuery = $"UPDATE Salaries SET Salary = Salary + {delta},
                                UPDATED_AT = NOW() WHERE UserId = '{userId}'";
                da.ExecuteAsync(addQuery).Wait();

                var readQuery = $"SELECT * FROM users WHERE Id LIKE '%{userId}%'";
                dynamic found = da.ExecuteAsync(readQuery).Result.ListAll().First();

                da.Dispose();
                return Json(found);
            }
            catch (DataException ex)
            {
                //TODO: add logging here
                throw ex;
            }
        }

        #region
        private IActionResult BadRequest(string v)
        {
            throw new NotImplementedException();
        }

        #endregion

        */
    }

    #region
    internal class RetryFilterAttribute : Attribute
    {
    }

    internal class DataAccess
    {
        private string v;

        public DataAccess(string v)
        {
            this.v = v;
        }

        internal void Dispose()
        {
            throw new NotImplementedException();
        }

        internal object ExecuteAsync(string addQuery)
        {
            throw new NotImplementedException();
        }
    }

    #endregion
}
