using System.Windows;
using System.Windows.Controls;
using TestForIS_23_02.DB;

namespace TestForIS_23_02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            RunUser();
        }

        private void RunUser()
        {
            try
            {
                DB.DB_Context b_Context = new DB_Context();
                listContent.ItemsSource = null; // грубо 
                listContent.ItemsSource = b_Context.Users.ToList();
            }
            catch
            {
                Title = "Error";
            }
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {

            var b = (Button)sender;
            var us = (User)b.DataContext;


            WindowUserChange user = new WindowUserChange(us);

            if (user.ShowDialog() == true)
                MessageBox.Show("Успешно!");
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var b = (Button)sender;
            var us = (User)b.DataContext;

            if (us == null)
                return;

            var r =MessageBox.Show($"Вы уверены что хотите удалить {us.Name}?" ,"Вопрос" , MessageBoxButton.YesNo );
            
            if (r==MessageBoxResult.Yes)
            {
                try
                {
                    using DB.DB_Context dB_Context = new DB_Context();
                    dB_Context.Users.Remove(us);
                    dB_Context.SaveChanges();
                    MessageBox.Show("Успешно!");
                    RunUser();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowUser user = new WindowUser();
            if( user.ShowDialog()==true)
            {
                RunUser();
            }
        }

        private void btnRefrash_Click(object sender, RoutedEventArgs e)
        {
            RunUser();
        }
    }
}