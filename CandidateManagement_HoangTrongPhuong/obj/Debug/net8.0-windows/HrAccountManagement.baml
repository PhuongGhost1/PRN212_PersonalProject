   M S B A M L   `   `   `  ����_  [CandidateManagement_HoangTrongPhuong, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:CandidateManagement_HoangTrongPhuong$CandidateManagement_HoangTrongPhuong  5   	   >    8CandidateManagement_HoangTrongPhuong.HrAccountManagement   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Dlocal2clr-namespace:CandidateManagement_HoangTrongPhuong     5   	   -   5          � Title$  HrAccountManagement��5   	   $	��450��6%   $	��800��62    � DataContext 5	   	   ��  �� RelativeSource �� *Self+.��5
      � -   5         �Name$ listBox��5
      $��	0,10,10,0q�6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��
0,212,0,73q�5         AutoGenerateColumns$
 True��5      $��Center=�5      $	��780��60   ��5      �� *
Candidates+ �� SelectedItem 5      �� *SelectedCandidate+5   0   �� 5   
   -   5         ��Name$ btn_Add��5      $	��Add��6"   $
��Left=�60   $��
27,366,0,0q�6K   $	��Top=�6_    J� RenderTransformOrigin$ 0.233,-0.545&�6w   $��44��6�   $	��109��6�   ���	#FF3FFF666�   �� 5   
   -   5        $ btn_Add_Copy��5      $��Update��6'   $
��Left=�68   $��233,367,0,0q�6S   $	��Top=�6h   $ 0.233,-0.545&�6�   $��43��6�   $	��109��6�   ���	#FF6EE8256�   �� 5   
   -   5        $ btn_Add_Copy1��5      $��Delete��6(   $
��Left=�69   $��456,367,0,0q�6T   $	��Top=�6i   $ 0.233,-0.545&�6�   $��43��6�   $	��109��6�   ���	#FFF609096�   �� 5   
   -   5        $ btn_Add_Copy2��5      $��Close��6(   $
��Left=�68   $��654,367,0,0q�6S   $	��Top=�6h   $ 0.233,-0.545&�6�   $��43��6�   $	��109��6�   ���	#FF20C8ED6�   �� 5   
   $"��CANDIDATE PROFILE MANAGEMENT��6   $
��Left=�67   $��
287,14,0,0q�6R   $	��Top=�6f   �� 5   
   $��Candidate ID��6   $
��Left=�6'   $��	27,47,0,0q�6B   $	��Top=�6U   �� 5   
   $��Fullname��6   $
��Left=�6#   $��	27,78,0,0q�6>   $	��Top=�6Q   �� 5   
   $��ImgURL��6   $
��Left=�6!   $��
27,109,0,0q�6<   $	��Top=�6P   �� 5   
   $��Birthday��6   $
��Left=�6#   $��
27,140,0,0q�6>   $	��Top=�6R   �� 5   
   $��
JobHosting��6   $
��Left=�6%   $��
456,47,0,0q�6@   $	��Top=�6T   �� 5   
   $��Description��6   $
��Left=�6&   $��
456,78,0,0q�6A   $	��Top=�6U   �� 5   
   -   5         ��Name$ candidateId��5   A   $
��Left=�6V   $��
128,51,0,0q�6q   	 �� TextWrapping$
	 Wrap=�6�   $	��Top=�6�   $	��120��6�   ��6   �� *SelectedCandidate.CandidateId+6�   �� 5    
   -	   5        $ fullName��5    >   $
��Left=�6P   $��
128,82,0,0q�6k   $
	 Wrap=�6   $	��Top=�6�   $	��120��6�   ��6   �� *SelectedCandidate.Fullname+6�   �� 5!   
   -
   5        $ ImgURL��5!   @   $
��Left=�6P   $��128,113,0,0q�6k   $
	 Wrap=�6�   $	��Top=�6�   $	��120��6�   ��6   �� *SelectedCandidate.ProfileUrl+6�   (  "System.Windows.Controls.DatePicker  5"   
   -   5        
  Name$
 birthday��5"   A   $
��Left=�6S   $��128,141,0,0q�6n   $	��Top=�6�   $	��120��6�      Text 6   �� *SelectedCandidate.Birthday+6�   �� 5#   
   -   5        $ description��5#   M   $
��Left=�6b   $��456,113,0,0q�6}   $
	 Wrap=�6�   $	��Top=�6�   $	��307��6�   $��53��6�   ��6   �� *+)SelectedCandidate.ProfileShortDescription+6�   �� 5$   
   -   5         ��Name$ JobPostingSelected��5$      $
��Left=�5%      $��
564,47,0,0q�5&      $	��Top=�5'      $	��120��5(       �� IsDropDownOpen$
 True��6   �� 5)   
   -   5        $ 	btn_Clear��5)      $��Clear��6$   $
��Left=�64   $��	6,187,0,0q�6O   $	��Top=�6b   $��60��6z   ���	#FFF4E9406�   �� 5*   
   -   5        $ searchTextBoxByName��5*      $
��Left=�5+      $��202,183,0,0q�5,      $
	 Wrap=�5-      $��Search by full name��5.      $	��Top=�5/      $	��140��50      $��24��51   @     52   
   -   5        $
 searchTextBoxByBirthDay��52      $
��Left=�66   $��370,183,0,0q�6Q   $	��Top=�6f   $	��140��6~   $ 0.496,2.549&�6�   6�   54      55      