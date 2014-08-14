using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recommendations.Data;

namespace Recommendations.Tests.Database
{
    [TestClass]
    public class IntegrityTests
    {
        [TestMethod]
        public void CreateDatabaseTest()
        {
            using (var context = new DataContext())
            {
                var isDbCreated = context.Database.CreateIfNotExists();
                Assert.IsTrue(isDbCreated, "Database was not created.");
            }
        }

        [TestMethod]
        public void ConfirmDatabaseTest()
        {
            using (var context = new DataContext())
            {
                var isDbConfirmed = context.Database.CompatibleWithModel(true);
                Assert.IsTrue(isDbConfirmed, "Database is not compatible with entity model.");


            }
        }

        [TestMethod]
        public void DeleteDatabaseTest()
        {
            using (var context = new DataContext())
            {
                var isDbDeleted = context.Database.Delete();
                Assert.IsTrue(isDbDeleted, "Database was not removed.");
            }
        }
    }
}