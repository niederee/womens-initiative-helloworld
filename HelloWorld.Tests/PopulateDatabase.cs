using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloWorld.Tests
{
    [TestClass]
    public class PopulateDatabase
    {
        MockDataService mk = new MockDataService();
        [TestMethod]
        public void populateData()
        {
            DatabaseCopyService dbCopyService = new DatabaseCopyService(mk);
            dbCopyService.Copy();
            using(Npgsql.NpgsqlConnection conn = new Npgsql.NpgsqlConnection(ConfigService.GetConfig()["ConnectionStrings:FootLooseConnection"]))
            {
                DatabaseService.BulkLoad("person",mk.People, conn);
                DatabaseService.BulkLoad("shoe",mk.Shoes, conn);
                DatabaseService.BulkLoad("shoeperson",mk.ShoePersons, conn);
            }
        }
    }
}