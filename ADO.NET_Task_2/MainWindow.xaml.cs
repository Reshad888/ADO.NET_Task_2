using Microsoft.Data.SqlClient;
using System.Data;
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

namespace ADO.NET_Task_2
{
    public partial class MainWindow : Window
    {
        string connectionString = "Data Source = DESKTOP-RH41O1K\\SQLEXPRESS;" +
            "Initial Catalog = Library;" +
            "Integrated Security = True;" +
            "Connect Timeout = 30;" +
            "Encrypt = True;" +
            "Trust Server Certificate = True;" +
            "Application Intent = ReadWrite;" +
            "Multi Subnet Failover = False";

        DataTable? dataTable;
        SqlDataAdapter? dataAdapter;

        public MainWindow()
        {
            InitializeComponent();

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                string selectQuery = "SELECT * FROM Authors";
                dataAdapter = new SqlDataAdapter(selectQuery, connection);

                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                dataGrid.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                string selectQuery = $"SELECT * FROM Authors WHERE FirstName = '{QueryTextBox.Text}'";
                dataAdapter = new SqlDataAdapter(selectQuery, connection);

                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                dataGrid.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(dataAdapter);

            dataAdapter?.Update(dataTable!);
        }

        private void AuthorsButton_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                string selectQuery = "SELECT * FROM Authors";
                SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, connection);

                dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGrid.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}