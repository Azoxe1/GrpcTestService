   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfApp.ViewsWpfApp.Views  5          WpfApp.Views.ShowDBView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:WpfApp.Views     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��auto �6#   .+�5      �� $��0��6   $��Все данные��6(   �� 5      $��1��6   $��
Назад��6%   $��5q�65   ��6@   �� *BackCommand+5      �� 5   
   $��1��6   ��6    �� *	BaseModel+��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value$ Stretch=�6C   5       �� View 5      �� 5       .P�5!      �� $��ID��6%    �� Width$
 auto��61    �� CellTemplate 5"      �� 5#      .R�5$   "   �� $��Center=�6,   ��6I   �� *ID+5%      5'      �� 5(      $��Имя��6%   $
 auto��62    5)      �� 5*      .R�5+   "   �� $��Center=�6,   ��6I   �� *Name+5,      5.      �� 5/      $��Возраст��6%   $
 auto��66    50      �� 51      .R�52   "   �� $��Center=�6,   ��6I   �� *Age+53      55      56      58      59      5:      