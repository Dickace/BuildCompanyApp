   M S B A M L   `   `   `  ���� G  CBuildCompany, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:BuildCompanyBuildCompany  U QSystem.Runtime, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3aO8clr-namespace:System.Collections;assembly=System.RuntimeSystem.Collections 5clr-namespace:BuildCompany.ViewBuildCompany.View      BuildCompany.MainWindow   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:BuildCompany     Hcol8clr-namespace:System.Collections;assembly=System.Runtime     0viewclr-namespace:BuildCompany.View       � Icon$  Images/Logo.ico�� � Title$/ )Строительная компания��$	��450��$	��800�� � 	Resources  �� DataType!  BuildCompany.OrderViewModel"   BuildCompany.View.OrdersView   BuildCompany.TeamViewModel!   BuildCompany.View.TeamsView#  BuildCompany.SettingViewModel#   BuildCompany.View.SettingView"  BuildCompany.ClientViewModel#   BuildCompany.View.ClientsView$	  BuildCompany.EmployeeViewModel$
   BuildCompany.View.EmployeeView$  BuildCompany.VacationViewModel$   BuildCompany.View.VacationView"  BuildCompany.PayoutViewModel"   BuildCompany.View.PayoutView%  BuildCompany.SickLeaveViewModel%   BuildCompany.View.SickLeaveView(  "BuildCompany.MaterialListViewModel$   BuildCompany.View.MaterialList��%2  (��       *, +)(��      *, +)(�� $     *, +)(�� 6     *, +)(�� H     *,	 +)(�� Z     *, +)(�� l     *, +)(�� ~     *, +)(�� �     *, +)�� "  .R�  �� "  .R�  �� "  .R�  �� "  .R�  �� " 	 .R�
  �� "  .R�  �� "  .R�  �� "  .R�  �� "  .R�  .��]� $
��True��.+�� $	��Top=�
����·�.+���  �� Orientation$ 
Horizontal=�$
��Left=�.+��� $��Images/Logo.png��$��32��$
��Left=�$��18,1,0,2q��� $��DemiBold"�$��23(�$��43��.��Build Company� $��Right=��� $
��Left=�$
��Left=�$	��160��.+��� $��Заказы��$��orders��$��50������ *
NavCommand+�� $��Бригады��$��teams��$��50������ *
NavCommand+�� $��Сотрудники��$��	employees��$��50������ *
NavCommand+�� $��Клиенты��$��clients��$��50������ *
NavCommand+�� $��
Склад��$��	materials��$��50������ *
NavCommand+�� $��Больничный��$��	sickleave��$��50������ *
NavCommand+�� $��Отпуск��$��vacation��$��50������ *
NavCommand+�� $��Бухгалтерия��$��payouts��$��50������ *
NavCommand+�� $��Настройки��$��setting��$��50������ *
NavCommand+�� ���� *CurrentViewModel+