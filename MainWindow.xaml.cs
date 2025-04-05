using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Thwip_WPF.Client;
using Thwip_WPF.Components;

namespace Thwip_WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly SpiderManClient _spiderManClient;
    private readonly DispatcherTimer _retryTimer;
    
    public MainWindow()
    {
        InitializeComponent();
        _spiderManClient = new SpiderManClient();

        _retryTimer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMinutes(15)
        };
        _retryTimer.Tick += async (s, e) => await HandleGetSpiderManData();
        _retryTimer.Start();

        _ = HandleGetSpiderManData();
    }

    private async Task HandleGetSpiderManData(){
        try
        {
            var data = await _spiderManClient.GetSpiderManData();
            if (data != null)
            {
                // Process the data as needed
                Console.WriteLine("Data received: " + data.ToString());
                // Assign data to the UI elements             
            }
            else
            {
                ShowErrorModal("Failed to retrieve data from Marvel API. Please try again later.");
            }
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request error: {e.Message}");
            ShowErrorModal("Request error: " + e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unexpected error: {e.Message}");
            ShowErrorModal("Unexpected error: " + e.Message);
        }
    }

    private void ShowErrorModal(string message)
    {
        var errorModal = new ErrorModal(message, this);
        errorModal.ShowDialog();
    }
}