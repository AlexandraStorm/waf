﻿using System;
using Waf.NewsReader.Applications.ViewModels;
using Waf.NewsReader.Applications.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Waf.NewsReader.Presentation.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeedView : IFeedView
    {
        private FeedViewModel viewModel;

        public FeedView()
        {
            InitializeComponent();
        }

        public object DataContext
        {
            get => BindingContext;
            set => BindingContext = value;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            viewModel = (FeedViewModel)BindingContext;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            searchBar.IsVisible = false;
            viewModel.SearchText = "";
        }

        private void FeedItemsItemTapped(object sender, ItemTappedEventArgs e)
        {
            viewModel.ShowFeedItemViewCommand.Execute(e.Item);
        }

        private void SearchClicked(object sender, EventArgs e)
        {
            searchBar.IsVisible = !searchBar.IsVisible;
            if (searchBar.IsVisible) searchBar.Focus();
        }
    }
}