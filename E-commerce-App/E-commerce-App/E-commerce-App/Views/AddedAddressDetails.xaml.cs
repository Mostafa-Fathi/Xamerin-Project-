﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace E_commerce_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddedAddressDetails : ContentPage
    {
        public AddedAddressDetails()
        {
            InitializeComponent();
        }

        private void add(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PushAsync(new AddAddressess());
        }


    }
}