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
                    MessageBox.Show("Id chưa được lựa chọn!");
                }
                else
                {
                    var candidate = _candidateProfile.GetCandidateProfile(candidateId.Text);
                    if (candidate != null)
                    {
                        MessageBox.Show("Candidate found with ID: " + candidate.CandidateId);
                        MessageBox.Show("Id đã tồn tại!!");
                    }
                    else
                    {
                        CandidateProfile candidateProfile = new CandidateProfile();
                        candidateProfile.CandidateId = candidateId.Text;
                        candidateProfile.Fullname = fullName.Text;
                        candidateProfile.ProfileUrl = ImgURL.Text;
                        candidateProfile.Birthday = birthday.SelectedDate;
                        candidateProfile.ProfileShortDescription = description.Text;

                        if (JobPostingSelected.SelectedItem is JobPosting selectedJobPosting)
                        {
                            candidateProfile.PostingId = selectedJobPosting.PostingId;
                            candidateProfile.Posting = selectedJobPosting;
                        }
                        else
                        {
                            MessageBox.Show("JobPosting chưa được lựa chọn!");
                            return;
                        }

                        bool isSucceed = _candidateProfile.AddCandidateProfile(candidateProfile);
                        if (isSucceed) 
                        {
                            MessageBox.Show("Da them thanh vien thanh cong!");
                            LoadHrAccountsAsync();
                        }
                        else
                        {
                            MessageBox.Show("Them thanh vien that bai!");
                        }
                    }
                }  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Khong the them!!!");
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
