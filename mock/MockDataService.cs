using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;

namespace HelloWorld
{
    public class MockDataService
    {
        public MockDataService()
        {
            filePath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "mock\\");
            Accounts = getList<Account>(Path.Combine(filePath, "account.dat"));
            People = getList<Person>(Path.Combine(filePath, "person.dat"));
            AccountPersons = getList<AccountPerson>(Path.Combine(filePath, "accountPerson.dat"));
        }


        private string filePath { get; set; }
        public List<Account> Accounts { get; internal set; }
        public List<Person> People { get; internal set; }
        public List<AccountPerson> AccountPersons { get; internal set; }





        private static List<T> getList<T>(string filePath)
        {
            List<T> objs = new List<T>();
            Type objType = typeof(T);
            var props = objType.GetProperties().ToList();

            StreamReader reader = new StreamReader(filePath);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                List<string> values = line.Split("|").ToList();
                var tmpObj = Activator.CreateInstance(objType);
                for (int i = 0; i < props.Count; i++)
                {
                    string propVal = values.Skip(i).First();
                    PropertyInfo prop = props.Skip(i).First();
                    if (propVal != string.Empty)

                        if (prop.PropertyType.IsEnum)
                        {
                            prop.SetValue(tmpObj, Enum.Parse(prop.PropertyType, propVal), null);
                        }
                        else if (Nullable.GetUnderlyingType(prop.PropertyType) == typeof(DateTime))
                        {
                            prop.SetValue(tmpObj, DateTime.Parse(propVal));
                        }
                        else
                        {
                            prop.SetValue(tmpObj, Convert.ChangeType(propVal, prop.PropertyType));
                        }
                }
                objs.Add((T)tmpObj);
            }
            return objs;
        }
    }

}