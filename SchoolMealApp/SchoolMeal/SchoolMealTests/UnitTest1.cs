using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolMeal;
using System.Collections.Generic;
using System.Diagnostics;

namespace SchoolMealTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Meal meal = new Meal(Regions.Gyeonggi, SchoolType.Middle, "J100005350");

            var menu = meal.GetMealMenu();

            foreach (var item in menu)
            {
                Debug.WriteLine(item.ToString());
            }
            Assert.AreEqual(menu.Count, 30);
        }

        [TestMethod]
        public void YeojuHighSchool()
        {
            var meal = new Meal(Regions.Gyeonggi, SchoolType.High, "J100000718");
            var menu = meal.GetMealMenu();
            foreach (var item in menu)
            {
                Debug.WriteLine(item.ToString());
            }

            // Assert.AreEqual(menu.Find(x => x.Date == new DateTime(2016, 11, 26)).IsExistMenu, false);
        }
    }
}
