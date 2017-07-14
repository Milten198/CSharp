using System;
using System.Collections.Generic;
using System.Linq;
using SeleniumFrameworkCsharp.Utilities;
using SeleniumFrameworkCsharp.Pages.Locators;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumFrameworkCsharp.Utilities.Objects;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using SeleniumFrameworkCsharp.Utilities.Helpers;

namespace SeleniumFrameworkCsharp.Pages.Executors
{
    class Task5Page : AbstractPage
    {
        private Task5PageLocators locators;

        public Task5Page(SeleniumExecutor executor)
            : base(executor)
        {
            InitTask5PageElements();
        }

        private void InitTask5PageElements()
        {
            locators = new Task5PageLocators();
            PageFactory.InitElements(SeleniumExecutor.GetDriver(), locators);
        }

        public void UploadFile(string fileName)
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + $@"Files\Task5\{fileName}";
            locators.uploadInput.SendKeys(filePath);
        }

        public bool CompareTwoLists()
        {
            bool areEquals = true;
            List<Person> list1 = CreateListOfDataFromFile();
            List<Person> list2 = CreateListOfDataFromApp();
            for (int i = 0; i < list1.Count; i++)
            {
                if (!list1[i].Name.Equals(list2[i].Name) || !list1[i].Surname.Equals(list2[i].Surname) || !list1[i].Phone.Equals(list2[i].Phone))
                {
                    areEquals = false;
                    break;
                }
            }
            return areEquals;
        }

        private List<Person> CreateListOfDataFromFile()
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + @"Files\Task5\correct.txt";
            string[] rows = System.IO.File.ReadAllLines(filePath);
            List<Person> people = new List<Person>();

            foreach (var row in rows)
            {
                string[] records = row.Split(',').Select(line => Regex.Replace(line, @"\s+", "")).ToArray();
                people.Add(new Person { Name = records[0], Surname = records[1], Phone = records[2] });
            }
            return people;
        }

        private List<Person> CreateListOfDataFromApp()
        {
            List<Person> people = new List<Person>();

            for (int i = 1; i <= locators.rows.Count(); i++)
            {
                IList<IWebElement> personData = locators.GetRow(i);
                people.Add(new Person { Name = personData[0].Text, Surname = personData[1].Text, Phone = personData[2].Text });
            }
            return people;
        }
    }
}