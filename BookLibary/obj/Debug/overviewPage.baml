   M S B A M L   `   `   `  ����R  NOxyPlot.Wpf, Version=2.1.2.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0>.clr-namespace:OxyPlot.Wpf;assembly=OxyPlot.WpfOxyPlot.Wpf  5   	   E ABookLibary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:BookLibary
BookLibary 5         BookLibary.overviewPage   5      6oxy.clr-namespace:OxyPlot.Wpf;assembly=OxyPlot.Wpf  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:BookLibary     5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5	        N� Title$  overviewPage��5      $��615.124��6   .��5      �  � RowDefinitions 5   
   �� 5      $	��41* �6   �� 5      $	��64* �6   .+�5   
   �� -   5         ��Name$ comboBox��5      $��493,0,11.2,142.2q�6&   .@�5      �� $��users��6   �� 5      $��books��6   �� 5      $��lends��6   �� 5      $��expried lends��6   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ datagrid��5   %      
IsReadOnly . $
��Left=�67   $	��165��6R   $��10,0,0,0q�6_   $	��Top=�6q   $	��478��6�      OxyPlot.Wpf.PlotView  5   
   -   5          Name$ 
usersGraph��5      $��10,32.8,326.2,35.6q�6+   $��1��6G     5   
   -   5        $ 
booksGraph��5      $��306,32.8,10.2,35.6q�6+   $��1��6G   �� 5   
   -   5         ��Name$ 	numberBox��5      $y�Hidden=�6%   
�������$
��Left=�6L   $��113,170,0,0q�6g    �� TextWrapping$
 Wrap=�6|   $	��Top=�6�   $	��112��6�   $��27��6�   $��2��6�   �� 5    
   -   5         ��Name$ 	numberLbl��5       $y�Hidden=�6#   $��number of lends��67   $
��Left=�6Q   $��
10,170,0,0q�6l   $	��Top=�6�   $��2��6�   �� 5!   
   -   5        	 ��Name$	 	numberbtn��5!   "   $��update��6   $y�Hidden=�65   $
��Left=�6I   $��266,173,0,0q�6d   $	��Top=�6y   $��75��6�   $��2��6�   6�   5#      5%      