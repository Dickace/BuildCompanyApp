   M S B A M L   `   `   `  ����G  CBuildCompany, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:BuildCompanyBuildCompany  5   	   U QSystem.Runtime, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3aO8clr-namespace:System.Collections;assembly=System.RuntimeSystem.Collections 62   5clr-namespace:BuildCompany.ViewBuildCompany.View  5   	       BuildCompany.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:BuildCompany     5   	   Hcol8clr-namespace:System.Collections;assembly=System.Runtime     62   0viewclr-namespace:BuildCompany.View     5   	     � Icon$  Images/Logo.ico��5
   	    � Title$/ )Строительная компания��5   	   $	��450��6'   $	��800��67    � 	Resources 5       �� DataType!  BuildCompany.OrderViewModel"   BuildCompany.View.OrdersView   BuildCompany.TeamViewModel!   BuildCompany.View.TeamsView#  BuildCompany.SettingViewModel#   BuildCompany.View.SettingView"  BuildCompany.ClientViewModel#   BuildCompany.View.ClientsView$	  BuildCompany.WellComeViewModel$
   BuildCompany.View.WellcomeView$  BuildCompany.EmployeeViewModel$   BuildCompany.View.EmployeeView$  BuildCompany.VacationViewModel$   BuildCompany.View.VacationView"  BuildCompany.PayoutViewModel"   BuildCompany.View.PayoutView%  BuildCompany.SickLeaveViewModel%   BuildCompany.View.SickLeaveView(  "BuildCompany.MaterialListViewModel$   BuildCompany.View.MaterialList��%�  (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)(�� �     5      *, +)(�� �     5      *,	 +)(�� �     5!      *, +)(�� ,    5$      *, +)(�� ^    5'      *, +)(�� �    5*      *, +)(�� �    5-      *, +)�� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   " 	 6   .R�5      
  5       �� 5!   
   "  6   .R�5"        5#      �� 5$   
   "  6   .R�5%        5&      �� 5'   
   "  6   .R�5(        5)      �� 5*   
   "  6   .R�5+        5,      �� 5-   
   "  6   .R�5.        5/      50      .��52      ]� $
��True��6   .+�54   
   � $	��Top=�6   
����·�.+�55      ��  �� Orientation$ 
Horizontal=�6   $
��Left=�62   .+�56      �� $��Images/Logo.png��6   $��32��61   $
��Left=�6=   $��18,1,0,2q�6X   6m   �� 57      $��DemiBold"�6   $��23(�6/   $��43��6=   .��6J   Build Company6Y   58      � 59      $��Right=�6   5;      5=      �� 5@   
   $
��Left=�6   $
��Left=�6+   $	��160��6F   .+�5A      �� $��Заказы��6   $��orders��6E   $��50��6_   ��6&   �� *
NavCommand+5C      �� 5D      $��Бригады��6   $��teams��6F   $��50��6_   ��6'   �� *
NavCommand+5F      �� 5G      $��Сотрудники��6   $��	employees��6I   $��50��6f   ��6*   �� *
NavCommand+5I      �� 5J      $��Заказчики��6   $��clients��6H   $��50��6c   ��6)   �� *
NavCommand+5L      �� 5M      $��
Склад��6   $��	materials��6E   $��50��6c   ��6&   �� *
NavCommand+5O      �� 5P      $��Больничный��6   $��	sickleave��6I   $��50��6f   ��6*   �� *
NavCommand+5R      �� 5S      $��Отпуск��6   $��vacation��6E   $��50��6a   ��6&   �� *
NavCommand+5U      �� 5V      $��Бухгалтерия��6   $��payouts��6J   $��50��6e   ��6+   �� *
NavCommand+5X      �� 5Y      $��Настройки��6   $��setting��6H   $��50��6c   ��6)   �� *
NavCommand+5[      5\      �� 5]   
   ��6   �� *CurrentViewModel+6@   5d      5h      