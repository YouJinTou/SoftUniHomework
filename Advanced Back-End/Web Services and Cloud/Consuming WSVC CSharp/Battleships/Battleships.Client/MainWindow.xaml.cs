using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using Battleships.Client.Models;

namespace Battleships.Client
{
    public partial class MainWindow : Window
    {
        private const string BaseUri = "http://localhost:62859/";
        private const string RegisterUserEndPoint = "api/Account/Register";
        private const string LoginUserEndPoint = "Token";
        private const string CreateGameEndPoint = "api/Games/create";
        private const string AvailableGamesEndPoint = "api/Games/available";
        private const string JoinGameEndPoint = "api/Games/join";
        private const string UserGamesEndPoint = "api/Games/User";
        private const string PlayGameEndPoint = "api/Games/play";

        private static Token accessToken;

        public MainWindow()
        {
            accessToken = new Token();
            InitializeComponent();
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            var email = emailField.Text;
            var password = passwordField.Text;
            var confirmPassword = confirmPasswordField.Text;

            RegisterPlayerAsync(email, password, confirmPassword);
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            var username = usernameLoginField.Text;
            var password = passwordLoginField.Text;

            LoginPlayerAsync(username, password, gamesList, gamesUnderwayList);
        }

        private void createGameButton_Click(object sender, RoutedEventArgs e)
        {
            CreateGameAsync(gamesList);
            GetAvailableGamesAsync(gamesList);
        }

        private void joinGameButton_Click(object sender, RoutedEventArgs e)
        {
            string game = (string)gamesList.SelectedItem;
            if (game == null)
            {
                MessageBox.Show("Select a game to join.");
                return;
            }

            var id = game.Substring(0, game.IndexOf('|')).Trim();

            JoinGameAsync(id, gamesList, gamesUnderwayList);
            GetUserGamesAsync(gamesUnderwayList);
        }

        private void launchMissileButton_Click(object sender, RoutedEventArgs e)
        {
            string id = (string)gamesUnderwayList.SelectedItem;
            if (id == null)
            {
                MessageBox.Show("Choose a game to play.");
            }
            else
            {
                var posX = xCoordField.Text;
                var posY = YCoordField.Text;

                PlayGameAsync(id, posX, posY);
            }
        }

        private static async Task RegisterPlayerAsync(string email, string password, string confirmPassword)
        {
            var httpContent = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("email", email),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("confirmPassword", confirmPassword)
            });
            var httpClient = new HttpClient();
            var response = await httpClient.PostAsync(BaseUri + RegisterUserEndPoint, httpContent);

            MessageBox.Show(response.ToString());
        }

        private static async Task LoginPlayerAsync(string username, string password, ListBox gamesList, ListBox userGamesList)
        {
            var httpClient = new HttpClient();
            var httpContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password")
            });
            var response = await httpClient.PostAsync(BaseUri + LoginUserEndPoint, httpContent);
            var contents = response.Content.ReadAsStringAsync();

            accessToken = JsonConvert.DeserializeObject<Token>(contents.Result);
            MessageBox.Show(response.ToString());

            GetAvailableGamesAsync(gamesList);
            GetUserGamesAsync(userGamesList);
        }

        private static async Task CreateGameAsync(ListBox gamesList)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken.Access_Token);

            var response = await httpClient.PostAsync(BaseUri + CreateGameEndPoint, null);
            MessageBox.Show(response.ToString());

            GetAvailableGamesAsync(gamesList);
        }

        private static async Task GetAvailableGamesAsync(ListBox gamesList)
        {
            gamesList.Items.Clear();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken.Access_Token);

            var response = await httpClient.GetAsync(BaseUri + AvailableGamesEndPoint);
            var content = response.Content.ReadAsStringAsync();
            var games = JsonConvert.DeserializeObject<HashSet<PlayerGame>>(content.Result);

            foreach (var game in games)
            {
                var id = game.Id;
                var playerOne = game.PlayerOne;
                var state = game.State;
                gamesList.Items.Add(id + " | " + playerOne + " | " + state);
            }
        }

        private static async Task JoinGameAsync(string id, ListBox gamesList, ListBox userGamesList)
        {
            var httpContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("gameId", id)
            });
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken.Access_Token);

            var response = await httpClient.PostAsync(BaseUri + JoinGameEndPoint, httpContent);
            var message = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Successfully joined the game.");
            }
            else
            {
                MessageBox.Show(message);
            }

            GetAvailableGamesAsync(gamesList);
            GetUserGamesAsync(userGamesList);
        }

        private static async Task GetUserGamesAsync(ListBox userGamesList)
        {
            userGamesList.Items.Clear();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken.Access_Token);

            var response = await httpClient.GetAsync(BaseUri + UserGamesEndPoint);
            var content = response.Content.ReadAsStringAsync();
            var games = JsonConvert.DeserializeObject<string[]>(content.Result);

            foreach (var gameId in games)
            {
                userGamesList.Items.Add(gameId);
            }
        }

        private static async Task PlayGameAsync(string id, string posX, string posY)
        {
            var httpContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("gameId", id),
                new KeyValuePair<string, string>("positionX", posX),
                new KeyValuePair<string, string>("positionY", posY)
            });
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken.Access_Token);

            var response = await httpClient.PostAsync(BaseUri + PlayGameEndPoint, httpContent);
            var message = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Successfully played a move.");
            }
            else
            {
                MessageBox.Show(message);
            }
        }
    }
}
