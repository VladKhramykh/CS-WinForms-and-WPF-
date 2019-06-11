using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;    

namespace OOP_8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        DataTable BankCountsTable;

        public MainWindow()
        {
            InitializeComponent();
            // получаем строку подключения из app.config
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string path = @"G:\УЧЁБА\ООП_CS (Forms)\Лабораторная 8\Creation.sql";
            string sql = "SELECT * FROM BankCounts";
            BankCountsTable = new DataTable();

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                if(connection == null)
                {
                    string createSql = "";
                    using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                    {
                        SqlCommand commandCreate = new SqlCommand(createSql, connection);                        
                    }
                }
                else
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    adapter = new SqlDataAdapter(command);
                }                

                // установка команды на добавление для вызова хранимой процедуры
                adapter.InsertCommand = new SqlCommand("sp_InsertAccount", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@OwnerId", SqlDbType.NVarChar, 40, "OwnerId"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Balance", SqlDbType.NVarChar, 20, "Balance"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@TypeOfCount", SqlDbType.NVarChar, 20, "TypeOfCount"));
                SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
                parameter.Direction = ParameterDirection.Output;

                connection.Open();
                adapter.Fill(BankCountsTable);
                bankAccountsGrid.ItemsSource = BankCountsTable.DefaultView;
                //----------------------------
                bankAccountsGrid.CanUserAddRows = false;

            }
            catch (Exception ex)
            {
                string createSql = "";
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    SqlCommand commandCreate = new SqlCommand(createSql, connection);
                    MessageBox.Show(ex.Message);
                }
                    
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        private void UpdateTableGUI()
        {
            string sql = "SELECT * FROM BankCounts";
            BankCountsTable = new DataTable();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);
                connection.Open();
                adapter.Fill(BankCountsTable);
                bankAccountsGrid.ItemsSource = BankCountsTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        private void UpdateDB()
        {
            SqlCommandBuilder comandbuilder = new SqlCommandBuilder(adapter);
            adapter.Update(BankCountsTable);
            bankAccountsGrid.CanUserAddRows = false;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateDB();
            UpdateTableGUI();
            bankAccountsGrid.CanUserAddRows = false;
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (bankAccountsGrid.SelectedItems != null)
            {
                for (int i = 0; i < bankAccountsGrid.SelectedItems.Count; i++)
                {
                    DataRowView datarowView = bankAccountsGrid.SelectedItems[i] as DataRowView;
                    if (datarowView != null)
                    {
                        DataRow dataRow = (DataRow)datarowView.Row;
                        dataRow.Delete();
                    }
                }
            }
            UpdateDB();
            bankAccountsGrid.CanUserAddRows = false;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            bankAccountsGrid.CanUserAddRows = true;
        }

        private void sortButton_Click(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT * FROM BankCounts ORDER BY Balance DESC ";
            BankCountsTable = new DataTable();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);
                connection.Open();
                adapter.Fill(BankCountsTable);
                bankAccountsGrid.ItemsSource = BankCountsTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        private void transButton_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); SqlTransaction transact = connection.BeginTransaction();
                SqlCommand transCommand1 = connection.CreateCommand();
                string name = "'" + nameText.Text + "'";
                string type = "'" + typeText.Text + "'";
                string balance = "'" + balanceText.Text + "'";
                transCommand1.CommandText = "INSERT INTO BankCounts (OwnerId, Balance, TypeOfCount) VALUES(" + name + "," + balance + "," + type + ")";
                transCommand1.Transaction = transact;
                transCommand1.ExecuteNonQuery();
                //диалог 
                MessageBoxResult response = MessageBox.Show("Команда выполнена" + Environment.NewLine + "подтвердить?", "Добавление", MessageBoxButton.YesNo);
                switch (response)
                {
                    case MessageBoxResult.Yes:  // подтверждаем транзакцию 
                        transact.Commit(); break;
                    case MessageBoxResult.No: // откатить транзакцию
                        transact.Rollback(); break;
                }
            }
        }

        private void BankAccountsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}