using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;

// Get requests: https://shoppingbackendapi.azurewebsites.net/api/shoppinglist/code/handyshopper

namespace XamarinShoppingList
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            LoadDataFromRestAPI();


            async void LoadDataFromRestAPI()
            {
                dataLista.ItemsSource = new List<string> { "Ladataan", "Ostoslista", "palvelimelta..." };
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://shoppingbackendapi.azurewebsites.net/");
                string json = await client.GetStringAsync("/api/shoppinglist/code/handyshopper");
                IEnumerable<Item> raakaLista = JsonConvert.DeserializeObject<Item[]>(json);

                List<String> stringList = new List<string>();

                foreach (var item in raakaLista)
                {
                    string merkkijono = item.ItemName.ToString() +
                  " " + item.Pieces.ToString() + " kpl";
                    stringList.Add(merkkijono);
                }

                dataLista.ItemsSource = stringList;

            }
        }

        private void kerätty_nappi_Clicked(object sender, EventArgs e)
        {

        }
    }
}