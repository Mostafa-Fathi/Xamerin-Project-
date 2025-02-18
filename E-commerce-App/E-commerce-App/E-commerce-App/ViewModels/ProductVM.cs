﻿using E_commerce_App.Models;
using E_commerce_App.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace E_commerce_App.ViewModel
{
    internal class ProductVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Product> productsList;
        private ServerRequests httpClient;
        void onPropertyChanged([CallerMemberName]string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ObservableCollection<Product> ProductsList
        {
            get { return productsList; }
            set
            {
                productsList = value;
                onPropertyChanged();
            }
        }
        public ProductVM()
        {
            httpClient = new ServerRequests();
            loadData();
            ProductsList = new ObservableCollection<Product>() { 
                new Product(){id=0,title="Loading"},
              
            };
            
        }
        private async void loadData()
        {
           // ProductsList = await httpClient.GetProducts();
            ProductsList = await httpClient.GetProducts("category/jewelery");

        }


    }
}
