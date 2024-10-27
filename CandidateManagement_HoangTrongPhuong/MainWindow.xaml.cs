using Candidate_BusinessObject;
using Candidate_Service;
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

namespace CandidateManagement_HoangTrongPhuong
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IHrAccountService _accountService;
        public MainWindow()
        { 
            InitializeComponent();
            _accountService = new HrAccountService();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Hraccount hraccount = await _accountService.GetHrAccountsByEmailAsync(txtEmail.Text);
            if (hraccount != null && hraccount.Password.Equals(txtPassword.Text))
            {
                MessageBox.Show("Have data!");

                HrAccountManagement hrAccountManagement = new HrAccountManagement(hraccount.MemberRole.Value);
                hrAccountManagement.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show("No data!");
            }
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}