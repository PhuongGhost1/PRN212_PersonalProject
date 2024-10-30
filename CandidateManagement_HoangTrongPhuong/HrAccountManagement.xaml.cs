using Candidate_BusinessObject;
using Candidate_Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace CandidateManagement_HoangTrongPhuong
{
    /// <summary>
    /// Interaction logic for HrAccountManagement.xaml
    /// </summary>
    public partial class HrAccountManagement : Window, INotifyPropertyChanged
    {
        private int? RoleID = 0;
        private ICandidateProfileService _candidateProfile;
        private IJobHostingService _jobPosting;
        private CandidateProfile _selectedCandidate;
        public ObservableCollection<CandidateProfile> Candidates { get; set; }

        public CandidateProfile SelectedCandidate
        {
            get { return _selectedCandidate; }
            set
            {
                _selectedCandidate = value;
                OnPropertyChanged(nameof(SelectedCandidate));
            }
        }

        public HrAccountManagement(int? roleId)
        {
            InitializeComponent();
            _candidateProfile = new CandidateProfileService();
            _jobPosting = new JobHostingService();
            LoadHrAccountsAsync();
            this.RoleID = roleId;
            switch(RoleID)
            {
                case 1:
                    break;
                case 2:
                    this.btn_Add.IsEnabled = false;
                    this.btn_Add_Copy1.IsEnabled = false;
                    break;
                case 3:
                    this.btn_Add.IsEnabled = false;
                    this.btn_Add_Copy.IsEnabled = false;
                    this.btn_Add_Copy2.IsEnabled = false;
                    this.btn_Add_Copy1.IsEnabled = false;
                    break;
                default:
                    break;
            }
        }

        private void LoadHrAccountsAsync()
        {
            Candidates = new ObservableCollection<CandidateProfile>(_candidateProfile.GetCandidateProfiles());
            OnPropertyChanged(nameof(Candidates));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedCandidate = (CandidateProfile)((DataGrid)sender).SelectedItem;
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(candidateId.Text))
                {
                    MessageBox.Show("Candidate ID has not been selected!");
                    return;
                }

                var existingCandidate = _candidateProfile.GetCandidateProfile(candidateId.Text);
                if (existingCandidate != null)
                {
                    MessageBox.Show("A candidate with this ID already exists!");
                    return;
                }

                CandidateProfile candidateProfile = new CandidateProfile
                {
                    CandidateId = candidateId.Text,
                    Fullname = fullName.Text,
                    ProfileUrl = ImgURL.Text,
                    Birthday = birthday.SelectedDate,
                    ProfileShortDescription = description.Text,
                    PostingId = (JobPostingSelected.SelectedItem as JobPosting)?.PostingId
                };

                if (candidateProfile.PostingId == null)
                {
                    MessageBox.Show("Job Posting has not been selected!");
                    return;
                }

                bool isSucceed = _candidateProfile.AddCandidateProfile(candidateProfile);
                if (isSucceed)
                {
                    MessageBox.Show("Candidate added successfully!");
                    LoadHrAccountsAsync();
                }
                else
                {
                    MessageBox.Show("Failed to add candidate!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the candidate: " + ex.Message);
            }
        }

        private void btn_Add_Copy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(candidateId.Text))
                {
                    MessageBox.Show("Id chưa được lựa chọn!");
                }
                else 
                {
                    var candidate = _candidateProfile.GetCandidateProfile(candidateId.Text);
                    if (candidate != null)
                    {
                        candidate.Fullname = fullName.Text;
                        candidate.ProfileUrl = ImgURL.Text;
                        candidate.Birthday = birthday.SelectedDate;
                        candidate.ProfileShortDescription = description.Text;

                        if (JobPostingSelected.SelectedItem is JobPosting selectedJobPosting)
                        {
                            candidate.PostingId = selectedJobPosting.PostingId;
                        }
                        else
                        {
                            MessageBox.Show("JobPosting chưa được lựa chọn!");
                            return;
                        }

                        bool isSucceed = _candidateProfile.UpdateCandidateProfile(candidate.CandidateId, candidate);
                        if (isSucceed)
                        {
                            MessageBox.Show("Da cap nhat thanh vien thanh cong!");
                            LoadHrAccountsAsync();
                        }
                        else
                        {
                            MessageBox.Show("Cap nhat thanh vien that bai!");
                        }                
                    }
                    else
                    {
                        MessageBox.Show("Id chua ton tai");
                    }
                }         
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Khong the cap nhat!!!");
            }       
        }

        private void btn_Add_Copy1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(candidateId.Text))
                {
                    MessageBox.Show("Id chưa được lựa chọn!");
                }
                else
                {
                    var candidate = _candidateProfile.GetCandidateProfile(candidateId.Text);
                    if (candidate != null)
                    {
                        bool isSucceed = _candidateProfile.DeleteCandidateProfile(candidateId.Text);
                        if (isSucceed)
                        {
                            MessageBox.Show("Da xoa thanh vien thanh cong!");
                            LoadHrAccountsAsync();
                        }
                        else
                        {
                            MessageBox.Show("Xoa thanh vien that bai!");
                        }                                            
                    }
                    else
                    {
                        MessageBox.Show("Id khong ton tai!!!");
                    }
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Khong the xoa!");
            }           
        }

        private void btn_Add_Copy2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void JobPostingSelected_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.JobPostingSelected.ItemsSource = _jobPosting.GetJobPostings();
            this.JobPostingSelected.DisplayMemberPath = "JobPostingTitle";
            this.JobPostingSelected.SelectedValuePath = "PostingId";
        }
    }
}
