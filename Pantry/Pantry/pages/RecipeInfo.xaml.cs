﻿using Pantry.enums;
using Pantry.models;
using Plugin.LocalNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.PlatformConfiguration.iOSSpecific;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace Pantry.pages
{

    public partial class RecipeInfoPage : Popup
    {

        public RecipeInfoPage(string name, string ingredients, string description, string source, int calories)
        {

            InitializeComponent();


            recipeTitle.Text = name;
            recipeIngredients.Text = ingredients;
            recipeCalories.Text = "calories: "+calories.ToString();
            recipeDescription.Text = description;
            recipeImage.Source = new UriImageSource()
            {
                Uri = new Uri(source)
            };
        }
    }
}