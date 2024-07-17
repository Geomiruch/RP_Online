﻿using System;
using RP_App.Contracts.Login;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RP_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private readonly AuthService _authService;

        public LoginPage()
        {
            InitializeComponent();
            _authService = new AuthService();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                string email = emailEntry.Text;
                string password = passwordEntry.Text;
                LoginResponse response = await _authService.SendAuthRequestAsync(email, password);

                await DisplayAlert("Success", $"Login successful! Token: {response.Token}", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}