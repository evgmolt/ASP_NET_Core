using LiveCharts;
using MetricsManagerClient.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace MetricsManagerClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MetricsAgentClient httpClient;

        public MainWindow()
        {
            InitializeComponent();
            httpClient = new MetricsAgentClient(new System.Net.Http.HttpClient());
            var timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            var response = httpClient.GetCpuMetrics(new GetAllCpuMetricsApiRequest
            {
                AgentAddress = "http://localhost:5000",
                FromTime = DateTimeOffset.Now - new TimeSpan(0, 0, 10),
                ToTime = DateTimeOffset.Now
            });
            if (response == null)
            {
                return;
            }
            if (response.Count > 0)
            {
                CpuProgressBar.Value = response[0];
            }
        }

        List<int> GetCpuMetricsFormInterval(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            return httpClient.GetCpuMetrics(new GetAllCpuMetricsApiRequest
            {
                AgentAddress = "http://localhost:5000",
                FromTime = fromTime,
                ToTime = toTime
            });
        }

       
        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTimeOffset fromTime = new DateTimeOffset((DateTime)DatePickerFrom.SelectedDate);
                DateTimeOffset toTime = new DateTimeOffset((DateTime)DatePickerTo.DisplayDate);
                var metrics = GetCpuMetricsFormInterval(fromTime, toTime);
                CpuChart.ColumnServiesValues[0].Values.Clear();
                for (int i = 0; i < metrics.Count(); i++)
                {
                    CpuChart.ColumnServiesValues[0].Values.Add(metrics[i]);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
