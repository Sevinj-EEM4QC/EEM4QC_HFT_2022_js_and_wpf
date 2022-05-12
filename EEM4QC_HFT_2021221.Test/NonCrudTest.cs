namespace EEM4QC_HFT_2021221.Test
{
    using EEM4QC_HFT_2021221.Data;
    using EEM4QC_HFT_2021221.Logic;
    using EEM4QC_HFT_2021221.Repository;
    using NUnit.Framework;
    using System.Threading.Tasks;

    // naming convention [UnitOfWork_StateUnderTest_ExpectedBehavior]
    // The AAA (Arrange, Act, Assert) pattern is a common way of writing unit tests for a method under test. 

    /// <summary>
    /// Employee test.
    /// </summary>
    [TestFixture]
    public class NonCrudTest
    {
        /// <summary>
        /// Employee list .
        /// </summary>
        /// <returns>Task.</returns>
        [Test]
        public Task CheckUserName()
            => Task.Run(() =>
            {
                using DataContext context = new DataContext();
                IBaseLogic logic = new BaseLogic(new BaseRepository(context));

                var all = logic.EmployeeLogic.GetSingle(2);

                Assert.AreEqual(all.Emp_Name, "James");
            });

        /// <summary>
        /// Employee list .
        /// </summary>
        /// <returns>Task.</returns>
        [Test]
        public Task HasAnyUser()
            => Task.Run(() =>
            {
                using DataContext context = new DataContext();
                IBaseLogic logic = new BaseLogic(new BaseRepository(context));

                var all = logic.EmployeeLogic.GetList();

                Assert.IsTrue(all.Count > 0);
            });

        /// <summary>
        /// Employee list .
        /// </summary>
        /// <returns>Task.</returns>
        [Test]
        public Task IsEmployeeWorkingNow()
            => Task.Run(() =>
            {
                using DataContext context = new DataContext();
                IBaseLogic logic = new BaseLogic(new BaseRepository(context));

                var workDetail = logic.EmployeeWorkDetailLogic.GetSingle(2);

                Assert.IsFalse(workDetail.Wd_Is_Exited);
            });

        /// <summary>
        /// Employee list .
        /// </summary>
        /// <returns>Task.</returns>
        [Test]
        public Task HasAnyProgrammer()
            => Task.Run(() =>
            {
                using DataContext context = new DataContext();
                IBaseLogic logic = new BaseLogic(new BaseRepository(context));

                var workDetail = logic.EmployeeStatusLogic.GetList();
                int programmerCount = 0;

                foreach (var item in workDetail)
                {
                    if (item.Emps_Title == "Programmer")
                    {
                        programmerCount++;
                    }
                }

                Assert.IsTrue(programmerCount>0);
            });
        /// <summary>
        /// Employee list .
        /// </summary>
        /// <returns>Task.</returns>
        [Test]
        public Task HasAnyEmployeeFromBudapest()
            => Task.Run(() =>
            {
                using DataContext context = new DataContext();
                IBaseLogic logic = new BaseLogic(new BaseRepository(context));

                var workDetail = logic.EmployeeWorkDetailLogic.GetList();

                int employeeCount = 0;

                foreach (var item in workDetail)
                {
                    if (item.Wd_Location == "Budapest")
                    {
                        employeeCount++;
                    }
                }

                Assert.IsTrue(employeeCount > 0);
            });

        /// <summary>
        /// Employee list .
        /// </summary>
        /// <returns>Task.</returns>
        [Test]
        public Task HasAnyUserGetSalaryBiggerThan2500()
            => Task.Run(() =>
            {
                using DataContext context = new DataContext();
                IBaseLogic logic = new BaseLogic(new BaseRepository(context));

                var workDetail = logic.SalaryRecordLogic.GetList();

                int employeeCount = 0;

                foreach (var item in workDetail)
                {
                    if (item.Esr_Amount>2500)
                    {
                        employeeCount++;
                    }
                }

                Assert.IsTrue(employeeCount > 0);
            });
    }
}
