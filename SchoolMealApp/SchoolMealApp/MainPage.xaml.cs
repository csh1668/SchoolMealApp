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

            var meal = new Meal(Regions.Kangwon, SchoolType.High, "K100000460");
            Meals = meal.GetMealMenu();
            for (int  i = 0;  i < Meals.Count;  i++)
            {
                try
                {
                    if (Meals[i].Date.ToShortDateString() == DateTime.Now.ToShortDateString())
                    {
                        number = i;
                        Label_Change();
                    }
                }
                catch (NullReferenceException)
                {
                    NetworkError();
                } 
            }
            
        }
        private void NetworkError()
        {
            leftButton.Opacity = 0;
            rightButton.Opacity = 0;
            content.BackgroundImageSource = "errorImage.png";
            //System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
            int temp = number;
            try
            {
                number--;
                Label_Change();
            }
            catch (Exception)
            {
                number = temp;
                DisplayAlert("잠깐!", $"{DateTime.Today.Month}월의 급식 정보만 불러올 수 있어요.","알겠어요.");
            } 
        }

        private void Button2_Clicked(object sender, EventArgs e)
        {
            int temp = number;
            try
            {
                number++;
                Label_Change();
            }
            catch (Exception)
            {
                number = temp;
                DisplayAlert("잠깐!", $"{DateTime.Today.Month+1}월의 급식 정보는 아직 업데이트 되지 않았어요.", "알겠어요.");
            }
        }
        private void Label_Change()
        {
            labeldate.Text = Meals[number].Date.ToLongDateString();
            breakfast.Text = "";
            if (Meals[number].Breakfast != null)
            {
                breakfast.Text = string.Join(", ", Meals[number].Breakfast.ToArray());
            }
            else breakfast.Text = "이날은 아침이 없어요.";
            lunch.Text = "";
            if (Meals[number].Lunch != null)
            {
                lunch.Text = string.Join(", ", Meals[number].Lunch.ToArray());
            }
            else lunch.Text = "이날은 점심이 없어요.";
            dinner.Text = "";
            if (Meals[number].Dinner != null)
            {
                dinner.Text = string.Join(", ", Meals[number].Dinner.ToArray());
            }
            else dinner.Text = "이날은 저녁이 없어요.";
        }
    }
}
