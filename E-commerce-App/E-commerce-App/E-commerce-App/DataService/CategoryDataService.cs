﻿using E_commerce_App.ViewModels;
using System.Reflection;
using System.Runtime.Serialization.Json;
using Xamarin.Forms.Internals;

namespace E_commerce_App.DataService
{
    /// <summary>
    /// Data service to load the data from json file.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class CategoryDataService
    {
        #region fields

        private static CategoryDataService categoryDataService;

        private CategoryPageViewModel categoryPageViewModel;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates an instance for the <see cref="CategoryDataService"/> class.
        /// </summary>
        private CategoryDataService()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets an instance of the <see cref="CategoryDataService"/>.
        /// </summary>
        public static CategoryDataService Instance => categoryDataService ?? (categoryDataService = new CategoryDataService());

        /// <summary>
        /// Gets or sets the value of category page view model.
        /// </summary>
        public CategoryPageViewModel CategoryPageViewModel =>
            this.categoryPageViewModel ??
            (this.categoryPageViewModel = PopulateData<CategoryPageViewModel>("ecommerce.json"));

        #endregion

        #region Methods

        /// <summary>
        /// Populates the data for view model from json file.
        /// </summary>
        /// <typeparam name="T">Type of view model.</typeparam>
        /// <param name="fileName">Json file to fetch data.</param>
        /// <returns>Returns the view model object.</returns>
        private static T PopulateData<T>(string fileName)
        {
            var file = "E_commerce_App.Data." + fileName;

            var assembly = typeof(App).GetTypeInfo().Assembly;

            T data;

            using (var stream = assembly.GetManifestResourceStream(file))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                data = (T)serializer.ReadObject(stream);
            }

            return data;
        }

        #endregion
    }
}