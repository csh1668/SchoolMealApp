using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SchoolMeal;

namespace SchoolMealApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public List<MealMenu> Meals { get; private set; }
        public int number = 0;
        public MainPage()
        {
            InitializeComponent();
            
            Meal meal = new Meal(Regions.Kangwon, SchoolType.High, "K100000460");
            Meals = meal.GetMealMenu();
            MealMenu todaysMeal = Meals[0];
            DateTime date = DateTime.Now;
            DateTime more = date.AddDays(1);
            for (int  i = 0;  i < Meals.Count;  i++)
            {
                if (Meals[i].Date.ToShortDateString() == more.ToShortDateString())
                {
                    number = i;
                }
            }
            label1.Text = Meals[number].ToString();
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
            number--;
            label1.Text = Meals[number].ToString();
        }

        private void Button2_Clicked(object sender, EventArgs e)
        {
            number++;
            label1.Text = Meals[number].ToString();
        }
    }
}
