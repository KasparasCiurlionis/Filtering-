using Xamarin.CommunityToolkit.UI.Views;
using Pantry.pages;
using Java.Security;
using Pantry.models;
using Xamarin.Forms;
using System;
using Android.Util;
using System.Collections.Generic;
using System.Linq;
using Java.Lang;

namespace Pantry.pages
{
    public partial class RecipeFilterPage : Popup
    {
        private string typeValue = null;
        private DateTime? startDate = null;
        private DateTime? endDate = null;
        private int calorieValue = 0;
        private List<string> ingredients = new List<string>();
        public RecipeFilterPage(string typeValue, DateTime? startDate, DateTime? endDate, int? calorieValue, List<string> ingredients)
        {
            InitializeComponent();
            TypePicker.ItemsSource = RecipeHandler.RecipeTypes.ToList();
            IngredientPicker.ItemsSource = RecipeHandler.IngredientList.ToList();
            GetValues(typeValue, startDate, endDate, calorieValue, ingredients);
        }

        private void BtnSetFilter(object sender, EventArgs e)
        {
            SetValues();
            List<object> items = new List<object> { typeValue, startDate, endDate, calorieValue, ingredients};
            Dismiss(items);
        }

        private void BtnResetFilter(object sender, EventArgs e)
        {
            List<object> items = new List<object> { null, null, null, 0, null};
            Dismiss(items);

        }


        private void FilterByDateCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value == true)
            {
                StartDate.IsEnabled = true;
                EndDate.IsEnabled = true;
                FilterByDate.Color = Color.Black;

            }
            else
            {
                StartDate.IsEnabled = false;
                EndDate.IsEnabled = false;
                FilterByDate.Color = Color.Black;
            }
        }

        private void FilterByTypeCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value == true)
            {
                TypePicker.IsEnabled = true;
                FilterByType.Color = Color.Black;
                TypePicker.TitleColor = Color.Black;
            }
            else
            {
                TypePicker.IsEnabled = false;
                FilterByType.Color = Color.DarkGray;
            }
        }

        private void FilterByIngredientCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value == true)
            {
                IngredientPicker.IsEnabled = true;
                IngredientPicker.SelectionMode = SelectionMode.Multiple;
                FilterByIngredient.Color = Color.Black;
            }
            else
            {
                IngredientPicker.IsEnabled = false;
                FilterByIngredient.Color = Color.DarkGray;
                IngredientPicker.SelectionMode = SelectionMode.None;
            }
        }

        private void FilterByCaloriesCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value == true)
            {
                CaloryEditor.IsEnabled = true;
                FilterByCalories.Color = Color.Black;   
            }
            else
            {
                CaloryEditor.IsEnabled = false;
                FilterByCalories.Color = Color.DarkGray;
                CaloryEditor.Text = "";
            }
        }

        private void SetValues()
        {
            /*if (FilterByType.IsChecked && FilterByDate.IsChecked)
            {
                typeValue = (string)TypePicker.SelectedItem;
                startDate = StartDate.Date;
                endDate = EndDate.Date;

            }*/
            if (FilterByType.IsChecked)
            {
                typeValue = (string)TypePicker.SelectedItem;
            }
            if (FilterByDate.IsChecked)
            {
                startDate = StartDate.Date;
                endDate = EndDate.Date;
            }
            if (FilterByCalories.IsChecked) {
                int.TryParse(CaloryEditor.Text, out calorieValue);
            }
            if (FilterByIngredient.IsChecked) {
                foreach (string ingredient in IngredientPicker.SelectedItems) {
                    ingredients.Add(ingredient);
                }
            }
            /*
            else
            {
                return;
            }*/
        }

        private void GetValues(string typeValue, DateTime? startDate, DateTime? endDate, int? calorieValue, List<string> ingredients)
        {
            if (typeValue != null)
            {
                TypePicker.SelectedItem = typeValue;
                FilterByType.IsChecked = true;
            }

            if (startDate != null && endDate != null)
            {
                StartDate.Date = (DateTime)startDate;
                EndDate.Date = (DateTime)endDate;
                FilterByDate.IsChecked = true;
            }
            if (calorieValue != 0)
            {
                CaloryEditor.Text = calorieValue.ToString();
                FilterByCalories.IsChecked = true;
            }
            if (ingredients.Count != 0)
            {
                FilterByIngredient.IsChecked = true;
            }
        }
    }
}