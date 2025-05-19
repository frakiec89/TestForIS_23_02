using System;
using System.Windows;
using TestForIS_23_02.DB;
// track
namespace TestForIS_23_02
{
    /// <summary>
    /// Логика взаимодействия для WindowUser.xaml
    /// </summary>
    public partial class WindowUser : Window
    {
        protected User  User { get; set; }
        public WindowUser()
        {
            InitializeComponent();
            Title = "Добавить";
            User = new User() ;
            base.DataContext = User;
        }

        protected virtual void btnAction_Click(object sender, RoutedEventArgs e)
        {
            DB.DB_Context dB_Context = new DB.DB_Context();
            try
            {
                dB_Context.Users.Add(User);
                dB_Context.SaveChanges();
                MessageBox.Show("Успешно!");
                DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                DialogResult= false;
            }   
        }
    }

    public class WindowUserChange : WindowUser
    {
        public WindowUserChange(User user)
        {
            User = user;
            Title = "Изменить";
            btnAction.Content = "Изменить";
            base.DataContext = User;
        }

        protected override void btnAction_Click(object sender, RoutedEventArgs e)
        {
            DB.DB_Context dB_Context = new DB.DB_Context();
            try
            {
                dB_Context.Users.Update(User);
                dB_Context.SaveChanges();
                MessageBox.Show("Успешно!");
                DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                DialogResult = false;
            }
        }
    }
}
